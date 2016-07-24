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

public partial class Pages_BlogPage : System.Web.UI.Page
{
    public int PageSize = 10;
    CategoryBLL categores;
    PostBLL posts;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.load_data();
            this.GetPostPageWise(1);
        }
    }
    private void load_data()
    {
        categores = new CategoryBLL();
        string catID = RouteData.Values["Id"].ToString();
        if (!string.IsNullOrEmpty(catID))
        {
            Category category = categores.ListCategoryWithID(Convert.ToInt32(catID)).FirstOrDefault();
            lblCategoryName.Text = category.NameVN;
        }
    }
    protected string Limit(object desc, int maxLength)
    {
        var description = (string)desc;
        if (string.IsNullOrEmpty(description)) { return description; }
        return description.Length <= maxLength ?
            description : description.Substring(0, maxLength) + "...";
    }
    private void GetPostPageWise(int pageIndex)
    {
        posts = new PostBLL();
        string catID = RouteData.Values["Id"].ToString();
        rptPostItem.DataSource = posts.GetListPostsByCategoryIDPageWise(pageIndex, PageSize, Convert.ToInt32(catID));
        rptPostItem.DataBind();
        this.PopulatePager(rptPager, posts.CountListPostsByCategoryIDPageWise(Convert.ToInt32(catID)), pageIndex, PageSize);
    }
    //=======================================================================

    /// <summary>
    /// Repeater Populate Page Event
    /// </summary>
    /// <param name="rptPager"> Populate </param>
    /// <param name="recordCount">Sum Record In Table</param>
    /// <param name="currentPage"></param>
    /// <param name="PageSize"></param>
    public void PopulatePager(Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
    //========================================================================
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetPostPageWise(pageIndex);
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
}
