<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="BlogPage.aspx.cs" Inherits="Pages_BlogPage" %>

<%@ Register Src="~/Controls/PostSidebar.ascx" TagPrefix="uc1" TagName="PostSidebar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .Shorter {
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
        }
    </style>
    <div class="main">
        <div class="container">
            <ul class="breadcrumb">
                <li><a href="../Default.aspx">Home</a></li>
                <li><a href="../Pages/TinTucVaSuKien.aspx">Tin tức & Sự kiện</a></li>
            </ul>
            <!-- BEGIN SIDEBAR & CONTENT -->
            <div class="row margin-bottom-40">
                <!-- BEGIN CONTENT -->
                <div class="col-md-12 col-sm-12">
                    <h1>
                        <asp:Label ID="lblCategoryName" runat="server"></asp:Label></h1>
                    <div class="content-page">
                        <div class="row">
                            <!-- BEGIN LEFT SIDEBAR -->
                            <div class="col-md-9 col-sm-9 blog-posts">
                                <asp:Repeater ID="rptPostItem" runat="server">
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-md-4 col-sm-4">
                                                <img class="img-responsive" alt="" src='<%# "../../"+Eval("ImagesUrl") %>' />
                                            </div>
                                            <div class="col-md-8 col-sm-8">
                                                <h2><a href='<%# "Category-"+ XoaKyTuDacBiet(Eval("MetaTitle").ToString())+"-"+Eval("ID") %>'><%# Eval("TitleVN") %></a></h2>
                                                <ul class="blog-info">
                                                    <li><i class="fa fa-calendar"></i><%# Eval("PostTime","{0:dd-MM-yyyy}") %></li>
                                                    <li><i class="fa fa-comments"></i>17</li>
                                                    <li><i class="fa fa-tags"></i>Metronic, Keenthemes, UI Design</li>
                                                </ul>
                                                <p><%# Limit(Eval("MetaDescriptions"),500) %></p>
                                                <%--<p><%# Eval("MetaDescriptions") %></p>--%>
                                                <a href="blog-item.html" class="more">Read more <i class="icon-angle-right"></i></a>
                                            </div>
                                        </div>
                                        <hr class="blog-post-sep" />
                                    </ItemTemplate>
                                </asp:Repeater>
                                <ul class="pagination">
                                    <asp:Repeater ID="rptPager" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                    CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                                    OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'>
                                                </asp:LinkButton>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <!-- END LEFT SIDEBAR -->
                            <!-- BEGIN RIGHT SIDEBAR -->
                            <uc1:PostSidebar runat="server" ID="PostSidebar" />
                            <!-- END RIGHT SIDEBAR -->

                        </div>
                    </div>
                </div>
                <!-- END CONTENT -->
            </div>
            <!-- END SIDEBAR & CONTENT -->
        </div>
    </div>
</asp:Content>

