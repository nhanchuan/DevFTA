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

public partial class DefaultMasterPage : System.Web.UI.MasterPage
{
    MainMenuBLL mainmenu;
    SubMenuItemBLL submenuitem;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            this.load_rptMainMenu();
        }
    }
    private void load_rptMainMenu()
    {
        mainmenu = new MainMenuBLL();
        rptMainMenu.DataSource = mainmenu.ListMenuItemsByMenuStatus(true);
        rptMainMenu.DataBind();
    }

    protected void rptMainMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            submenuitem = new SubMenuItemBLL();
            Repeater childRepeater = (Repeater)e.Item.FindControl("rptSubMenuItem");
            Label lblmenuid = (Label)e.Item.FindControl("lblMenuID");
            int MenuID = Convert.ToInt32(lblmenuid.Text);
            childRepeater.DataSource = submenuitem.ListSubMenuItemByMenuID(MenuID);
            childRepeater.DataBind();
        }
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
