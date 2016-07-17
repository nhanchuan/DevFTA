<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Post-New.aspx.cs" Inherits="Admin_Pages_Post_New" %>

<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../assets/global/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <link href="../../App_Themes/admin/pagination.css" rel="stylesheet" />
    <style type="text/css">
        .page_disabled {
            background: #ff6a00;
        }
    </style>
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
                                                        <asp:ListItem Value="0">-- Chờ xét duyệt --</asp:ListItem>
                                                        <asp:ListItem Value="1">-- Đăng bài --</asp:ListItem>
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

                            <div class="form-group">
                                <i class="fa fa-calendar-o"></i>
                                <label>Đăng: </label>
                                &nbsp<strong><asp:Label ID="lblTimePost" runat="server" Text="Ngay lập tức"></asp:Label></strong><a href="#DatetimePost" data-toggle="collapse" id="TimepostClick" runat="server"> Chỉnh sửa</a>
                                <%-- Datetime picker --%>
                                <div id="DatetimePost" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="timePost" ValidationGroup="validtimepost" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                        <div class="form-group">
                                            <div class="input-group date form_meridian_datetime input-large">
                                                <input type="text" size="16" class="form-control" id="timePost" runat="server" />
                                                <span class="input-group-btn">
                                                    <button class="btn default date-reset" type="button"><i class="fa fa-times"></i></button>
                                                </span>
                                                <span class="input-group-btn">
                                                    <button class="btn default date-set" type="button"><i class="fa fa-calendar"></i></button>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- End Datetime picker --%>
                            </div>
                            <div class="form-group">
                                <asp:CheckBox ID="chkTopHot" Text="Top Hot" runat="server" />
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="panel-body">
                                <div class="inline">
                                    <asp:Button ID="btnPostNew" CssClass="btn btn-primary pull-right" ValidationGroup="validNewPost" OnClick="btnPostNew_Click" runat="server" Text="Đăng bài viết" />
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
                                    <asp:TreeView ID="treeboxCategory" OnTreeNodePopulate="treeboxCategory_TreeNodePopulate" runat="server" ShowExpandCollapse="true" PopulateNodesFromClient="true" ShowLines="true" ExpandDepth="2" ShowCheckBoxes="All"></asp:TreeView>
                                </div>
                            </div>
                            <a href="../../Admin/Pages/Category.aspx" target="_blank"><i class="fa fa-list"></i>&nbsp Thêm chuyên mục</a>
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
                            
                                    <div class="inline">
                                        <div class="input-icon">
                                            <i class="fa fa-tag"></i>
                                            <asp:TextBox ID="txttagsname" CssClass="form-control" onkeyup="document.getElementById('lblmultiTags').innerHTML = this.value" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <i>Phân cách với nhau bằng dấu (,)</i><br />
                                    <br />
                                    <%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%>
                                    <div id="lblmultiTags" class="label label-warning"></div>
                                    <asp:Label ID="lbltagsExsit" CssClass="label label-danger" runat="server"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="label label-danger" ControlToValidate="txttagsname" ValidationGroup="validTags" runat="server" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                    <%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%>
                               
                            <br />
                            <asp:Button ID="btnAddTags" CssClass="btn btn-success pull-right" OnClick="btnAddTags_Click" ValidationGroup="validTags" runat="server" Text="Thêm Tags" />
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
                            <asp:TextBox ID="txtPostImgTemp" CssClass="form-control display-none" runat="server"></asp:TextBox><%-- Images Name Temp --%>
                            <div class="col-lg-2"></div>
                            <div class="col-lg-8">
                                <img id="imgpost" src="../../images/noimage.jpg" class="img-responsive" runat="server" />
                            </div>
                            <div class="col-lg-2"></div>
                            <div class="clearfix"></div>
                            <br />
                            <div class="col-lg-12">
                                <div class="row">
                                    <a class="btn red" id="clearEditImg" runat="server"><i class="fa fa-refresh">Clear</i></a>
                                    <a class="btn green" href="#coluploadEditImges" data-toggle="collapse"><i class="fa fa-upload"></i>Tải lên</a>
                                    <a id="btnViewModalImages" class="btn yellow" href="#modalPostImages" data-toggle="modal"><i class="fa fa-bank"></i>Chọn từ thư viện</a>
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
                                                <asp:FileUpload ID="fileUploadImgPost" onchange="previewFile()" CssClass="form-control" runat="server" />
                                            </div>
                                            <span class="input-group-btn">
                                                <asp:Button ID="btnuploadImg" CssClass="btn btn-success" OnClick="btnuploadImg_Click" ValidationGroup="validfileUploadImgPost" runat="server" Text="<=OK" />
                                            </span>
                                        </div>
                                        <asp:RequiredFieldValidator ErrorMessage="Required"
                                            ControlToValidate="fileUploadImgPost" ValidationGroup="validfileUploadImgPost"
                                            runat="server" Display="Dynamic" ForeColor="Red" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpg|.gif|.png|.JPG|.PNG|.GIF)$"
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
                                            <input id="txtPostTitleVN" type="text" class="form-control" placeholder="Nhập tiêu đề tại đây" runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtPostTitleVN" ValidationGroup="validNewPost" runat="server" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtPostTitleVN" ForeColor="Red" Display="Dynamic" ValidationGroup="validNewPost" ValidationExpression="(.){0,200}$" runat="server" ErrorMessage="Tên từ 0-200 ký tự !"></asp:RegularExpressionValidator>
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

                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="tab_content_en">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="control-label"><strong>Post title</strong></label>
                                            <input id="txtPostTitleEN" type="text" class="form-control" placeholder="Enter Post title here " runat="server" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtPostTitleEN" ForeColor="Red" Display="Dynamic" ValidationGroup="validNewPost" ValidationExpression="(.){0,200}$" runat="server" ErrorMessage="Tên từ 0-200 ký tự !"></asp:RegularExpressionValidator>
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
        
    </div>

    <%-- Modal Post Images --%>
    <div class="modal" id="modalPostImages" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
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
                                                    <asp:Repeater ID="rptPager" runat="server">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "btn btn-default page_enabled" : "btn btn-default page_disabled" %>'
                                                                OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
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
                    <asp:Button ID="btnchangeImgPost" CssClass="btn btn-primary pull-right" OnClick="btnchangeImgPost_Click" ValidationGroup="vlidSelectImage" runat="server" Text="Save !" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Post Images --%>

    <%-- END CONTENT POST --%>
    <script src="../../assets/global/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <script src="../ckeditor/ckeditor.js"></script>
    <script src="../ckfinder/ckfinder.js"></script>
    <script type="text/javascript">
        function previewFile() {
            var preview = document.querySelector('#<%=imgpost.ClientID %>');
            var file = document.querySelector('#<%=fileUploadImgPost.ClientID %>').files[0];
            var reader = new FileReader();
            <%--document.getElementById('<%=HiddenUploadimg.ClientID %>').value = "";
            document.getElementById('<%=txtTenAnh.ClientID %>').value = "Image tag name";--%>
            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
        $(document).ready(function () {
            $("#ContentPlaceHolder1_clearEditImg").click(function () {
                var urlNoimg = "../../images/noimage.jpg";
                $("#ContentPlaceHolder1_imgpost").attr("src", urlNoimg);
                $("#ContentPlaceHolder1_txtPostImgTemp").val("");
            });
        });
        function calltagspanelClickEvent() {
            document.getElementById('<%=tagsshowPanel.ClientID %>').click();
        }
        function callImagesPanelClickEvent() {
            document.getElementById('<%=panelUploadImg.ClientID %>').click();
        }
        function calldropdownTimepostClickEvent() {
            document.getElementById('<%=TimepostClick.ClientID %>').click();
        }
        function showanh(url) {
            var filename = url.substring(url.lastIndexOf('/') + 1);
            document.querySelector('#<%=ImagesSelect.ClientID %>').src = url;
            document.getElementById('<%=HiddenimgSelect.ClientID %>').value = url;
            document.getElementById('<%=txtImgUrl.ClientID %>').value = url;
            return false;
        }
        function callmodalPostImages() {
            document.getElementById("btnViewModalImages").click();
        }
    </script>

</asp:Content>

