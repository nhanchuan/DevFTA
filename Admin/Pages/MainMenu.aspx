﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="MainMenu.aspx.cs" Inherits="Admin_Pages_MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                <a href="#">Setting</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../../Admin/Pages/MainMenu.aspx">Main menu</a>
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
        <div class="col-lg-5">
            <h2>Thêm Mục vào Menu Chính</h2>
            <div class="form-group">
                <label class="control-label">Tên Menu : </label>
                <asp:TextBox ID="txtItemname" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtItemname" ValidationGroup="validNewMenu" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Tên menu không được để trống !"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label class="control-label">Đường dẫn tĩnh : </label>
                <asp:TextBox ID="txtPermalink" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-control">
                <asp:CheckBox ID="chkStatus" Text="Show" runat="server" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnAddMenuItem" CssClass="btn btn-primary" ValidationGroup="validNewMenu" OnClick="btnAddMenuItem_Click" runat="server" Text="Thêm Mục" />
            </div>
        </div>
        <div class="col-lg-7">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label>Tên Menu</label>
                                        <asp:TextBox ID="txtEditItemname" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEditItemname" ValidationGroup="validEditMenu" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Tên menu không được để trống !"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="control-label">Permalink</label>
                                        <asp:TextBox ID="txtEPermalink" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <asp:CheckBox ID="chkEStatus" Text="Show" runat="server" />
                                </div>
                                <div class="col-lg-2">
                                    <br />
                                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="validEditMenu" Enabled="false" OnClick="btnSubmit_Click" runat="server" Text="Submit" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="clearfix"></div>
                    <asp:GridView ID="gwMenuItems" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                        OnRowDataBound="gwMenuItems_RowDataBound"
                        OnRowDeleting="gwMenuItems_RowDeleting"
                        OnSelectedIndexChanged="gwMenuItems_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="DB_ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblMenuID" runat="server" Text='<%# Eval("MenuID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Menu Item">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Đường dẫn tĩnh">
                                <ItemTemplate>
                                    <asp:Label ID="lblPermalink" runat="server" Text='<%# Eval("Permalink") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbtnUp" CommandArgument='<%# Eval("MenuID") %>' OnClick="lkbtnUp_Click" runat="server"><i class="fa fa-caret-square-o-up" style="font-size:20px;"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbtnDown" CommandArgument='<%# Eval("MenuID") %>' OnClick="lkbtnDown_Click" runat="server"><i class="fa fa-caret-square-o-down" style="font-size:20px;"></i></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Show">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkShow" Checked='<%# Eval("MenuStatus") %>' AutoPostBack="true" OnCheckedChanged="chkShow_CheckedChanged" runat="server" />
                                    <asp:HiddenField ID="hiddenField1" Value='<%# Eval("MenuID").ToString() %>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="40px" />
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

                    <div class="form-group">
                        <h3><i class="fa fa-cubes"></i>Sub Mennu Setting</h3>
                    </div>
                    <div class="form-group">
                        <div class="input-group">
                            <div class="input-icon">
                                <i class="fa fa-search"></i>
                                <asp:DropDownList ID="dlSelectCategory" placeholder="Thêm Category" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <span class="input-group-btn">
                                <asp:Button ID="btnInsertItemtoMenu" CssClass="btn btn-success" ValidationGroup="validChoseCategory" OnClick="btnInsertItemtoMenu_Click" runat="server" Text="Thêm vào Menu =>" />
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="dlSelectCategory"
                            ValidationGroup="validChoseCategory"
                            Display="Dynamic"
                            ForeColor="Red"
                            ErrorMessage="Chưa chọn danh mục !"
                            InitialValue="0">
                        </asp:RequiredFieldValidator>
                        <i>
                            <asp:Label ID="lblAddSubItemWaring" ForeColor="Red" runat="server"></asp:Label></i>
                    </div>
                    <div class="form-group">
                        <div class="input-group">
                            <div class="input-icon">
                                <i class="fa fa-search"></i>
                                <asp:DropDownList ID="dlPosts" CssClass="form-control" placeholder="Thêm bài viết" runat="server"></asp:DropDownList>
                            </div>
                            <span class="input-group-btn">
                                <asp:Button ID="btnAddPost" CssClass="btn btn-success" ValidationGroup="validChosePosts" OnClick="btnAddPost_Click" runat="server" Text="Thêm Bài Viết =>" />
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ControlToValidate="dlPosts"
                            ValidationGroup="validChosePosts"
                            Display="Dynamic"
                            ForeColor="Red"
                            ErrorMessage="Chưa chọn bài viết !"
                            InitialValue="0">
                        </asp:RequiredFieldValidator>
                        <i>
                            <asp:Label ID="lblWarningAddPost" ForeColor="Red" runat="server"></asp:Label></i>
                    </div>
                    <div class="row">
                        <div class="form-group margin-bottom-20">
                            <label class="control-label col-md-12">Thêm Mục Khác</label>
                            <div class="col-lg-5">
                                <asp:TextBox ID="txtOrtherItem" CssClass="form-control" placeholder="Tên chuyên mục" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtOrtherItem" ValidationGroup="validOrtherItem" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Nhập tên chuyên mục !"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-lg-5">
                                <asp:TextBox ID="txtOrtherItemParmalink" CssClass="form-control" placeholder="Permalink" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <asp:Button ID="btnAddOrtherItem" ValidationGroup="validOrtherItem" OnClick="btnAddOrtherItem_Click" CssClass="btn btn-success" runat="server" Text="Thêm =>" />
                            </div>
                        </div>
                        <i>
                            <asp:Label ID="lblWarningOrtherItem" ForeColor="Red" runat="server"></asp:Label></i>
                    </div>

                    <asp:GridView ID="gwSubMenuItem" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnRowDataBound="gwSubMenuItem_RowDataBound" OnRowDeleting="gwSubMenuItem_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="CMenuID">
                                <ItemTemplate>
                                    <asp:Label ID="lblmenuID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub Menu">
                                <ItemTemplate>
                                    <asp:Label ID="lblNameVN" runat="server" 
                                        Text='<%# (!string.IsNullOrEmpty(Eval("CategoryID").ToString())) ? Eval("NameVN"): (!string.IsNullOrEmpty(Eval("PostID").ToString()))? Eval("MetaTitle"): Eval("OrtherItem")  %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Thuộc Menu">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblPermalink" runat="server" Text='<%# Eval("Permalink") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbtnSubUp" CommandArgument='<%# Eval("ID") %>' OnClick="lkbtnSubUp_Click" runat="server"><i class="fa fa-caret-square-o-up" style="font-size:20px;"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbtnSubDown" CommandArgument='<%# Eval("ID") %>' OnClick="lkbtnSubDown_Click" runat="server"><i class="fa fa-caret-square-o-down" style="font-size:20px;"></i></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkBtnDelSubItem" CssClass="btn btn-circle btn-icon-only btn-default" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" Text="Delete"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
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
                        <HeaderStyle BackColor="#0099ff" ForeColor="White"></HeaderStyle>
                        <RowStyle BackColor="#FAF3DF"></RowStyle>
                    </asp:GridView>

                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="gwMenuItems" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

