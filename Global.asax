<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">

    void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("Home", "", "~/Default.aspx");
        routes.MapPageRoute("TrangChu", "trang-chu", "~/Default.aspx");
        routes.MapPageRoute("LichSuHinhThanh", "lich-su-hinh-thanh", "~/Pages/LichSuHinhThanh.aspx");
        routes.MapPageRoute("DoiNguPhatTrien", "doi-ngu-phat-trien-va-chuyen-gia", "~/Pages/DoiNguSangLap.aspx");
        routes.MapPageRoute("LienHe", "lien-he", "~/Pages/LienHe.aspx");
        routes.MapPageRoute("DetailPost", "Category-{MetaTitle}-{PostId}", "~/Pages/PostItem.aspx");
        routes.MapPageRoute("BlogPage", "{Category}-{Id}", "~/Pages/BlogPage.aspx");
        
    }
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
