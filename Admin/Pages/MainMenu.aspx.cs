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

public partial class Admin_Pages_MainMenu : BasePage
{
    MainMenuBLL mainmenu;
    CategoryBLL category;
    SubMenuItemBLL submenuitem;
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
                this.load_gwMenuItems();
            }
        }
    }

    private void load_gwMenuItems()
    {
        mainmenu = new MainMenuBLL();
        gwMenuItems.DataSource = mainmenu.ListMenuItems();
        gwMenuItems.DataBind();
    }
    protected void btnAddMenuItem_Click(object sender, EventArgs e)
    {
        try
        {

            mainmenu = new MainMenuBLL();
            if (mainmenu.NewMainMenu(txtItemname.Text, txtPermalink.Text, mainmenu.MaxItemindex() + 1, chkStatus.Checked))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                this.AlertPageValid(true, "False to connect server !", alertPageValid, lblPageValid);
                return;
            }

        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    protected void gwMenuItems_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void gwMenuItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    private void load_gwSubMenuItem(int menuId)
    {
        submenuitem = new SubMenuItemBLL();
        gwSubMenuItem.DataSource = submenuitem.ListSubMenuItemByMenuID(menuId);
        gwSubMenuItem.DataBind();
    }
    protected void gwMenuItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            mainmenu = new MainMenuBLL();
            int menuID = Convert.ToInt32((gwMenuItems.SelectedRow.FindControl("lblMenuID") as Label).Text);
            MainMenu menu = mainmenu.ListMenuItemsWithMenuID(menuID).FirstOrDefault();
            txtEditItemname.Text = menu.ItemName;
            txtEPermalink.Text = menu.Permalink;
            chkEStatus.Checked = menu.MenuStatus;
            btnSubmit.Enabled = true;
            this.load_dlSelectCategory();
            this.load_gwSubMenuItem(menuID);
            lblAddSubItemWaring.Text = "";
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
    private void load_dlSelectCategory()
    {
        category = new CategoryBLL();
        this.load_DropdownList(dlSelectCategory, category.ListAllCategory(), "NameVN", "ID");
        dlSelectCategory.Items.Insert(0, new ListItem("-- Selected Category --", "0"));
    }
    protected void chkShow_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            
            CheckBox chk = (sender as CheckBox);
            GridViewRow row = (GridViewRow)(((CheckBox)sender).NamingContainer);
            HiddenField hdnCheck = (HiddenField)row.Cells[4].FindControl("hiddenField1");
            mainmenu = new MainMenuBLL();
            if (mainmenu.UpdateStatus(Convert.ToInt32(hdnCheck.Value), chk.Checked))
            {
                this.load_gwMenuItems();
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            mainmenu = new MainMenuBLL();
            int menuID = Convert.ToInt32((gwMenuItems.SelectedRow.FindControl("lblMenuID") as Label).Text);
            if(mainmenu.UpdateMainMenu(menuID,txtEditItemname.Text,txtEPermalink.Text,chkEStatus.Checked))
            {
                this.load_gwMenuItems();
            }
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
            mainmenu = new MainMenuBLL();
            LinkButton lkbutton = (sender as LinkButton);
            //Get the command argument
            string commandArgument = lkbutton.CommandArgument;
            int menuid = int.Parse(commandArgument);
            Number a, b;
            Number A, B;
            List<MainMenu> lstMN = mainmenu.ListMenuItemsWithMenuID(menuid); //index A
            MainMenu menu = lstMN.FirstOrDefault();

            List<MainMenu> lstMUP = mainmenu.ListMenuItemsWithIndex(mainmenu.MaxItemindexLK(menu.ItemIndex)); //index B
            MainMenu menuUp = lstMUP.FirstOrDefault();

            if (menuUp == null)
            {
                a = new Number(0);
                b = new Number(0);
                return;
            }
            else
            {
                A = new Number(menu.MenuID);
                B = new Number(menuUp.MenuID);
                a = new Number(menu.ItemIndex);
                b = new Number(menuUp.ItemIndex);
                this.swap(a, b);
                this.mainmenu.UpdateItemIndex(a.getNum(), A.getNum());
                this.mainmenu.UpdateItemIndex(b.getNum(), B.getNum());
                this.load_gwMenuItems();
                gwMenuItems.SelectedIndex = -1;
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
            mainmenu = new MainMenuBLL();
            LinkButton lkbutton = (sender as LinkButton);
            //Get the command argument
            string commandArgument = lkbutton.CommandArgument;
            int menuid = int.Parse(commandArgument);
            Number a, b;
            Number A, B;
            List<MainMenu> lstMN = mainmenu.ListMenuItemsWithMenuID(menuid);
            MainMenu menu = lstMN.FirstOrDefault();
            List<MainMenu> lstMDown = mainmenu.ListMenuItemsWithIndex(mainmenu.MinItemindexLK(menu.ItemIndex)); //index B
            MainMenu menuDown = lstMDown.FirstOrDefault();
            if (menuDown == null)
            {
                a = new Number(0);
                b = new Number(0);
                return;
            }
            else
            {
                A = new Number(menu.MenuID);
                B = new Number(menuDown.MenuID);
                a = new Number(menu.ItemIndex);
                b = new Number(menuDown.ItemIndex);
                this.swap(a, b);
                this.mainmenu.UpdateItemIndex(a.getNum(), A.getNum());
                this.mainmenu.UpdateItemIndex(b.getNum(), B.getNum());
                this.load_gwMenuItems();
                gwMenuItems.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    protected void btnInsertItemtoMenu_Click(object sender, EventArgs e)
    {
        try
        {
            submenuitem = new SubMenuItemBLL();
            string strMenuID = (gwMenuItems.SelectedRow.FindControl("lblMenuID") as Label).Text;
            List<SubMenuItem> lstMC = submenuitem.ListItemByMenuIDandCategoryID(Convert.ToInt32(strMenuID), Convert.ToInt32(dlSelectCategory.SelectedValue));
            SubMenuItem menuItem = lstMC.FirstOrDefault();
            if (menuItem != null)
            {
                lblAddSubItemWaring.Text = "Danh mục đã có. Vui lòng chọn danh mục khác !";
            }
            else
            {
                //lblAddSubItemWaring.Text = menu_categry.CounkItemWithMenuID(Convert.ToInt32(strMenuID)).ToString();
                lblAddSubItemWaring.Text = "";
                if (submenuitem.AddNewSubMenuItem(Convert.ToInt32(strMenuID), Convert.ToInt32(dlSelectCategory.SelectedValue), submenuitem.MaxSortOrderByMenuID(Convert.ToInt32(strMenuID)) + 1))
                {
                    this.load_gwSubMenuItem(Convert.ToInt32(strMenuID));
                }
                else
                {
                    lblAddSubItemWaring.Text = "Thêm thất bại. Lỗi kết nối CSDL !";
                }
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    protected void gwSubMenuItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("linkBtnDelSubItem") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this ?')");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + "')</script>");
        }
    }

    protected void gwSubMenuItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            submenuitem = new SubMenuItemBLL();
            string strMenuID = (gwMenuItems.SelectedRow.FindControl("lblMenuID") as Label).Text;
            int subID = Convert.ToInt32((gwSubMenuItem.Rows[e.RowIndex].FindControl("lblmenuID") as Label).Text);

            if (this.submenuitem.DeleteByID(subID))
            {
                this.load_gwSubMenuItem(Convert.ToInt32(strMenuID));
            }
            else
            {
                Response.Write("<script>alert('Xóa Menu Item thất bại. Lỗi kết nối csdl !')</script>");
            }
        }
        catch (Exception ex)
        {
            lblAddSubItemWaring.Text = ex.ToLogString();
        }
    }

    protected void lkbtnSubUp_Click(object sender, EventArgs e)
    {
        try
        {
            submenuitem = new SubMenuItemBLL();
            string strMenuID = (gwMenuItems.SelectedRow.FindControl("lblMenuID") as Label).Text;
            LinkButton lkbutton = (sender as LinkButton);
            string commandArgument = lkbutton.CommandArgument;
            int c_menuid = int.Parse(commandArgument);
            Number a, b;
            Number A, B;
            List<SubMenuItem> lstCMN = submenuitem.ListItemByID(c_menuid);
            SubMenuItem c_menu = lstCMN.FirstOrDefault();
            List<SubMenuItem> lstCMUP = submenuitem.ListItemBySortOrderandMenuID(submenuitem.MaxItemindexLK(c_menu.SortOrder, Convert.ToInt32(strMenuID)), Convert.ToInt32(strMenuID));
            SubMenuItem menuUp = lstCMUP.FirstOrDefault();

            if (menuUp == null)
            {
                a = new Number(0);
                b = new Number(0);
                return;
            }
            else
            {
                A = new Number(c_menu.ID);
                B = new Number(menuUp.ID);
                a = new Number(c_menu.SortOrder);
                b = new Number(menuUp.SortOrder);
                this.swap(a, b);
                this.submenuitem.UpdateIndexItem(a.getNum(), A.getNum());
                this.submenuitem.UpdateIndexItem(b.getNum(), B.getNum());
                this.load_gwSubMenuItem(Convert.ToInt32(strMenuID));
                gwSubMenuItem.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
            lblAddSubItemWaring.Text = ex.ToLogString();
        }
    }

    protected void lkbtnSubDown_Click(object sender, EventArgs e)
    {
        try
        {
            submenuitem = new SubMenuItemBLL();
            string strMenuID = (gwMenuItems.SelectedRow.FindControl("lblMenuID") as Label).Text;
            LinkButton lkbutton = (sender as LinkButton);
            string commandArgument = lkbutton.CommandArgument;
            int c_menuid = int.Parse(commandArgument);
            Number a, b;
            Number A, B;
            List<SubMenuItem> lstCMN = submenuitem.ListItemByID(c_menuid);
            SubMenuItem c_menu = lstCMN.FirstOrDefault();
            List<SubMenuItem> lstCMUP = submenuitem.ListItemBySortOrderandMenuID(submenuitem.MinItemindexLK(c_menu.SortOrder, Convert.ToInt32(strMenuID)), Convert.ToInt32(strMenuID));
            SubMenuItem menuUp = lstCMUP.FirstOrDefault();

            if (menuUp == null)
            {
                a = new Number(0);
                b = new Number(0);
                return;
            }
            else
            {
                A = new Number(c_menu.ID);
                B = new Number(menuUp.ID);
                a = new Number(c_menu.SortOrder);
                b = new Number(menuUp.SortOrder);
                this.swap(a, b);
                this.submenuitem.UpdateIndexItem(a.getNum(), A.getNum());
                this.submenuitem.UpdateIndexItem(b.getNum(), B.getNum());
                this.load_gwSubMenuItem(Convert.ToInt32(strMenuID));
                gwSubMenuItem.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
            lblAddSubItemWaring.Text = ex.ToLogString();
        }
    }
}