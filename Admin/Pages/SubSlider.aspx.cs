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

public partial class Admin_Pages_SubSlider : BasePage
{
    SubSliderBLL subslider;
    ImagesBLL images;
    public int PageSize = 10;
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
                btnfixSubSlider.Attributes.Add("class", "btn btn-default disabled");
                btnselectImg.Attributes.Add("class", "btn btn-default disabled");
                this.GetSubSliderPageWise(1);
                this.GetImagesCTPageWise(1);
            }
        }
    }
    private void GetSubSliderPageWise(int pageIndex)
    {
        subslider =new SubSliderBLL();
        int recordCount = 0;
        gwSubSlider.DataSource = subslider.GetSubSliderPageWise(pageIndex, PageSize);
        recordCount = subslider.RecordCountSubSlider();
        gwSubSlider.DataBind();
        this.PopulatePager(rptPager, recordCount, pageIndex, PageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetSubSliderPageWise(pageIndex);
    }
    private void GetImagesCTPageWise(int pageIndex)
    {
        try
        {
            images = new ImagesBLL();
            int Size = 15;
            int recordCount = 0;
            rpChangeCTImage.DataSource = images.GetImagesPageWise(pageIndex, Size);
            recordCount = images.RecordCountImages();
            rpChangeCTImage.DataBind();
            this.PopulatePager(rptchangeImgCTPages, recordCount, pageIndex, Size);
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
    protected void ImgCT_Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetImagesCTPageWise(pageIndex);
        string script = "window.onload = function() { callmodalLBCtImages(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "callmodalLBCtImages", script, true);
    }
    private int UploadImg(FileUpload fileupload)
    {
        images = new ImagesBLL();
        string dateString = DateTime.Now.ToString("MM-dd-yyyy");
        string dirFullPath = HttpContext.Current.Server.MapPath("../../images/SubSlider/" + dateString + "/");

        if (!Directory.Exists(dirFullPath))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
        {
            Directory.CreateDirectory(dirFullPath);
        }
        string fileName = Path.GetFileName(fileupload.PostedFile.FileName);
        ImageCodecInfo jgpEncoder = null;
        string str_image = "";
        string fileExtension = "";
        if (!string.IsNullOrEmpty(fileName))
        {
            fileExtension = Path.GetExtension(fileName);
            str_image = dateString + "-" + RandomName + fileExtension;
            string pathToSave = HttpContext.Current.Server.MapPath("../../images/SubSlider/" + dateString + "/") + str_image;
            //file.SaveAs(pathToSave);
            System.Drawing.Image image = System.Drawing.Image.FromStream(fileupload.FileContent);
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
            Bitmap bmp1 = new Bitmap(fileupload.FileContent);
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 30L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(pathToSave, jgpEncoder, myEncoderParameters);
            this.images.NewImages(str_image, "images/SubSlider/" + dateString + "/" + str_image, Session.GetCurrentUser().ID);

        }

        Images img = images.ListWithImagesName(str_image).FirstOrDefault();
        return (str_image == "") ? 0 : img.ID;
    }
    protected void btnNewSubSlider_Click(object sender, EventArgs e)
    {
        try
        {
            subslider = new SubSliderBLL();
            if(subslider.NewSubSlider(txtTitle.Text,txtDescription.Text, UploadImg(FileImgUpload), chkShow.Checked, subslider.MaxItemindex()+1,Session.GetCurrentUser().ID,txtRedirectLink.Text))
            {
                this.GetSubSliderPageWise(1);
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    protected void gwSubSlider_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            subslider = new SubSliderBLL();
            images = new ImagesBLL();
            btnfixSubSlider.Attributes.Add("class", "btn btn-default");
            btnselectImg.Attributes.Add("class", "btn btn-default");
            int ID = Convert.ToInt32((gwSubSlider.SelectedRow.FindControl("lblID") as Label).Text);
            SubSlider sub = subslider.ListWithID(ID).FirstOrDefault();
            txtETitle.Text = sub.Title;
            txtEDescription.Text = sub.Descriptions;
            txtERedirectLink.Text = sub.RedirectLink;
            Images img = images.ListWithID(sub.SliderImg).FirstOrDefault();
            ImgEditImages.ImageUrl = (img == null) ? "#" : "../../" + img.ImagesUrl;
            chkEditStatus.Checked = sub.SliderStatus;
            UploadEditImage.ToolTip = (img == null) ? "" : img.ImagesName;
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
    [Serializable]
    class Number
    {
        int num;
        public Number(int num) // ham khoi tao
        {
            this.num = num;
        }
        public int getNum()     // ham tra ve gia tri num
        {
            return num;
        }
        public void setNum(int num) // ham set gia tri num
        {
            this.num = num;
        }
    }
    private void swap(Number a, Number b) // ham hoan vi
    {
        int temp = a.getNum();                  // gan num cua a cho temp
        a.setNum(b.getNum());                   // gan num cua b cho a
        b.setNum(temp);                         // gan temp cho num cua b
    }
    protected void lkbtnUp_Click(object sender, EventArgs e)
    {
        try
        {
            subslider = new SubSliderBLL();
            LinkButton lkbutton = (sender as LinkButton);
            //Get the command argument
            string commandArgument = lkbutton.CommandArgument;
            int id = int.Parse(commandArgument);
            Number a, b;
            Number A, B;
            List<SubSlider> lst = subslider.ListWithID(id);
            SubSlider sub = lst.FirstOrDefault();

            List<SubSlider> lstUP = subslider.ListWithSortOrder(subslider.MaxItemindexLK(sub.SortOrder)); //index B
            SubSlider sub_Up = lstUP.FirstOrDefault();

            if (sub_Up == null)
            {
                a = new Number(0);
                b = new Number(0);
                return;
            }
            else
            {
                A = new Number(sub.ID);
                B = new Number(sub_Up.ID);
                a = new Number(sub.SortOrder);
                b = new Number(sub_Up.SortOrder);
                this.swap(a, b);
                this.subslider.UpdateSortOrder(a.getNum(), A.getNum());
                this.subslider.UpdateSortOrder(b.getNum(), B.getNum());
                this.GetSubSliderPageWise(1);
                gwSubSlider.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    protected void lkbtnDown_Click(object sender, EventArgs e)
    {
        try
        {
            subslider = new SubSliderBLL();
            LinkButton lkbutton = (sender as LinkButton);
            //Get the command argument
            string commandArgument = lkbutton.CommandArgument;
            int id = int.Parse(commandArgument);
            Number a, b;
            Number A, B;
            List<SubSlider> lst = subslider.ListWithID(id);
            SubSlider sub = lst.FirstOrDefault();

            List<SubSlider> lstUP = subslider.ListWithSortOrder(subslider.MinItemindexLK(sub.SortOrder)); //index B
            SubSlider sub_Up = lstUP.FirstOrDefault();

            if (sub_Up == null)
            {
                a = new Number(0);
                b = new Number(0);
                return;
            }
            else
            {
                A = new Number(sub.ID);
                B = new Number(sub_Up.ID);
                a = new Number(sub.SortOrder);
                b = new Number(sub_Up.SortOrder);
                this.swap(a, b);
                this.subslider.UpdateSortOrder(a.getNum(), A.getNum());
                this.subslider.UpdateSortOrder(b.getNum(), B.getNum());
                this.GetSubSliderPageWise(1);
                gwSubSlider.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    protected void chkShow_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk = (sender as CheckBox);
            GridViewRow row = (GridViewRow)(((CheckBox)sender).NamingContainer);
            HiddenField hdnCheck = (HiddenField)row.Cells[4].FindControl("hiddenField1");
            subslider = new SubSliderBLL();
            if (subslider.UpdateStatus(Convert.ToInt32(hdnCheck.Value), chk.Checked))
            {
                this.GetSubSliderPageWise(1);
            }
            //this.AlertPageValid(true, hdnCheck.Value, alertPageValid, lblPageValid);

        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    protected void gwSubSlider_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("linkBtnDel") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this ?')");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + "')</script>");
        }
    }

    protected void gwSubSlider_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            subslider = new SubSliderBLL();
            int ID = Convert.ToInt32((gwSubSlider.Rows[e.RowIndex].FindControl("lblID") as Label).Text);
            if (subslider.DeleteWithID(ID))
            {
                this.GetSubSliderPageWise(1);
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
    protected void btnSevaEdit_Click(object sender, EventArgs e)
    {
        try
        {
            subslider = new SubSliderBLL();
            int ID = Convert.ToInt32((gwSubSlider.SelectedRow.FindControl("lblID") as Label).Text);
            SubSlider sub = subslider.ListWithID(ID).FirstOrDefault();
            if (subslider.UpdateSubSlider(ID, txtETitle.Text, txtEDescription.Text, (UploadImg(UploadEditImage) == 0) ? sub.SliderImg : UploadImg(UploadEditImage), chkEditStatus.Checked, txtERedirectLink.Text))
            {
                this.GetSubSliderPageWise(1);
            }
            else
            {
                this.AlertPageValid(true, "False to connect server !", alertPageValid, lblPageValid);
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    protected void btnChangeCTImages_Click(object sender, EventArgs e)
    {
        try
        {
            subslider = new SubSliderBLL();
            images = new ImagesBLL();
            int ID = Convert.ToInt32((gwSubSlider.SelectedRow.FindControl("lblID") as Label).Text);
            string http = "http://" + Request.Url.Authority + "/";
            string ImgNAme = HidImgUrlCT.Value.Remove(0, HidImgUrlCT.Value.LastIndexOf("/") + 1);
            Images img = images.ListWithImagesName(ImgNAme).FirstOrDefault();
            if (subslider.UpdateImage(ID, img.ID))
            {
                this.GetSubSliderPageWise(1);
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
}