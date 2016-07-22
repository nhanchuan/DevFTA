<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="NguoiTieuDung.aspx.cs" Inherits="DemoInProject_NguoiTieuDung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/frontend/btnAppStore.css" rel="stylesheet" />
    <div class="main">
        <div class="container">
            <div class="row">
                <h3 class="margin-bottom-15">NGƯỜI TIÊU DÙNG</h3>
                <div class="col-lg-12">
                    <div class="col-lg-5">
                        <h3>United On The Go</h3>
                        <p>Their newest device is the Blu Life Pure mini, a 4.5” smartphone with a 1280 x 720 IPS display.</p>
                        <a href="#" class="btn btn-app-store"><i class="fa fa-apple"></i> <span class="small">Download on the</span> <span class="big">App Store</span></a>
                      <a href="#" class="btn btn-app-store"><img width="60" class="pull-left" src="http://www.userlogos.org/files/logos/jumpordie/google_play_04.png" /> <span class="small">Download on the</span> <span class="big">Google play</span></a>
                           
                    </div>
                    <div class="col-lg-4">
                        <img src="../images/content/nguoitieudung/iphone-hand-mockup-drop-1000x640.png" style="width: 100%; height: auto;" />
                    </div>
                    <div class="col-lg-3">
                        <img src="../images/content/nguoitieudung/checkQ-Code.png" style="width:100%; height:auto;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

