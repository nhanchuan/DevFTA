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
using System.Text.RegularExpressions;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    SubSliderBLL subslider;
    CategoryBLL categories;
    PostBLL posts;
    TagsBLL tags;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Load_rptSubSlider();
            this.load_News();
            this.load_ModleSuKien(15);
            this.TheEventTookPlace(15);
        }
    }

    private void Load_rptSubSlider()
    {
        subslider = new SubSliderBLL();
        rptSubSlider.DataSource = subslider.ShowSubSlider();
        rptSubSlider.DataBind();
        rptindicators.DataSource = subslider.ShowSubSlider();
        rptindicators.DataBind();
    }
    private void load_News()
    {
        categories = new CategoryBLL();
        loadNewsCategoryTitle(16, lblLeftBlockNews);
        //loadNewsCategoryTitle(14, lblNewsMidTop);
        //loadNewsCategoryTitle(1, lblNewsMidBotom);
        //loadNewsCategoryTitle(6, lblNewsRight);

        load_BlockNews(16, rptLeftBlockNews, 8, 1, 2);
        load_BlockNews(16, rptNewsMidTop, 8, 3, 2);
        load_BlockNews(16, rptNewsMidBotom, 8, 5, 2);
        load_BlockNews(16, rptNewsRight, 8, 7, 3);
    }
    private void loadNewsCategoryTitle(int catID, Label lbl)
    {
        categories = new CategoryBLL();
        Category ct = categories.ListCategoryWithID(catID).FirstOrDefault();
        lbl.Text = (ct == null) ? "" : ct.NameVN;
    }
    private void load_BlockNews(int catID, Repeater rpt, int itemview, int start, int num)
    {
        categories = new CategoryBLL();
        posts = new PostBLL();
        Category ct = categories.ListCategoryWithID(catID).FirstOrDefault();
        rpt.DataSource = posts.WidgetIndexNews(ct.ID, itemview, start, num);
        rpt.DataBind();
    }
    protected string Limit(object desc, int maxLength)
    {
        var description = (string)desc;
        if (string.IsNullOrEmpty(description)) { return description; }
        return description.Length <= maxLength ?
            description : description.Substring(0, maxLength) + "...";
    }
    public string XoaKyTuDacBiet(string str)
    {
        string title_url = "";
        str = str.Replace(" ", "-");
        str = str.Replace("%", "-");
        str = str.Replace("~", "-");
        str = str.Replace("!", "-");
        str = str.Replace("@", "-");
        str = str.Replace("#", "-");
        str = str.Replace("$", "-");
        str = str.Replace("^", "-");
        str = str.Replace("&", "-");
        str = str.Replace("*", "-");
        str = str.Replace("(", "-");
        str = str.Replace(")", "-");
        str = str.Replace("{", "-");
        str = str.Replace("}", "-");
        str = str.Replace("<", "-");
        str = str.Replace(">", "-");
        str = str.Replace("|", "-");
        str = str.Replace(",", "-");
        str = str.Replace(".", "-");
        str = str.Replace("?", "-");
        str = str.Replace("\\", "-");
        str = str.Replace("/", "-");
        Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        string temp = str.Normalize(NormalizationForm.FormD);
        title_url = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        return title_url;
    }
    private void load_ModleSuKien(int CategoryID)
    {
        categories = new CategoryBLL();
        posts = new PostBLL();
        DataTable pot = posts.GetPostEventOnHome(CategoryID);
        foreach (DataRow r in pot.Rows)
        {
            lblEventNew.Text = (string.IsNullOrEmpty(r["TitleVN"].ToString())) ? "" : (string)r["TitleVN"];
            imgEventNew.Src=(string.IsNullOrEmpty(r["ImagesUrl"].ToString())) ? "#" : "../"+(string)r["ImagesUrl"];
            lblEventNewTimePost.Text= (string.IsNullOrEmpty(r["PostTime"].ToString())) ? "" : ((DateTime)r["PostTime"]).ToString("dd/MM/yyyy");
            lblEventNewContent.Text= (string.IsNullOrEmpty(r["MetaDescriptions"].ToString())) ? "" : Limit((string)r["MetaDescriptions"],500);
            this.load_rptTagsEventNew(Convert.ToInt32(r["ID"].ToString()));
        }
    }
    private void TheEventTookPlace(int CategoryID)
    {
        posts = new PostBLL();
        DataTable pot = posts.GetPostEventOnHome(CategoryID);
        rptTheEventTookPlace.DataSource = pot;
        rptTheEventTookPlace.DataBind();
    }
    private void load_rptTagsEventNew(int PostID)
    {
        tags = new TagsBLL();
        rptTagsEventNew.DataSource = tags.TbTagsByPostID(PostID);
        rptTagsEventNew.DataBind();
    }
}