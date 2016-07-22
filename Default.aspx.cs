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
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            this.Load_rptSubSlider();
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
}