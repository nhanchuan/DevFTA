<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="PostItem.aspx.cs" Inherits="Pages_PostItem" %>

<%@ Register Src="~/Controls/PostSidebar.ascx" TagPrefix="uc1" TagName="PostSidebar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="container">
            <ul class="breadcrumb">
                <li><a href="index.html">Home</a></li>
                <li><a href="#">Tin tức & Sự kiện</a></li>
            </ul>
            <!-- BEGIN SIDEBAR & CONTENT -->
            <div class="row margin-bottom-40">
                <!-- BEGIN CONTENT -->
                <div class="col-md-12 col-sm-12">
                    <%--<h1>Blog Item</h1>--%>
                    <div class="content-page">
                        <div class="row">
                            <!-- BEGIN LEFT SIDEBAR -->
                            <div class="col-md-9 col-sm-9 blog-item">
                                <%--<div class="blog-item-img">
                                    <!-- BEGIN CAROUSEL -->
                                    <div class="front-carousel">
                                        <div id="myCarousel" class="carousel slide">
                                            <!-- Carousel items -->
                                            <div class="carousel-inner">
                                                <div class="item">
                                                    <img src="../assets/frontend/pages/img/posts/img1.jpg" alt="" />
                                                </div>
                                                <div class="item">
                                                    <!-- BEGIN VIDEO -->
                                                    <iframe src="http://player.vimeo.com/video/56974716?portrait=0" style="width: 100%; border: 0" allowfullscreen="" height="259"></iframe>
                                                    <!-- END VIDEO -->
                                                </div>
                                                <div class="item active">
                                                    <img src="../assets/frontend/pages/img/posts/img3.jpg" alt="" />
                                                </div>
                                            </div>
                                            <!-- Carousel nav -->
                                            <a class="carousel-control left" href="#myCarousel" data-slide="prev">
                                                <i class="fa fa-angle-left"></i>
                                            </a>
                                            <a class="carousel-control right" href="#myCarousel" data-slide="next">
                                                <i class="fa fa-angle-right"></i>
                                            </a>
                                        </div>
                                    </div>
                                    <!-- END CAROUSEL -->
                                </div>--%>
                                <h2><a href="#"><asp:Label ID="lblPostTitle" runat="server" Text="Label"></asp:Label></a></h2>
                                <p>
                                    <asp:Label ID="lblcontent" runat="server" Text="Label"></asp:Label></p>
                                <ul class="blog-info">
                                    <li><i class="fa fa-user"></i>By admin</li>
                                    <li><i class="fa fa-calendar"></i>25/07/2013</li>
                                    <li><i class="fa fa-tags"></i>Metronic, Keenthemes, UI Design</li>
                                </ul>
                            </div>
                            <!-- END LEFT SIDEBAR -->

                            <!-- BEGIN RIGHT SIDEBAR -->
                            <uc1:PostSidebar runat="server" ID="PostSidebar" />
                            <!-- END RIGHT SIDEBAR -->
                        </div>
                    </div>
                </div>
                <!-- END CONTENT -->
            </div>
            <!-- END SIDEBAR & CONTENT -->
        </div>
    </div>
</asp:Content>

