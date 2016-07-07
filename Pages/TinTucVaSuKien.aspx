<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="TinTucVaSuKien.aspx.cs" Inherits="Pages_TinTucVaSuKien" %>

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
                    <h1>Tin tức & Sự kiện</h1>
                    <div class="content-page">
                        <div class="row">
                            <!-- BEGIN LEFT SIDEBAR -->
                            <div class="col-md-9 col-sm-9 blog-posts">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4">
                                        <!-- BEGIN CAROUSEL -->
                                        <div class="front-carousel">
                                            <div class="carousel slide" id="myCarousel">
                                                <!-- Carousel items -->
                                                <div class="carousel-inner">
                                                    <div class="item">
                                                        <img alt="" src="../../assets/frontend/pages/img/works/img1.jpg" />
                                                    </div>
                                                    <div class="item">
                                                        <img alt="" src="../../assets/frontend/pages/img/works/img2.jpg" />
                                                    </div>
                                                    <div class="item active">
                                                        <img alt="" src="../../assets/frontend/pages/img/works/img3.jpg" />
                                                    </div>
                                                </div>
                                                <!-- Carousel nav -->
                                                <a data-slide="prev" href="#myCarousel" class="carousel-control left">
                                                    <i class="fa fa-angle-left"></i>
                                                </a>
                                                <a data-slide="next" href="#myCarousel" class="carousel-control right">
                                                    <i class="fa fa-angle-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <!-- END CAROUSEL -->
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h2><a href="../Pages/PostItem.aspx">Corrupti quos dolores etquas</a></h2>
                                        <ul class="blog-info">
                                            <li><i class="fa fa-calendar"></i>25/07/2013</li>
                                            <li><i class="fa fa-comments"></i>17</li>
                                            <li><i class="fa fa-tags"></i>Metronic, Keenthemes, UI Design</li>
                                        </ul>
                                        <p>At vero eos et accusamus et iusto odio dignissimos ducimus qui sint blanditiis prae sentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non eleifend enim a feugiat. Pellentesque viverra vehicula sem ut volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing condimentum eleifend enim a feugiat.</p>
                                        <a href="blog-item.html" class="more">Read more <i class="icon-angle-right"></i></a>
                                    </div>
                                </div>
                                <hr class="blog-post-sep" />
                                <div class="row">
                                    <div class="col-md-4 col-sm-4">
                                        <img class="img-responsive" alt="" src="../../assets/frontend/pages/img/works/img4.jpg" />
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h2><a href="../Pages/PostItem.aspx">Corrupti quos dolores etquas</a></h2>
                                        <ul class="blog-info">
                                            <li><i class="fa fa-calendar"></i>25/07/2013</li>
                                            <li><i class="fa fa-comments"></i>17</li>
                                            <li><i class="fa fa-tags"></i>Metronic, Keenthemes, UI Design</li>
                                        </ul>
                                        <p>At vero eos et accusamus et iusto odio dignissimos ducimus qui sint blanditiis prae sentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non eleifend enim a feugiat. Pellentesque viverra vehicula sem ut volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing condimentum eleifend enim a feugiat.</p>
                                        <a href="blog-item.html" class="more">Read more <i class="icon-angle-right"></i></a>
                                    </div>
                                </div>
                                <hr class="blog-post-sep" />
                                <div class="row">
                                    <div class="col-md-4 col-sm-4">
                                        <!-- BEGIN VIDEO -->
                                        <iframe height="205" allowfullscreen="" style="width: 100%; border: 0" src="http://player.vimeo.com/video/56974716?portrait=0"></iframe>
                                        <!-- END VIDEO -->
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h2><a href="blog-item.html">Corrupti quos dolores etquas</a></h2>
                                        <ul class="blog-info">
                                            <li><i class="fa fa-calendar"></i>25/07/2013</li>
                                            <li><i class="fa fa-comments"></i>17</li>
                                            <li><i class="fa fa-tags"></i>Metronic, Keenthemes, UI Design</li>
                                        </ul>
                                        <p>At vero eos et accusamus et iusto odio dignissimos ducimus qui sint blanditiis prae sentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non eleifend enim a feugiat. Pellentesque viverra vehicula sem ut volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing condimentum eleifend enim a feugiat.</p>
                                        <a href="blog-item.html" class="more">Read more <i class="fa fa-angle-right"></i></a>
                                    </div>
                                </div>
                                <hr class="blog-post-sep" />
                                <div class="row">
                                    <div class="col-md-4 col-sm-4">
                                        <img class="img-responsive" alt="" src="../../assets/frontend/pages/img/works/img2.jpg">
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h2><a href="#">Corrupti quos dolores etquas</a></h2>
                                        <ul class="blog-info">
                                            <li><i class="fa fa-calendar"></i>25/07/2013</li>
                                            <li><i class="fa fa-comments"></i>17</li>
                                            <li><i class="fa fa-tags"></i>Metronic, Keenthemes, UI Design</li>
                                        </ul>
                                        <p>At vero eos et accusamus et iusto odio dignissimos ducimus qui sint blanditiis prae sentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non eleifend enim a feugiat. Pellentesque viverra vehicula sem ut volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing condimentum eleifend enim a feugiat.</p>
                                        <a href="blog-item.html" class="more">Read more <i class="fa fa-angle-right"></i></a>
                                    </div>
                                </div>
                                <hr class="blog-post-sep" />
                                <ul class="pagination">
                                    <li><a href="#">Prev</a></li>
                                    <li><a href="#">1</a></li>
                                    <li><a href="#">2</a></li>
                                    <li class="active"><a href="#">3</a></li>
                                    <li><a href="#">4</a></li>
                                    <li><a href="#">5</a></li>
                                    <li><a href="#">Next</a></li>
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

