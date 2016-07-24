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

public partial class _Default : System.Web.UI.Page
{
    SubSliderBLL subslider;
    CategoryBLL categories;
    PostBLL posts;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Load_rptSubSlider();
            this.load_News();
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
        loadNewsCategoryTitle(13, lblLeftBlockNews);
        loadNewsCategoryTitle(14, lblNewsMidTop);
        loadNewsCategoryTitle(1, lblNewsMidBotom);
        loadNewsCategoryTitle(6, lblNewsRight);

        load_BlockNews(13, rptLeftBlockNews, 2);
        load_BlockNews(14, rptNewsMidTop, 2);
        load_BlockNews(1, rptNewsMidBotom, 2);
        load_BlockNews(6, rptNewsRight, 3);
    }
    private void loadNewsCategoryTitle(int catID, Label lbl)
    {
        categories = new CategoryBLL();
        Category ct = categories.ListCategoryWithID(catID).FirstOrDefault();
        lbl.Text = (ct == null) ? "" : ct.NameVN;
    }
    private void load_BlockNews(int catID, Repeater rpt, int itemview)
    {
        categories = new CategoryBLL();
        posts = new PostBLL();
        Category ct = categories.ListCategoryWithID(catID).FirstOrDefault();
        rpt.DataSource = posts.WidgetIndexNews(ct.ID, itemview);
        rpt.DataBind();
    }
    protected string Limit(object desc, int maxLength)
    {
        var description = (string)desc;
        if (string.IsNullOrEmpty(description)) { return description; }
        return description.Length <= maxLength ?
            description : description.Substring(0, maxLength) + "...";
    }
}