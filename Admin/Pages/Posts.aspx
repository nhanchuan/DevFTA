<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Posts.aspx.cs" Inherits="Admin_Pages_Posts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../App_Themes/admin/pagination.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Tất cả bài viết
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../../Admin/Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../../Admin/Pages/Posts.aspx">Tất cả Bài viết</a>
                <i class="fa fa-angle-right"></i>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <%-- Pages is Valid --%>
    <div class="row">
        <div class="col-lg-12">
            <div class="alert alert-danger display-none" id="alertPageValid" runat="server">
                <asp:Label ID="lblPageValid" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <%--End Pages is Valid --%>
    <div class="row">
        <!-- BEGIN Portlet PORTLET-->
        <div class="portlet light">
            <div class="portlet-title">
                <div class="caption">
                    <i class="glyphicon glyphicon-list-alt font-yellow-casablanca"></i>
                    <span class="caption-subject bold font-yellow-casablanca uppercase">Danh sách bài viết </span>
                    <span class="caption-helper">more samples...</span>
                </div>
                <div class="inputs">
                    <div class="portlet-input input-inline input-medium">
                        <div class="input-group">
                            <input id="txtsearch" type="text" class="form-control input-circle-left" placeholder="search..." title="Tìm Mã hoặc Tên khóa học" runat="server" />
                            <span class="input-group-btn">
                                <button id="btnSearchKhoaHoc" class="btn btn-circle-right btn-default" type="submit" runat="server">Go!</button>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="actions">
                    <a class="btn btn-circle btn-icon-only btn-default" title="Xuất danh sách Excel" href="#">
                        <i class="fa fa-file-excel-o"></i>
                    </a>
                    <a class="btn btn-circle btn-icon-only btn-default" href="#modalEditKhoa" data-toggle="modal" id="btnEditKhoaHoc" title="Chỉnh sửa thông tin khóa học" runat="server">
                        <i class="icon-wrench"></i>
                    </a>
                    <a id="btnRefreshLstKhoaHoc" class="btn btn-circle btn-icon-only btn-default" title="Làm mới danh sách" runat="server" href="#">
                        <i class="fa fa-refresh"></i>
                    </a>
                    <a class="btn btn-circle btn-icon-only btn-default fullscreen" href="#"></a>
                </div>
            </div>
            <div class="portlet-body">
                <asp:GridView ID="gwPosts" CssClass="table table-condensed table-responsive" runat="server"
                    AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                    OnSelectedIndexChanged="gwPosts_SelectedIndexChanged" OnRowDataBound="gwPosts_RowDataBound" OnRowDeleting="gwPosts_RowDeleting">
                    <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField HeaderText="Ảnh Bài viết">
                            <ItemTemplate>
                                <img src='<%# "../../" + Eval("ImagesUrl") %>' style="width: 60px; height: auto;" />
                                <asp:Label ID="lblID" CssClass="display-none" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Post Title">
                            <ItemTemplate>
                                <a class="bold" href='<%#"../../Admin/Pages/Post-Update.aspx?PostCode="+Eval("PostCode") %>'>
                                    <asp:Label ID="lblTitleEN" CssClass="bold" runat="server" Text='<%# Eval("TitleEN") %>'></asp:Label><br />
                                </a>
                                <label>VIETNAMESE</label><br />
                                <a class="bold" href='<%#"../../Admin/Pages/Post-Update.aspx?PostCode="+Eval("PostCode") %>'>
                                    <asp:Label ID="lblTitleVN" runat="server" Text='<%# Eval("TitleVN") %>'></asp:Label>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Meta Content">
                            <ItemTemplate>
                                <div class="form-group">
                                    <a class="accordion-toggle accordion-toggle-styled bold" data-toggle="collapse" href="#collMetaTitle"><i class="fa fa-plus-square-o"></i>&nbsp Meta Title</a>
                                    <div id="collMetaTitle" class="panel-collapse collapse">
                                        <asp:Label ID="lblMetaTitle" runat="server" Text='<%# Eval("MetaTitle") %>'></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <a class="accordion-toggle accordion-toggle-styled bold" data-toggle="collapse" href="#collMetaKeywords"><i class="fa fa-plus-square-o"></i>&nbsp Meta Keywords</a>
                                    <div id="collMetaKeywords" class="panel-collapse collapse">
                                        <asp:Label ID="lblMetaKeywords" runat="server" Text='<%# Eval("MetaKeywords") %>'></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <a class="accordion-toggle accordion-toggle-styled bold" data-toggle="collapse" href="#collMetaDescriptions"><i class="fa fa-plus-square-o"></i>&nbsp Meta Descriptions</a>
                                    <div id="collMetaDescriptions" class="panel-collapse collapse">
                                        <asp:Label ID="lblMetaDescriptions" runat="server" Text='<%# Eval("MetaDescriptions") %>'></asp:Label>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày tạo">
                            <ItemTemplate>
                                <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("CreateDate","{0:dd/MM/yyyy hh:mm:ss tt}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạng thái">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkPostStatus" Checked='<%# Eval("TopHot") %>' AccessKey='<%# Eval("ID") %>' OnCheckedChanged="chkPostStatus_CheckedChanged" AutoPostBack="true" Text="Duyệt" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Top Hot">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkTopHot" Checked='<%# Eval("TopHot") %>' AccessKey='<%# Eval("ID") %>' OnCheckedChanged="chkTopHot_CheckedChanged" AutoPostBack="true" Text="Top Hot" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="linkBtnDel" CssClass="btn btn-circle btn-icon-only btn-default" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" Text="Delete"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <SelectedRowStyle BackColor="#FBC741" ForeColor="Black" />
                    <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                    <RowStyle BackColor="#A1DCF2"></RowStyle>
                </asp:GridView>
            </div>
        </div>
        <div class="col-lg-12">
            <!-- BEGIN PAGINATOR -->
            <div class="col-md-4 col-sm-4 items-info">
            </div>
            <div class="col-md-8 col-sm-8">
                <div class="pagination_lst pull-right">
                    <asp:Repeater ID="rptPager" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "btn btn-default page_enabled" : "btn btn-default page_disabled" %>'
                                OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--<asp:Repeater ID="rptSearchPage" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSearchPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                OnClick="SearchPage_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>--%>
                    <div class="clearfix"></div>
                </div>
            </div>
            <!-- END PAGINATOR -->
        </div>
        <%-- END LIST CATOGORY --%>
    </div>
</asp:Content>

