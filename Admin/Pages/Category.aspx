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
                                    <a class="btn yellow" href="#modalselectimages" data-toggle="modal"><i class="fa fa-bank"></i>Chọn từ thư viện</a>
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
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="(.)+(.jpg|.gif|.png|.JPG|.PNG|.GIF)$"
                                                ControlToValidate="fileUploadImgCategory"
                                                ValidationGroup="fileUploadImgCategory"
                                                runat="server" ForeColor="Red"
                                                ErrorMessage="Please select a valid Images file !"
                                                Display="Dynamic" />
                                        </div>
                                        <label>You can upload JPG, GIF, or PNG file. Maximum file size is 4MB.</label>
                                        <%-- Tên Images Tạm --%>
                                        <asp:TextBox ID="txtImageTemp" runat="server"></asp:TextBox>
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
                                    <asp:CheckBox ID="chkShowOnHome" CssClass="display-none" Text="Show On Home" runat="server" />
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
                <asp:GridView ID="gwCategory" CssClass="table table-condensed table-responsive" runat="server"
                    AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                    OnSelectedIndexChanged="gwCategory_SelectedIndexChanged" OnRowDataBound="gwCategory_RowDataBound" OnRowDeleting="gwCategory_RowDeleting">
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
                                    CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
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
    <script type="text/javascript">
        function previewFile() {
            var preview = document.querySelector('#<%=ImgPostCategory.ClientID %>');
            var file = document.querySelector('#<%=fileUploadImgCategory.ClientID %>').files[0];
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
    </script>
</asp:Content>

