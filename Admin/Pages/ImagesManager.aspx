<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ImagesManager.aspx.cs" Inherits="Admin_Pages_ImagesManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
   <%-- <link href="../../App_Themes/admin/imgaesmanager.css" rel="stylesheet" />--%>
    <link href="../../App_Themes/admin/pagination.css" rel="stylesheet" />
    <style type="text/css">
        .page_disabled {
            background:#ff6a00;
        }
    </style>
    <!-- BEGIN PAGE HEADER-->
    <h3 class="page-title">Thư viện hình ảnh <small>Images Manager</small>
    </h3>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../../Admin/Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">Media Library</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../../Admin/Pages/ImagesManager.aspx">Images Manager</a>
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
    <a class="btn green" data-toggle="collapse" data-parent="#accordion2" href="#panelupload" id="btnNewImages" runat="server">Thêm hình ảnh</a>
    <hr />
    <div class="clearfix"></div>
    <div id="panelupload" class="col-lg-12 panel-collapse collapse">
        <div id="dZUpload" class="dropzone">
            <div class="dz-default dz-message">
                <img src="../../libs/DropzoneJs_scripts/spritemap@2x.png" style="width: 50%; height: 50%;" />
            </div>
        </div>
    </div>
    <div class="" id="ImageslibraryPanel" runat="server">
        <!-- BEGIN USERS TABLE PORTLET-->
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-edit"></i>Thư viện hình ảnh
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a>
                            <a href="#portlet-config" data-toggle="modal" class="config"></a>
                            <button id="btnreload" class="btn green" runat="server"><i class="icon-reload"></i></button>
                            <a href="javascript:;" class="remove"></a>
                        </div>
                    </div>
                    <div class="portlet-body background">
                        <div class="table-toolbar">
                            <div class="clearfix"></div>
                            <div class="grid-container">
                                <ul class="rig columns-5">
                                    <asp:Repeater ID="rpLstImg" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <a href='<%#"../../"+Eval("ImagesUrl") %>' onclick="return showthumbanh(this.href)">
                                                    <span href="#modalviewImages" data-toggle="modal">
                                                        <img src='<%#"../../"+Eval("ImagesUrl") %>' />
                                                        <h4>Upload by <i style="color: red;"><%# Eval("UserName") %></i></h4>
                                                        <p><i class="fa fa-clock-o"></i><%# Eval("DateOfStart") %></p>
                                                    </span>
                                                </a>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <!--/#five-columns-->
                        </div>

                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="form-group">
                    <!-- BEGIN PAGINATOR -->
                    <div class="row">
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
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                    <!-- END PAGINATOR -->
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- /.modal view Images -->
    <div class="modal fade" id="modalviewImages" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">View Images</h4>
                </div>
                <div class="modal-body">
                    <div class="panel-default">
                        <div class="panel-body">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-6">
                                <img src="#" id="imgThumgProduct" runat="server" style="width: 100%; height: auto;" />
                            </div>
                            <div class="col-lg-1"></div>
                            <div class="col-lg-4">
                                <div class="panel panel-default">
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <label class="control-label">Image Url</label>
                                            <asp:TextBox ID="txtImgurl" CssClass="form-control" runat="server"></asp:TextBox>
                                            <%--<input id="txtImgurl" class="form-control" type="text" runat="server" />--%>
                                            <%--<asp:Button ID="btncopylink" runat="server" onclick="btnCopyClicked" Text="Copy link" />--%>
                                            <a id="markup-copy"><i class="fa fa-copy"></i>Copy link</a>
                                        </div>
                                        <asp:HiddenField ID="HiddenImages" runat="server" />
                                        <a href="#" style="color: red;" id="btndelete" onserverclick="btndelete_ServerClick" runat="server"><i class="fa fa-remove">Delete Images</i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="../libs/Clipboard_jsmaster/clipboard.min.js"></script>
    <!-- /.end modal view Images -->
    <script type="text/javascript">
        function showthumbanh(url) {
            var filename = url.substring(url.lastIndexOf('/') + 1);
            document.querySelector('#<%=imgThumgProduct.ClientID %>').src = url;
            document.getElementById('<%=txtImgurl.ClientID %>').value = url;
            document.getElementById('<%=HiddenImages.ClientID %>').value = filename;
            return false;
        }
        <%-- Copy Link Images to ClipBoards --%>
        document.getElementById('markup-copy').addEventListener('click', function () {
            clipboard.copy({
                'text/plain': document.getElementById('<%=txtImgurl.ClientID %>').value,
                //'text/html': '<i>here</i> is some <b>rich text</b>'
            }).then(
            function () { console.log('success'); },
            function (err) {
                console.log('failure', err);
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            console.log("Hello");
            Dropzone.autoDiscover = true;
            //Simple Dropzonejs 
            $("#dZUpload").dropzone({
                url: "/Handler/hn_SimpeFileUploader.ashx",
                maxFiles: 10,
                addRemoveLinks: true,
                success: function (file, response) {
                    var imgName = response;
                    file.previewElement.classList.add("dz-success");
                    console.log("Successfully uploaded :" + imgName);
                },
                error: function (file, response) {
                    file.previewElement.classList.add("dz-error");
                }
            });
        });
    </script>
</asp:Content>

