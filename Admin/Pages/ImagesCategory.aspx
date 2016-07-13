<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ImagesCategory.aspx.cs" Inherits="Admin_Pages_ImagesCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Chuyên mục hình ảnh
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../../Admin/Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../../Admin/Pages/ImagesCategory.aspx">Chuyên mục hình ảnh</a>
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
            <h3>Thêm Chuyên Mục Hình Ảnh</h3>
            <br />
            <div class="form-group">
                <label class="control-label">Chuyên mục hình ảnh</label>
                <asp:TextBox ID="txtImgCategory" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtImgCategory" ValidationGroup="validImgCategory" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Tên chuyên mục không được để trống !"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Button ID="btnAddImgCategory" CssClass="btn btn-primary" ValidationGroup="validImgCategory" OnClick="btnAddImgCategory_Click" runat="server" Text="Thêm Danh Mục" />
            </div>
        </div>
        <div class="col-lg-8">
            <div class="row margin-bottom-25">
                <div class="col-lg-12">
                    <a id="btnfixImagesCT" href="#modalEditIamgeCategory" data-toggle="modal" runat="server"><i class="fa fa-cog"></i>&nbsp Chỉnh sửa danh mục</a>
                    <asp:Label ID="lblConfirm" runat="server"></asp:Label>
                </div>
            </div>

            <asp:GridView ID="gwImagesCategory" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                OnRowDataBound="gwImagesCategory_RowDataBound" OnRowDeleting="gwImagesCategory_RowDeleting" OnSelectedIndexChanged="gwImagesCategory_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="DB_ID">
                        <ItemTemplate>
                            <asp:Label ID="lblImagesTypeID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Chuyên mục hình ảnh">
                        <ItemTemplate>
                            <asp:Label ID="lblImagesTypeName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số Hình Ảnh">
                        <ItemTemplate>
                            <asp:Label ID="lblNunImages" runat="server" Text='<%# Eval("NumImages") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkBtnDel" CssClass="btn btn-circle btn-icon-only btn-default" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" Text="Delete"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
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
        </div>
    </div>
    <%-- Modal Edit Images Catefory --%>
    <div id="modalEditIamgeCategory" class="modal fade modal-scroll" tabindex="-1" data-replace="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <i class="fa fa-cog"></i>Edit Images Category
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label class="control-label">Chuyên mục hình ảnh</label>
                        <asp:TextBox ID="txtEditImagesCategory" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtEditImagesCategory" ValidationGroup="validEImgCategory" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Tên danh mục không được để trống !"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Cancel</a>
                    <asp:Button ID="btnsave" CssClass="btn btn-primary" ValidationGroup="validEImgCategory" OnClick="btnsave_Click" runat="server" Text="Save" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal --%>
</asp:Content>

