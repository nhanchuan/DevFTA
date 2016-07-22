<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="SubSlider.aspx.cs" Inherits="Admin_Pages_SubSlider" %>

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
    <h1 class="page-title">Setting SubSlider
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../../Admin/Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">Setting</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../../Admin/Pages/SubSlider.aspx">SubSlider</a>
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
        <div class="col-lg-4">
            <div class="form-group">
                <label>Title</label>
                <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Description</label>
                <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Redirect Link</label>
                <asp:TextBox ID="txtRedirectLink" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Upload File</label>
                <p>
                    You can upload JPG, GIF, or PNG file. Maximum file size is 4MB.
                </p>
                <asp:FileUpload ID="FileImgUpload" CssClass="form-control margin-bottom-25" onchange="previewFile()" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="No File chosen !"
                    ControlToValidate="FileImgUpload" ValidationGroup="validFileImgUpload"
                    runat="server" Display="Dynamic" ForeColor="Red" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.JPG|.JPEG|.GIF|.PNG)$"
                    ControlToValidate="FileImgUpload"
                    ValidationGroup="validFileImgUpload"
                    runat="server" ForeColor="Red"
                    ErrorMessage="Please select a valid Images file !"
                    Display="Dynamic" />
                <div class="clearfix"></div>
                <div class="col-lg-2"></div>
                <div class="col-lg-8">
                    <asp:Image ID="imgUpload" CssClass="img-responsive" runat="server" />
                </div>
                <div class="col-lg-2"></div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <asp:CheckBox ID="chkShow" Text="Show" runat="server" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnNewSubSlider" CssClass="btn green pull-right" ValidationGroup="validFileImgUpload" OnClick="btnNewSubSlider_Click" runat="server" Text="Add New" />
            </div>
        </div>
        <div class="col-lg-8">
            <div class="row">
                <div class="col-lg-12 margin-bottom-30">
                    <div class="row margin-bottom-20">
                        <div class="col-lg-12">
                            <a id="btnfixSubSlider" href="#modalEditSubSlider" data-toggle="modal" runat="server"><i class="fa fa-cog"></i>&nbsp Edit Sub Slider</a>
                            <a id="btnselectImg"  href="#modalSelectImg" data-toggle="modal" runat="server"><i class="fa fa-image"></i>&nbsp From Library</a>
                        </div>
                    </div>
                    <asp:GridView ID="gwSubSlider" CssClass="table table-condensed table-responsive" runat="server" AutoGenerateColumns="False"
                        OnSelectedIndexChanged="gwSubSlider_SelectedIndexChanged" OnRowDataBound="gwSubSlider_RowDataBound" OnRowDeleting="gwSubSlider_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText=".No">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label>
                                    <asp:Label ID="lblID" CssClass="display-none" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <label class="bold"><i class="fa fa-key"></i>Title :</label>
                                    <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label><br />
                                    <label class="bold"><i class="fa fa-list"></i>Descriptions :</label>
                                    <asp:Label ID="lblDescriptions" runat="server" Text='<%# Bind("Descriptions") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <img src='<%# "../../" + Eval("ImagesUrl") %>' style="width: 70px; height: auto;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkBtnDel" CssClass="btn btn-circle btn-icon-only btn-default" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" Text="Delete"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Show">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkShow" Checked='<%# Eval("SliderStatus") %>' OnCheckedChanged="chkShow_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <asp:HiddenField ID="hiddenField1" Value='<%# Eval("ID").ToString() %>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="40px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbtnUp" CommandArgument='<%# Eval("ID") %>' OnClick="lkbtnUp_Click" runat="server"><i class="fa fa-caret-square-o-up" style="font-size:20px;"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbtnDown" CommandArgument='<%# Eval("ID") %>' OnClick="lkbtnDown_Click" runat="server"><i class="fa fa-caret-square-o-down" style="font-size:20px;"></i></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="55px" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                        <HeaderStyle BackColor="#FFB848" ForeColor="White"></HeaderStyle>
                        <RowStyle BackColor="#FAF3DF"></RowStyle>
                    </asp:GridView>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <!-- BEGIN PAGINATOR -->
                                <div class="pagination_lst pull-right">
                                    <asp:Repeater ID="rptPager" runat="server">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "btn btn-default page_enabled" : "btn btn-default page_disabled" %>'
                                                OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- Modal Edit SubSlider --%>
    <div class="modal fade" id="modalEditSubSlider" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Fix Popup    
                    </h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-8">
                            <div class="form-group">
                                <label>Title</label>
                                <asp:TextBox ID="txtETitle" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Description</label>
                                <asp:TextBox ID="txtEDescription" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Redirect Link</label>
                                <asp:TextBox ID="txtERedirectLink" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Upload File</label>
                                <p>
                                    You can upload JPG, GIF, or PNG file. Maximum file size is 4MB.
                                </p>
                                <asp:FileUpload ID="UploadEditImage" CssClass="form-control margin-bottom-25" onchange="previewEditFile()" runat="server" />
                                <asp:RequiredFieldValidator ErrorMessage="No File chosen !"
                                    ControlToValidate="UploadEditImage" ValidationGroup="validEditImgUpload"
                                    runat="server" Display="Dynamic" ForeColor="Red" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.JPG|.JPEG|.GIF|.PNG)$"
                                    ControlToValidate="UploadEditImage"
                                    ValidationGroup="validEditImgUpload"
                                    runat="server" ForeColor="Red"
                                    ErrorMessage="Please select a valid Images file !"
                                    Display="Dynamic" />
                                <div class="clearfix"></div>
                                <div class="col-lg-2"></div>
                                <div class="col-lg-8">
                                    <asp:Image ID="ImgEditImages" CssClass="img-responsive" runat="server" />
                                </div>
                                <div class="col-lg-2"></div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group">
                                <asp:CheckBox ID="chkEditStatus" Text="Show" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal" aria-hidden="true">Cancel</a>
                    <asp:Button ID="btnSevaEdit" CssClass="btn btn-primary" OnClick="btnSevaEdit_Click" runat="server" Text="Update" />
                </div>
            </div>
        </div>
    </div>
    <%--End Modal Edit SubSlider --%>

    <%-- Modal Sub Slider Change Images --%>
    <div class="modal" id="modalSelectImg" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
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
    <%-- End Modal Sub Slider  Libray Images --%>


    <script type="text/javascript">
        function previewFile() {
            var preview = document.querySelector('#<%=imgUpload.ClientID %>');
            var file = document.querySelector('#<%=FileImgUpload.ClientID %>').files[0];
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
        function previewEditFile() {
            var preview = document.querySelector('#<%=ImgEditImages.ClientID %>');
            var file = document.querySelector('#<%=UploadEditImage.ClientID %>').files[0];
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
        function showlbanh(url) {
            var filename = url.substring(url.lastIndexOf('/') + 1);
            document.querySelector('#<%=ImagesLBSelect.ClientID %>').src = url;
            document.getElementById('<%=HidImgUrlCT.ClientID %>').value = url;
            document.getElementById('<%=txtImgUrlCT.ClientID %>').value = url;
            return false;
        }
        function callmodalLBCtImages() {
            document.getElementById('<%=btnselectImg.ClientID %>').click();
        }
    </script>
</asp:Content>

