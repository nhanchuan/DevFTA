<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Admin_Pages_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Chuyên mục
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../../Admin/Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../../Admin/Pages/Posts.aspx">Bài viết</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../../Admin/Pages/Category.aspx">Chuyên mục</a>
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
    <%-- PORLET ADD NEW CATEGORY --%>
    <div class="row">
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-globe"></i>&nbsp Thêm chuyên mục
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a>
                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                    <a href="javascript:;" class="reload"></a>
                    <a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-horizontal">
                    <div class="form-body">
                        <%-- /Row --%>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Tên chuyên mục - VN</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtCategoryNameVN" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Tên chuyên mục - EN</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtCategoryNameEN" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- /Row --%>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label bold col-md-2">Chuỗi cho đường dẫn tĩnh</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtPermalink" CssClass="form-control" runat="server"></asp:TextBox>
                                        <label>Chuỗi cho đường dẫn tĩnh là phiên bản của tên hợp chuẩn với Đường dẫn (URL). Chuỗi này bao gồm chữ cái thường, số và dấu gạch ngang (-).</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- /Row --%>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Danh mục cha</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="dlParent" CssClass="form-control" runat="server"></asp:DropDownList>
                                        <label>Chuyên mục khác với thẻ, bạn có thể sử dụng nhiều cấp chuyên mục. Ví dụ: Trong chuyên mục nhạc, bạn có chuyên mục con là nhạc Pop, nhạc Jazz. Việc này hoàn toàn là tùy theo ý bạn.</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">SEO - Title</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtSeoTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- /Row --%>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Meta Title</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtMetaTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Meta Keywords</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtMetaKeywords" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- /Row --%>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label bold col-md-2">Meta Decriptions</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtMetaDescriptions" TextMode="MultiLine" Rows="3" CssClass="form-control" runat="server"></asp:TextBox>
                                        <label>Mô tả bình thường không được sử dụng trong giao diện, tuy nhiên có vài trang hiện thị mô tả này.</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- /Row --%>
                        <div class="row">
                            <div class="col-md-2">
                                <img src="../../images/default_images.jpg" id="ImgPostCategory" class="img-responsive" runat="server" />
                                <%--<asp:Image ID="" CssClass="img-responsive" ImageUrl="~/images/No_image.png" runat="server" />--%>
                            </div>
                            <div class="col-lg-10">
                                <label class="control-label">Chọn ảnh tiêu biểu</label>
                                <div class="row">
                                    <a class="btn red" id="btnrefreshImg" runat="server"><i class="fa fa-refresh">Clear</i></a>
                                    <a class="btn green" href="#modaluploadImages" data-toggle="modal"><i class="fa fa-upload"></i>Tải tập tin lên</a>
                                    <a class="btn yellow" href="#modalselectimages" data-toggle="modal"><i class="fa fa-bank"></i>Chọn từ thư viện</a>
                                </div>
                                <br />
                                <i>( Ảnh chức năng cho chuyên mục )</i>
                            </div>
                        </div>
                        <%-- /Row --%>
                        <div class="row">
                            <div class="col-md-8"></div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:CheckBox ID="CheckBox1" Text="Show On Home" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-actions right">
                        <a class="btn btn-default">Cancel</a>
                        <asp:Button ID="btnSaveNew" CssClass="btn blue" runat="server" Text="Thêm chuyên mục" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- END PORLET ADD NEW CATEGORY --%>
    <%-- LIST CATEGORY --%>
    <div class="clearfix"></div>
    <!-- BEGIN Portlet PORTLET-->
    <div class="portlet light">
        <div class="portlet-title">
            <div class="caption">
                <i class="glyphicon glyphicon-list-alt font-yellow-casablanca"></i>
                <span class="caption-subject bold font-yellow-casablanca uppercase">Danh sách chuyên mục </span>
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
        </div>
    </div>
    <%-- END LIST CATOGORY --%>
</asp:Content>

