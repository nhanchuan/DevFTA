<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Admin_Pages_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../App_Themes/admin/pagination.css" rel="stylesheet" />
    <style type="text/css">
        .page_disabled {
            background: #ff6a00;
        }
    </style>
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
    <%-- LIST CATEGORY --%>
    <div class="clearfix"></div>
    <div class="row">
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
                    <a id="btnchangeLBImageCT" runat="server" title="Chọn ảnh từ thư viện" href="#modalCategoryChangeImages" data-toggle="modal">
                        <i class="fa fa-image"></i>
                    </a>
                    <a href="#modalEditCategory" data-toggle="modal" id="btnEditCategory" title="Chỉnh sửa thông tin danh mục" runat="server">
                        <i class="icon-wrench"></i>
                    </a>
                    <a id="btnRefreshLstKhoaHoc" class="btn btn-circle btn-icon-only btn-default" title="Làm mới danh sách" runat="server" href="#">
                        <i class="fa fa-refresh"></i>
                    </a>
                    <a class="btn btn-circle btn-icon-only btn-default fullscreen" href="#"></a>
                </div>
            </div>
            <div class="portlet-body">
                <asp:GridView ID="gwCategory" CssClass="table table-condensed table-responsive" runat="server"
                    AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                    OnSelectedIndexChanged="gwCategory_SelectedIndexChanged" 
                    OnRowDataBound="gwCategory_RowDataBound" 
                    OnRowDeleting="gwCategory_RowDeleting">
                    <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên Danh Mục - VN">
                            <ItemTemplate>
                                <asp:Label ID="lblCategoryID" CssClass="display-none" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                <asp:Label ID="lblNameVN" runat="server" Text='<%# Bind("NameVN") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên Danh Mục - EN">
                            <ItemTemplate>
                                <asp:Label ID="lblNameEN" runat="server" Text='<%# Bind("NameEN") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Meta Descriptions">
                            <ItemTemplate>
                                <asp:Label ID="lblMetaDescriptions" runat="server" Text='<%# Bind("MetaDescriptions") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Permalink">
                            <ItemTemplate>
                                <asp:Label ID="lblPermalink" runat="server" Text='<%# Bind("Permalink") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thuộc danh mục">
                            <ItemTemplate>
                                <asp:Label ID="lblParentVN" runat="server" Text='<%# Bind("ParentVN") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hình ảnh">
                            <ItemTemplate>
                                <img src='<%# "../../" + Eval("ImagesUrl") %>' style="width: 60px; height: auto;" />
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
                    <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                    <RowStyle BackColor="#A1DCF2"></RowStyle>
                </asp:GridView>
                <div class="col-lg-12 margin-bottom-20">
                    <!-- BEGIN PAGINATOR -->
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
                    <!-- END PAGINATOR -->
                </div>
            </div>
        </div>
        
        <%-- END LIST CATOGORY --%>
    </div>
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
                                    <label class="control-label bold col-md-4">Tên chuyên mục - VN (<span class="required">*</span>)</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtCategoryNameVN" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtCategoryNameVN" ValidationGroup="validNewCategory" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Category name can't be blank !"></asp:RequiredFieldValidator>
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
                                    <a class="btn green" href="#coluploadUploadImg" data-toggle="collapse"><i class="fa fa-upload"></i>Tải tập tin lên</a>
                                    <a class="btn yellow" href="#modalCategoryImages" id="btnViewModalImages" data-toggle="modal"><i class="fa fa-bank"></i>Chọn từ thư viện</a>
                                </div>
                                <br />
                                <i>( Ảnh chức năng cho chuyên mục )</i>
                                <div class="col-md-12">
                                    <%-- Collapse Upload Images --%>
                                    <div id="coluploadUploadImg" class="panel-collapse collapse">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <div class="input-icon">
                                                    <i class="fa fa-file"></i>
                                                    <asp:FileUpload ID="fileUploadImgCategory" onchange="previewFile()" CssClass="form-control" runat="server" />
                                                </div>
                                                <span class="input-group-btn">
                                                    <asp:Button ID="btnuploadImg" CssClass="btn btn-success" OnClick="btnuploadImg_Click" ValidationGroup="fileUploadImgCategory" runat="server" Text="<= OK" />
                                                </span>
                                            </div>
                                            <asp:RequiredFieldValidator ErrorMessage="You have not picked a picture !"
                                                ControlToValidate="fileUploadImgCategory" ValidationGroup="fileUploadImgCategory"
                                                runat="server" Display="Dynamic" ForeColor="Red" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="(.)+(.jpg|.jpeg|.gif|.png|.JPG|.JPEG|.GIF|.PNG)$"
                                                ControlToValidate="fileUploadImgCategory"
                                                ValidationGroup="fileUploadImgCategory"
                                                runat="server" ForeColor="Red"
                                                ErrorMessage="Please select a valid Images file !"
                                                Display="Dynamic" />
                                        </div>
                                        <label>You can upload JPG, GIF, or PNG file. Maximum file size is 4MB.</label>
                                        <%-- Tên Images Tạm --%>
                                        <asp:TextBox ID="txtImageTemp" CssClass="display-none" runat="server"></asp:TextBox>
                                    </div>
                                    <%-- End Collapse Upload Images --%>
                                </div>
                            </div>
                        </div>

                        <%-- /Row --%>
                        <div class="row">
                            <div class="col-md-8"></div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:CheckBox ID="chkShowOnHome" Text="Show On Home" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-actions right">
                        <a class="btn btn-default">Cancel</a>
                        <asp:Button ID="btnSaveNewCategory" ValidationGroup="validNewCategory" CssClass="btn blue" OnClick="btnSaveNewCategory_Click" runat="server" Text="Thêm chuyên mục" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- END PORLET ADD NEW CATEGORY --%>

    <%-- Modal edit Category --%>
    <div class="modal fade" id="modalEditCategory" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Edit Category    
                    </h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label>Tên chuyên mục - VN (<span>*</span>)</label>
                                <asp:TextBox ID="txtENameVN" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Tên chuyên mục - EN </label>
                                <asp:TextBox ID="txtENameEN" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="row">
                                <div class="col-lg-8">
                                    <div class="form-group">
                                        <label>Chuỗi cho đường dẫn tĩnh</label>
                                        <asp:TextBox ID="txtEPermalink" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Danh mục cha</label>
                                        <asp:DropDownList ID="dlEParent" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>SEO - Title</label>
                                        <asp:TextBox ID="txtESeoTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Meta Title</label>
                                        <asp:TextBox ID="txtEMetaTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Meta Keywords</label>
                                        <asp:TextBox ID="txtEMetaKeywords" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Meta Decriptions</label>
                                        <asp:TextBox ID="txtEMetaDescriptions" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <asp:CheckBox ID="chkUpdateStatus" Text="Status" runat="server" />
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:CheckBox ID="chkShowHome" Text="Show On Home" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label>Upload File</label>
                                        <p>
                                            You can upload JPG, GIF, or PNG file. Maximum file size is 4MB.
                                        </p>
                                        <asp:FileUpload ID="FileUploadUpdateImg" CssClass="form-control margin-bottom-25" onchange="previewFileUpdate()" runat="server" />
                                        <asp:RequiredFieldValidator ErrorMessage="Required"
                                            ControlToValidate="FileUploadUpdateImg" ValidationGroup="validUploadFileImgUpload"
                                            runat="server" Display="Dynamic" ForeColor="Red" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.JPG|.JPEG|.GIF|.PNG)$"
                                            ControlToValidate="FileUploadUpdateImg"
                                            ValidationGroup="validUploadFileImgUpload"
                                            runat="server" ForeColor="Red"
                                            ErrorMessage="Please select a valid Images file !"
                                            Display="Dynamic" />
                                        <div class="clearfix"></div>
                                        <div class="col-lg-2"></div>
                                        <div class="col-lg-8">
                                            <asp:Image ID="ImageUpdate" CssClass="img-responsive" runat="server" />
                                        </div>
                                        <div class="col-lg-2"></div>
                                        <asp:TextBox ID="txtImgUpdateTemp" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal" aria-hidden="true">Cancel</a>
                    <asp:Button ID="btnUpdateCategory" CssClass="btn btn-primary" OnClick="btnUpdateCategory_Click" runat="server" Text="Update" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Edit Category --%>

    <%-- Modal Category Libray Images --%>
    <div class="modal" id="modalCategoryImages" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-full">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Select Images</h4>
                </div>
                <div class="modal-body background">
                    <div class="panel-default">
                        <div class="panel-body">
                            <div class="col-lg-9">
                                <%--<asp:UpdatePanel runat="server">
                                    <ContentTemplate>--%>
                                        <div class="col-lg-12">
                                            
                                            <div class="form-group margin-bottom-20">
                                                <div class="pagination_lst">
                                                    <asp:Repeater ID="rptPaginationImg" runat="server">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "btn btn-default page_enabled" : "btn btn-default page_disabled" %>'
                                                                OnClick="Img_Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>

                                            <div style="height: 700px; overflow: auto;">
                                                <div class="grid-container">
                                                    <ul class="rig columns-5">
                                                        <asp:Repeater ID="rpLstImg" runat="server">
                                                            <ItemTemplate>
                                                                <li>
                                                                    <a href='<%#"../../"+Eval("ImagesUrl") %>' onclick="return showanh(this.href)"">
                                                                        <img src='<%#"../../"+Eval("ImagesUrl") %>' />
                                                                        <h4>Upload by <i style="color: red;"><%# Eval("UserName") %></i></h4>
                                                                        <p><i class="fa fa-clock-o"></i><%# Eval("DateOfStart") %></p>
                                                                    </a>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    <%--</ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                            <div class="col-lg-3">
                                <%-- info --%>
                                <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="vlidSelectImage" DisplayMode="BulletList" ShowSummary="true" ForeColor="Red" runat="server" />
                                <asp:Image ID="ImagesSelect" CssClass="img-responsive" runat="server" />
                                <br />
                                <asp:HiddenField ID="HiddenimgSelect" runat="server" />
                                <label>Url Image:</label>
                                <asp:TextBox ID="txtImgUrl" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtImgUrl" ValidationGroup="vlidSelectImage" ErrorMessage="No Image Selected !" Display="None"></asp:RequiredFieldValidator>
                                <%-- end info --%>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Hủy</a>
                    <asp:Button ID="btnchangeImgPost" CssClass="btn btn-primary pull-right" ValidationGroup="vlidSelectImage" OnClick="btnchangeImgPost_Click" runat="server" Text="Save !" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Category Libray Images --%>

    <%-- Modal Category Change Images --%>
    <div class="modal" id="modalCategoryChangeImages" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-full">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Select Images</h4>
                </div>
                <div class="modal-body background">
                    <div class="panel-default">
                        <div class="panel-body">
                            <div class="col-lg-9">
                                <%--<asp:UpdatePanel runat="server">
                                    <ContentTemplate>--%>
                                        <div class="col-lg-12">
                                            <div class="form-group margin-bottom-20">
                                                <div class="pagination_lst">
                                                    <asp:Repeater ID="rptchangeImgCTPages" runat="server">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "btn btn-default page_enabled" : "btn btn-default page_disabled" %>'
                                                                OnClick="ImgCT_Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>
                                            <div style="height: 700px; overflow: auto;">
                                                <div class="grid-container">
                                                    <ul class="rig columns-5">
                                                        <asp:Repeater ID="rpChangeCTImage" runat="server">
                                                            <ItemTemplate>
                                                                <li>
                                                                    <a href='<%#"../../"+Eval("ImagesUrl") %>' onclick="return showlbanh(this.href)"">
                                                                        <img src='<%#"../../"+Eval("ImagesUrl") %>' />
                                                                        <h4>Upload by <i style="color: red;"><%# Eval("UserName") %></i></h4>
                                                                        <p><i class="fa fa-clock-o"></i><%# Eval("DateOfStart") %></p>
                                                                    </a>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    <%--</ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                            <div class="col-lg-3">
                                <%-- info --%>
                                <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="vlidSelectImageCT" DisplayMode="BulletList" ShowSummary="true" ForeColor="Red" runat="server" />
                                <asp:Image ID="ImagesLBSelect" CssClass="img-responsive" runat="server" />
                                <br />
                                <asp:HiddenField ID="HidImgUrlCT" runat="server" />
                                <label>Url Image:</label>
                                <asp:TextBox ID="txtImgUrlCT" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtImgUrlCT" ValidationGroup="vlidSelectImageCT" ErrorMessage="No Image Selected !" Display="None"></asp:RequiredFieldValidator>
                                <%-- end info --%>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Hủy</a>
                    <asp:Button ID="btnChangeCTImages" CssClass="btn btn-primary pull-right" ValidationGroup="vlidSelectImageCT" OnClick="btnChangeCTImages_Click" runat="server" Text="Save !" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Category Libray Images --%>

    <script type="text/javascript">
        function previewFile() {
            var preview = document.querySelector('#<%=ImgPostCategory.ClientID %>');
            var file = document.querySelector('#<%=fileUploadImgCategory.ClientID %>').files[0];
            var reader = new FileReader();
            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
        function previewFileUpdate() {
            var preview = document.querySelector('#<%=ImageUpdate.ClientID %>');
            var file = document.querySelector('#<%=FileUploadUpdateImg.ClientID %>').files[0];
            var reader = new FileReader();
            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
        function showanh(url) {
            var filename = url.substring(url.lastIndexOf('/') + 1);
            document.querySelector('#<%=ImagesSelect.ClientID %>').src = url;
            document.getElementById('<%=HiddenimgSelect.ClientID %>').value = url;
            document.getElementById('<%=txtImgUrl.ClientID %>').value = url;
            return false;
        }
        function callmodalCtImages() {
            document.getElementById("btnViewModalImages").click();
        }
        function showlbanh(url) {
            var filename = url.substring(url.lastIndexOf('/') + 1);
            document.querySelector('#<%=ImagesLBSelect.ClientID %>').src = url;
            document.getElementById('<%=HidImgUrlCT.ClientID %>').value = url;
            document.getElementById('<%=txtImgUrlCT.ClientID %>').value = url;
            return false;
        }
        function callmodalLBCtImages() {
            document.getElementById('<%=btnchangeLBImageCT.ClientID %>').click();
        }
    </script>
</asp:Content>

