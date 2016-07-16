using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessLogicLayer;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Web.Services;
using System.Configuration;

public partial class Admin_Pages_Post_New : BasePage
{
    public int PageSize = 15;
    PostBLL posts;
    Post_Category_Relationships post_category_relationships;
    CategoryBLL category;
    ImagesBLL images;
    TagsBLL tags;
    Tags_relationships tags_relationships;

    //protected override void OnLoad(EventArgs e)
    //{
    //    CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
    //    _FileBrowser.BasePath = "/Admin/ckfinder/";
    //    _FileBrowser.SetupCKEditor(EditorPostContentVN);
    //    _FileBrowser.SetupCKEditor(EditorPostContentEN);
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        if (!IsPostBack)
        {
            if (Session.GetCurrentUser() == null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Admin/Login.aspx");
            }
            else
            {
                this.AlertPageValid(false, "", alertPageValid, lblPageValid);
                this.PopulateRootLevel();
                this.GetImagesPageWise(1);
            }
        }
    }
    private void PopulateRootLevel()
    {
        category = new CategoryBLL();
        DataTable tbnodeRoot = category.getCategoryWithParentNull();
        PopulateNodes(tbnodeRoot, treeboxCategory.Nodes);
    }
    private void PopulateNodes(DataTable tb, TreeNodeCollection node)
    {
        foreach (DataRow r in tb.Rows)
        {
            //int parentId = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
            TreeNode child = new TreeNode
            {
                Text = (string)r["NameVN"],
                Value = r["ID"].ToString()
            };
            int dec = (string.IsNullOrEmpty(r["childnodecount"].ToString())) ? 0 : (int)r["childnodecount"];
            child.PopulateOnDemand = (dec > 0);
            node.Add(child);
        }
    }
    private void PopulateSubLevel(int parentid, TreeNode parentNode)
    {
        category = new CategoryBLL();
        DataTable dtChild = category.getCategoryWithParent(parentid);
        PopulateNodes(dtChild, parentNode.ChildNodes);
    }
    protected void treeboxCategory_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        PopulateSubLevel(int.Parse(e.Node.Value), e.Node);
    }
    protected void btnuploadImg_Click(object sender, EventArgs e)
    {
        try
        {
            images = new ImagesBLL();
            string dateString = DateTime.Now.ToString("MM-dd-yyyy");
            string dirFullPath = HttpContext.Current.Server.MapPath("../../images/Uploads/" + dateString + "/");

            if (!Directory.Exists(dirFullPath))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(dirFullPath);
            }
            string fileName = Path.GetFileName(fileUploadImgPost.PostedFile.FileName);
            ImageCodecInfo jgpEncoder = null;
            string str_image = "";
            string fileExtension = "";
            if (!string.IsNullOrEmpty(fileName))
            {
                fileExtension = Path.GetExtension(fileName);
                str_image = dateString + "-" + RandomName + fileExtension;
                string pathToSave = HttpContext.Current.Server.MapPath("../../images/Uploads/" + dateString + "/") + str_image;
                //file.SaveAs(pathToSave);
                System.Drawing.Image image = System.Drawing.Image.FromStream(fileUploadImgPost.FileContent);
                if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Gif);
                else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Bmp.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Bmp);
                else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Png);
                else
                    throw new System.ArgumentException("Invalid File Type");
                Bitmap bmp1 = new Bitmap(fileUploadImgPost.FileContent);
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 30L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp1.Save(pathToSave, jgpEncoder, myEncoderParameters);

                this.images.NewImages(str_image, "images/Uploads/" + dateString + "/" + str_image, Session.GetCurrentUser().ID);
                txtPostImgTemp.Text = str_image;
                imgpost.Src = "../../images/Uploads/" + dateString + "/" + str_image;
            }
            else
            {
                Response.Write("<script>alert('Upload Image False !')</script>");
                return;
            }
            string script = "window.onload = function() { callImagesPanelClickEvent(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "callImagesPanelClickEvent", script, true);
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
    //Load Images
    private void GetImagesPageWise(int pageIndex)
    {

        try
        {
            images = new ImagesBLL();
            int recordCount = 0;
            rpLstImg.DataSource = images.GetImagesPageWise(pageIndex, PageSize);
            recordCount = images.RecordCountImages();
            rpLstImg.DataBind();
            this.PopulatePager(recordCount, pageIndex);

        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
    private void PopulatePager(int recordCount, int currentPage)
    {
        List<ListItem> pages = new List<ListItem>();
        int startIndex, endIndex;
        int pagerSpan = 5;

        //Calculate the Start and End Index of pages to be displayed.
        double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
        endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
        if (currentPage > pagerSpan % 2)
        {
            if (currentPage == 2)
            {
                endIndex = 5;
            }
            else
            {
                endIndex = currentPage + 2;
            }
        }
        else
        {
            endIndex = (pagerSpan - currentPage) + 1;
        }

        if (endIndex - (pagerSpan - 1) > startIndex)
        {
            startIndex = endIndex - (pagerSpan - 1);
        }

        if (endIndex > pageCount)
        {
            endIndex = pageCount;
            startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
        }

        //Add the First Page Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("First", "1"));
        }

        //Add the Previous Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("<<", (currentPage - 1).ToString()));
        }

        for (int i = startIndex; i <= endIndex; i++)
        {
            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
        }

        //Add the Next Button.
        if (currentPage < pageCount)
        {
            pages.Add(new ListItem(">>", (currentPage + 1).ToString()));
        }

        //Add the Last Button.
        if (currentPage != pageCount)
        {
            pages.Add(new ListItem("Last", pageCount.ToString()));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetImagesPageWise(pageIndex);
        string script = "window.onload = function() { callmodalPostImages(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "callmodalPostImages", script, true);
    }
    protected void btnchangeImgPost_Click(object sender, EventArgs e)
    {
        string http = "http://" + Request.Url.Authority + "/";
        txtPostImgTemp.Text = HiddenimgSelect.Value.Remove(0, HiddenimgSelect.Value.LastIndexOf("/") + 1);
        imgpost.Src = "../../" + HiddenimgSelect.Value.Remove(0, http.Length);
        string script = "window.onload = function() { callImagesPanelClickEvent(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "callImagesPanelClickEvent", script, true);
    }

    protected void btnPostNew_Click(object sender, EventArgs e)
    {
        try
        {
            posts = new PostBLL();
            post_category_relationships = new Post_Category_Relationships();
            category = new CategoryBLL();
            images = new ImagesBLL();
            tags = new TagsBLL();
            tags_relationships = new Tags_relationships();



        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
}