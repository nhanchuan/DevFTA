<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="DemoInProject_Default" %>

<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">New Post
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
                <a href="../../Admin/Pages/Post-New.aspx">Viết bài mới</a>
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
    <%-- CONTENT POST --%>
    <div class="row">
        <div class="col-lg-9">
            <div class="row">
                <div class="col-lg-12">
                    <div class="tabbable-custom ">
                        <ul class="nav nav-tabs ">
                            <li class="active">
                                <a href="#tab_content_vi" data-toggle="tab">Content VN </a>
                            </li>
                            <li>
                                <a href="#tab_content_en" data-toggle="tab">Content EN </a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tab_content_vi">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="control-label"><strong>Tiêu đề bài viết</strong></label>
                                            <input id="txtPostTitle" type="text" class="form-control" placeholder="Nhập tiêu đề tại đây" runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtPostTitle" ValidationGroup="validNewPost" runat="server" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtPostTitle" ForeColor="Red" Display="Dynamic" ValidationGroup="validNewPost" ValidationExpression="(.){0,200}$" runat="server" ErrorMessage="Tên từ 0-200 ký tự !"></asp:RegularExpressionValidator>
                                        </div>
                                        <CKEditor:CKEditorControl ID="EditorPostContentVN" runat="server"
                                            Toolbar="Full"
                                            ContentsLangDirection="Ui"
                                            DialogButtonsOrder="OS"
                                            Height="800px"
                                            EnterMode="BR"
                                            ResizeDir="Both"
                                            ShiftEnterMode="P"
                                            StartupMode="Wysiwyg"
                                            Language="vi"
                                            ToolbarLocation="Top">
                                        </CKEditor:CKEditorControl>
                                        <CKFinder:FileBrowser ID="CKFilemanager" BasePath="/ckfinder/" Height="750" runat="server"></CKFinder:FileBrowser>

                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="tab_content_en">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="control-label"><strong>Post title</strong></label>
                                            <input id="Text1" type="text" class="form-control" placeholder="Enter Post title here " runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPostTitle" ValidationGroup="validNewPost" runat="server" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtPostTitle" ForeColor="Red" Display="Dynamic" ValidationGroup="validNewPost" ValidationExpression="(.){0,200}$" runat="server" ErrorMessage="Tên từ 0-200 ký tự !"></asp:RegularExpressionValidator>
                                        </div>
                                        <CKEditor:CKEditorControl ID="EditorPostContentEN" runat="server"
                                            Toolbar="Full"
                                            ContentsLangDirection="Ui"
                                            DialogButtonsOrder="OS"
                                            Height="800px"
                                            EnterMode="BR"
                                            ResizeDir="Both"
                                            ShiftEnterMode="P"
                                            StartupMode="Wysiwyg"
                                            Language="en"
                                            ToolbarLocation="Top">
                                        </CKEditor:CKEditorControl>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <%-- Info Post --%>
        <div class="col-lg-3">

            <div class="panel-group accordion" id="accordion3">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a class="accordion-toggle accordion-toggle-styled" data-toggle="collapse" href="#collapse_3_1"><i class="fa fa-calendar"></i>&nbsp Đăng bài viết</a>
                        </h4>
                    </div>
                    <div id="collapse_3_1" class="panel-collapse collapse in">
                        <div class="panel-body">
                            <div class="inline">
                                <asp:Button ID="Button1" CssClass="btn btn-default pull-left" runat="server" Text="Lưu nháp" />
                                <asp:Button ID="Button2" CssClass="btn btn-default pull-right" runat="server" Text="Xem thử" />
                            </div>
                            <div class="clearfix"></div>
                            <br />
                            <div class="form-group">
                                <i class="fa fa-key"></i>
                                <label>Trạng thái:</label>&nbsp<strong><asp:Label ID="lblpost_status" runat="server" Text="Bản nháp"></asp:Label></strong><a href="#poststatus" data-toggle="collapse"> Chỉnh sửa</a>
                                <%--  --%>
                                <div id="poststatus" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <div class="input-icon">
                                                    <i class="fa fa-twitch"></i>
                                                    <asp:DropDownList ID="dlpost_status" CssClass="form-control" runat="server">
                                                        <asp:ListItem Value="0">Bản nháp</asp:ListItem>
                                                        <asp:ListItem Value="1">Chờ xét duyệt</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="input-group-btn">
                                                    <button id="btnChangepost_status" class="btn btn-success" type="button" runat="server"><i class="fa fa-arrow-left fa-fw"></i>OK</button>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%--  --%>
                            </div>

                        </div>
                        <div class="panel-footer">
                            <div class="panel-body">
                                <div class="inline">
                                    <asp:Button ID="btnPostNew" CssClass="btn btn-primary pull-right" ValidationGroup="validNewPost" runat="server" Text="Đăng bài viết" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" href="#collapse_3_2"><i class="fa fa-reorder"></i>&nbsp Chuyên mục </a>
                        </h4>
                    </div>
                    <div id="collapse_3_2" class="panel-collapse collapse">
                        <div class="panel-body" style="height: 500px; overflow-y: auto;">
                            <div class="form-control height-auto">
                                <div class="scroller" style="height: 420px; overflow-x: scroll;" data-always-visible="1">
                                    <%--<asp:CheckBoxList ID="chkblCategory" runat="server">
                                        </asp:CheckBoxList>--%>
                                    <asp:TreeView ID="treeboxCategory" runat="server" ShowExpandCollapse="true" PopulateNodesFromClient="true" ShowLines="true" ExpandDepth="2" ShowCheckBoxes="All"></asp:TreeView>
                                </div>
                            </div>
                            <a href="#newcategory" data-toggle="modal"><i class="fa fa-list"></i>Thêm nhanh chuyên mục</a>
                        </div>
                    </div>
                </div>
                <%-- Meta tags --%>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a class="accordion-toggle accordion-toggle-styled" data-toggle="collapse" href="#collapse_meta_tags"><i class="fa fa-bookmark"></i>&nbsp Meta Tags</a>
                        </h4>
                    </div>
                    <div id="collapse_meta_tags" class="panel-collapse collapse">
                        <div class="panel-body">
                            <div class="form-group">
                                <label class="control-label">Meta Tilte</label>
                                <asp:TextBox ID="txtMetaTitle" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Meta Keywords</label>
                                <asp:TextBox ID="txtMetaKeywords" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Meta Description</label>
                                <asp:TextBox ID="txtMetaDescription" TextMode="MultiLine" Rows="3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- End Meta tags --%>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" href="#collapse_3_3" id="tagsshowPanel" runat="server"><i class="fa fa-tags"></i>&nbsp Thẻ </a>
                        </h4>
                    </div>
                    <div id="collapse_3_3" class="panel-collapse collapse">
                        <div class="panel-body">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="inline">
                                        <div class="input-icon">
                                            <i class="fa fa-tag"></i>
                                            <asp:TextBox ID="txttagsname" CssClass="form-control" onkeyup="document.getElementById('lblmultiTags').innerHTML = this.value" AutoPostBack="true" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <i>Phân cách với nhau bằng dấu (,)</i><br />
                                    <br />
                                    <%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%>
                                    <div id="lblmultiTags" class="label label-warning"></div>
                                    <asp:Label ID="lbltagsExsit" CssClass="label label-danger" runat="server"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="label label-danger" ControlToValidate="txttagsname" ValidationGroup="validTags" runat="server" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                    <%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="txttagsname" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <br />
                            <asp:Button ID="btnAddTags" CssClass="btn btn-success pull-right" ValidationGroup="validTags" runat="server" Text="Thêm Tags" />
                            <br />
                            <br />
                            <a>Chọn từ những thẻ được dùng nhiều nhất</a>
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <%-- CheckBoxList tags --%>
                                    <div class="scroller" style="height: 350px; overflow-x: scroll;" data-always-visible="1">
                                        <asp:CheckBoxList ID="cbltags" runat="server"></asp:CheckBoxList>
                                    </div>
                                    <%-- End CheckBoxList tags --%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" href="#collapse_3_4" id="panelUploadImg" runat="server"><i class="fa fa-picture-o"></i>&nbsp Ảnh chức năng bài viết </a>
                        </h4>
                    </div>
                    <div id="collapse_3_4" class="panel-collapse collapse">
                        <div class="panel-body">
                            <asp:TextBox ID="txtPostImgTemp" CssClass="form-control display-none" runat="server"></asp:TextBox>
                            <div class="col-lg-2"></div>
                            <div class="col-lg-8">
                                <img id="imgpost" src="../images/default_images.jpg" class="img-responsive" runat="server" />
                            </div>
                            <div class="col-lg-2"></div>
                            <div class="clearfix"></div>
                            <br />
                            <div class="col-lg-12">
                                <div class="row">
                                    <a class="btn red" id="clearEditImg" runat="server"><i class="fa fa-refresh">Clear</i></a>
                                    <a class="btn green" href="#coluploadEditImges" data-toggle="collapse"><i class="fa fa-upload"></i>Tải lên</a>
                                    <a class="btn yellow" href="#modalPostImages" data-toggle="modal"><i class="fa fa-bank"></i>Chọn từ thư viện</a>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <br />
                            <%-- Collapse Upload Images --%>
                            <div id="coluploadEditImges" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <div class="input-icon">
                                                <i class="fa fa-file"></i>
                                                <asp:FileUpload ID="fileUploadImgPost" CssClass="form-control" runat="server" />
                                            </div>
                                            <span class="input-group-btn">
                                                <button id="btnuploadImg" class="btn btn-success" type="button" validationgroup="validfileUploadImgPost" runat="server"><i class="fa fa-arrow-left fa-fw"></i>OK</button>
                                            </span>
                                        </div>
                                        <asp:RequiredFieldValidator ErrorMessage="Required"
                                            ControlToValidate="fileUploadImgPost" ValidationGroup="validfileUploadImgPost"
                                            runat="server" Display="Dynamic" ForeColor="Red" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpg|.gif|.png)$"
                                            ControlToValidate="fileUploadImgPost"
                                            ValidationGroup="validfileUploadImgPost"
                                            runat="server" ForeColor="Red"
                                            ErrorMessage="Please select a valid Images file !"
                                            Display="Dynamic" />
                                    </div>
                                    <label>You can upload JPG, GIF, or PNG file. Maximum file size is 4MB.</label>
                                </div>
                            </div>
                            <%-- End Collapse Upload Images --%>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <%-- End Info Post --%>
    </div>

    <%-- END CONTENT POST --%>

    <script src="../../ckeditor/ckeditor.js"></script>

    <script src="../../ckfinder/ckfinder.js"></script>
    <script type="text/javascript">
        var editor = CKEDITOR.replace('cke_ContentPlaceHolder1_EditorPostContentVN');
        CKFinder.setupCKEditor(editor, '/ckfinder/');
    </script>
</asp:Content>

