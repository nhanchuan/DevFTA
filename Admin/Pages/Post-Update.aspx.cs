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

public partial class Admin_Pages_Post_Update : BasePage
{
    public int PageSize = 15;
    PostBLL posts;
    Post_Category_RelationshipsBLL post_category_relationships;
    CategoryBLL category;
    ImagesBLL images;
    TagsBLL tags;
    Tags_relationshipsBLL tags_relationships;
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
                if(check_Querystring())
                {
                    this.AlertPageValid(false, "", alertPageValid, lblPageValid);
                    this.PopulateRootLevel();
                    this.GetImagesPageWise(1);
                    this.load_cbltags();
                    this.LoadPostInfo();
                }
                else
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Admin/Pages/Posts.aspx");
                }
            }
        }
    }
    private Boolean check_Querystring()
    {
        posts = new PostBLL();
        string querystr = Request.QueryString["PostCode"];
        if(string.IsNullOrWhiteSpace(querystr))
        {
            return false;
        }
        else
        {
            Post po = posts.ListPostWithPostCode(querystr).FirstOrDefault();
            if(po==null)
            {
                return false;
            }
        }
        return true;
    }
    private void LoadPostInfo()
    {
        try
        {
            posts = new PostBLL();
            Post post = posts.ListPostWithPostCode(Request.QueryString["PostCode"]).FirstOrDefault();
            txtPostTitleVN.Value = post.TitleVN;
            txtPostTitleEN.Value = post.TitleEN;
            EditorPostContentVN.Text = post.PostContentVN;
            EditorPostContentEN.Text = post.PostContentEN;
            txtMetaTitle.Text = post.MetaTitle;
            txtMetaKeywords.Text = post.MetaKeywords;
            txtMetaDescription.Text = post.MetaDescriptions;
            chkTopHot.Checked = post.TopHot;
            lblpost_status.Text = (post.PostStatus) ? " -- Đăng bài --" : " -- Chờ xét duyệt  --";
            dlpost_status.Items.FindByValue((post.PostStatus) ? "1" : "0").Selected = true;

            lblTimePost.Text = post.PostTime.ToString();
            this.load_Checkcbltag(post.ID);

            images = new ImagesBLL();
            imgpost.Src = (images.ListWithID(post.PostImages).FirstOrDefault() == null) ? "../../images/noimage.jpg.jpg" : "../../" + images.ListWithID(post.PostImages).FirstOrDefault().ImagesUrl;
            txtPostImgTemp.Text = (images.ListWithID(post.PostImages).FirstOrDefault() == null) ? "" : images.ListWithID(post.PostImages).FirstOrDefault().ImagesName;
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
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
        this.checkedTreeBoxCategory(new PostBLL().ListPostWithPostCode(Request.QueryString["PostCode"]).FirstOrDefault().ID.ToString());
    }
    protected void checkedTreeBoxCategory(string postid)
    {
        post_category_relationships = new Post_Category_RelationshipsBLL();
        foreach (TreeNode node in treeboxCategory.Nodes)
        {
            List<Post_Category_Relationships> lstPCR = post_category_relationships.getCategoryWithPostId(int.Parse(postid));
            foreach (Post_Category_Relationships itm in lstPCR)
            {
                checknode(node, itm.CategoryID.ToString());
            }
        }
    }
    private void checknode(TreeNode node, string id)
    {
        if (node.Value.Trim() == id.Trim())
        {
            node.Checked = true;
        }
        foreach (TreeNode chidl in node.ChildNodes)
        {
            checknode(chidl, id);
        }
    }
    protected void load_cbltags()
    {
        tags = new TagsBLL();
        cbltags.DataSource = tags.ListAllTags();
        cbltags.DataTextField = "TagsName";
        cbltags.DataValueField = "ID";
        cbltags.DataBind();
    }
    protected void load_Checkcbltag(int postid)
    {
        tags_relationships = new Tags_relationshipsBLL();
        List<Tags_relationships> lstTR = tags_relationships.getTagsWithPostID(postid);
        foreach (Tags_relationships itm in lstTR)
        {
            cbltags.Items.FindByValue(itm.TagsID.ToString()).Selected = true;
        }
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
    protected class CategoryPost : IEquatable<CategoryPost>, IComparable<CategoryPost>
    {
        public int id { get; set; }
        public string name { get; set; }

        public int CompareTo(CategoryPost other)
        {
            if (other == null)
                return 1;

            else
                return this.id.CompareTo(other.id);
        }

        public bool Equals(CategoryPost other)
        {
            if (other == null) return false;
            CategoryPost objAsPost = other as CategoryPost;
            if (objAsPost == null) return false;
            else return Equals(objAsPost);
        }
    }
    protected class TagsPost : IEquatable<TagsPost>, IComparable<TagsPost>
    {
        public int id { get; set; }
        public string name { get; set; }

        public int CompareTo(TagsPost other)
        {
            if (other == null)
                return 1;

            else
                return this.id.CompareTo(other.id);
        }

        public bool Equals(TagsPost other)
        {
            if (other == null) return false;
            TagsPost objAsPost = other as TagsPost;
            if (objAsPost == null) return false;
            else return Equals(objAsPost);
        }
    }
    protected void New_Post_Category_relationships(string postcode)
    {
        posts = new PostBLL();
        post_category_relationships = new Post_Category_RelationshipsBLL();
        List<Post> lstP = posts.ListPostWithPostCode(postcode);
        Post pp = lstP.FirstOrDefault();
        int postid = pp.ID;
        List<CategoryPost> cp = new List<CategoryPost>();
        foreach (TreeNode n in treeboxCategory.CheckedNodes)
        {
            // arr.Add(n.Value);
            cp.Add(new CategoryPost() { id = int.Parse(n.Value), name = n.Text });
        }
        List<CategoryPost> newl = cp.OrderBy(r => r.id).ToList();
        foreach (CategoryPost itm in newl)
        {
            this.post_category_relationships.NewPost_Category_Relationships(postid, itm.id);
        }
    }
    protected void New_Tags_relationships(string postcode)
    {
        posts = new PostBLL();
        tags_relationships = new Tags_relationshipsBLL();
        List<Post> lstP = posts.ListPostWithPostCode(postcode);
        Post pp = lstP.FirstOrDefault();
        int postid = pp.ID;
        List<TagsPost> lstp = new List<TagsPost>();
        foreach (ListItem itm in cbltags.Items)
        {
            if (itm.Selected) lstp.Add(new TagsPost() { id = int.Parse(itm.Value), name = itm.Text });
        }
        List<TagsPost> newlt = lstp.OrderBy(r => r.id).ToList();
        foreach (TagsPost tp in newlt)
        {
            this.tags_relationships.NewTags_relationships(postid, tp.id);
        }
    }
    protected Boolean CheckExistTagsName(string name)
    {
        tags = new TagsBLL();
        List<Tags> lst = tags.getTagsWithName(name);
        Tags tg = lst.FirstOrDefault();
        if (tg != null)
        {
            return false;
        }
        return true;
    }
    protected void btnAddTags_Click(object sender, EventArgs e)
    {

        try
        {
            tags = new TagsBLL();
            string[] lsttags = txttagsname.Text.Split(',');
            int i = 0;
            while (i < lsttags.Length)
            {
                if (CheckExistTagsName(lsttags[i]))
                {
                    tags.newTagsName(lsttags[i]);
                }
                i++;
            }
            this.load_cbltags();
            string script = "window.onload = function() { calltagspanelClickEvent(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "calltagspanelClickEvent", script, true);
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }

    }
    //GET DATETIME
    private string getday(string str)
    {
        string day = str.Substring(0, 2);
        return day;
    }
    private string getmonth(string str)
    {
        string month = "";
        List<clsmonth> lstmonth = new List<clsmonth>();
        lstmonth.Add(new clsmonth("01", "January"));
        lstmonth.Add(new clsmonth("02", "February"));
        lstmonth.Add(new clsmonth("03", "March"));
        lstmonth.Add(new clsmonth("04", "April"));
        lstmonth.Add(new clsmonth("05", "May"));
        lstmonth.Add(new clsmonth("06", "June"));
        lstmonth.Add(new clsmonth("07", "July"));
        lstmonth.Add(new clsmonth("08", "August"));
        lstmonth.Add(new clsmonth("09", "September"));
        lstmonth.Add(new clsmonth("10", "October"));
        lstmonth.Add(new clsmonth("11", "November"));
        lstmonth.Add(new clsmonth("12", "December"));
        foreach (clsmonth itm in lstmonth)
        {
            if (str.Contains(itm.Strmonth))
            {
                month = itm.Num;
            }
        }
        return month;
    }
    [Serializable()]
    public class clsmonth
    {
        public string Num { get; set; }
        public string Strmonth { get; set; }
        public clsmonth(string num, string strmonth)
        {
            Num = num;
            Strmonth = strmonth;
        }
    }
    private string getyear(string str)
    {
        string year = str.Substring(str.IndexOf("-") - 5, 4);
        return year;
    }
    private string gethours(string str)
    {
        string hours = str.Substring(str.IndexOf(":") - 2, 2);
        return hours;
    }
    private string getminutes(string str)
    {
        string minutes = str.Substring(str.IndexOf(":") + 1, 2);
        return minutes;
    }
    private string gettimeRefix(string str)
    {
        string re = str.Substring(str.Length - 2, 2);
        return re;
    }
    protected int ImagesID(string filename)
    {
        int ImID = 0;
        images = new ImagesBLL();

        if (string.IsNullOrWhiteSpace(filename))
        {
            ImID = 0;
        }
        else
        {
            ImID = images.ImagesID(filename);
        }
        return ImID;
    }
    public Boolean UpdatePost(int ID)
    {
        posts = new PostBLL();

        string TitleVN = txtPostTitleVN.Value;
        string TitleEN = txtPostTitleEN.Value;
        string PostContentVN = EditorPostContentVN.Text;
        string PostContentEN = EditorPostContentEN.Text;
        string time = timePost.Value.ToString();
        DateTime ModifyDate = DateTime.Now;
        int ModifyBy = Session.GetCurrentUser().ID;
        string MetaTitle = txtMetaTitle.Text;
        string MetaKeywords = txtMetaKeywords.Text;
        string MetaDescriptions = txtMetaDescription.Text;
        bool PostStatus = (dlpost_status.SelectedValue == "0") ? false : true;
        bool TopHot = (chkTopHot.Checked == true) ? true : false;
        int imgID = ImagesID(txtPostImgTemp.Text);

        DateTime PostTime = (string.IsNullOrWhiteSpace(time)) ? Convert.ToDateTime(lblTimePost.Text) : Convert.ToDateTime(getmonth(time) + "/" + getday(time) + "/" + getyear(time) + " " + gethours(time) + ":" + getminutes(time) + ":00" + " " + gettimeRefix(time));
        return posts.UpdatePost(ID, TitleVN, TitleEN, PostContentVN, PostContentEN, ModifyDate, ModifyBy, MetaTitle, MetaKeywords, MetaDescriptions, PostStatus, TopHot, imgID, PostTime);
    }

    protected void btnUpdateTimePost_Click(object sender, EventArgs e)
    {
        Response.Write("<script>alert('" + DateTime.Now.ToString() + "')</script>");
    }

    protected void btnPostUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Post post = new PostBLL().ListPostWithPostCode(Request.QueryString["PostCode"]).FirstOrDefault();
            if (UpdatePost(post.ID))
            {
                if (new Tags_relationshipsBLL().DeleteWithPostID(post.ID) && new Post_Category_RelationshipsBLL().DeleteWithPostID(post.ID))
                {
                    this.New_Post_Category_relationships(Request.QueryString["PostCode"]);
                    this.New_Tags_relationships(Request.QueryString["PostCode"]);
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
}