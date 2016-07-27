<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="../assets/admin/pages/css/news.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="../assets/admin/pages/css/blog.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL STYLES -->
    <link href="../css/frontend/addvideo.css" rel="stylesheet" />
    <%-- FONT --%>
    <link href="http://fonts.googleapis.com/css?family=Roboto+Condensed:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800|&amp;subset=latin,latin-ext,cyrillic,cyrillic-ext,greek-ext,greek,vietnamese" rel="stylesheet" type="text/css" />
    <link href="../libs/homeycombs/css/homeycombs.css" rel="stylesheet" />
    <link href="../css/frontend/btnAppStore.css" rel="stylesheet" />
    <link href="../css/frontend/custom.css" rel="stylesheet" />
    <!-- BEGIN SLIDER -->
    <div class="page-slider margin-bottom-40">
        <div class="fullwidthbanner-container revolution-slider" style="height: 500px;">
            <div class="fullwidthabnner">
                <ul id="revolutionul">
                    <!-- THE NEW SLIDE -->
                    <li data-transition="fade" data-slotamount="8" data-masterspeed="700" data-delay="9400" data-thumb="../assets/frontend/pages/img/revolutionslider/thumbs/thumb2.jpg">
                        <!-- THE MAIN IMAGE IN THE FIRST SLIDE -->
                        <img src="../assets/frontend/pages/img/revolutionslider/bg5.jpg" alt="" />
                        <div class="caption lfb"
                            data-x="30"
                            data-y="10"
                            data-speed="700"
                            data-start="1000"
                            data-easing="easeOutExpo">
                            <img src="../images/slider/OpenFarm.png" id="imgSliderFarm" alt="Image 1" />
                        </div>
                        <div class="caption lft slide_subtitle slide_item_left subtitle_1"
                            data-x="600"
                            data-y="150"
                            data-speed="400"
                            data-start="1500"
                            data-easing="easeOutExpo">
                            THỰC PHẨM AN TOÀN CẦN MINH BẠCH
                        </div>
                        <div class="caption lft slide_subtitle_white slide_item_left bold" style="color: black;"
                            data-x="600"
                            data-y="190"
                            data-speed="400"
                            data-start="2000"
                            data-easing="easeOutExpo">
                            Food safety requires transparency
                        </div>
                        <a class="caption lft btn dark green slide_item_left" href="#"
                            data-x="610"
                            data-y="250"
                            data-speed="400"
                            data-start="3000"
                            data-easing="easeOutExpo">Xem thêm !
                        </a>

                    </li>

                    <!-- THE FIRST SLIDE -->
                    <li data-transition="fade" data-slotamount="8" data-masterspeed="700" data-delay="9400" data-thumb="../assets/frontend/pages/img/revolutionslider/thumbs/thumb2.jpg">
                        <!-- THE MAIN IMAGE IN THE FIRST SLIDE -->
                        <img src="../images/slider/TrachNhiemDoanhNghiep.PNG" alt="" />

                        <div class="caption lft slide_subtitle slide_item_left subtitle_2 bold"
                            data-x="0"
                            data-y="360"
                            data-speed="400"
                            data-start="2000"
                            data-easing="easeOutExpo">
                            DOANH NGHIỆP TRÁCH NHIỆM - MINH BẠCH
                        </div>

                        <a class="caption lft btn green slide_item_left" href="#"
                            data-x="0"
                            data-y="410"
                            data-speed="400"
                            data-start="3000"
                            data-easing="easeOutExpo">Xem thêm !
                        </a>

                    </li>

                    <!-- THE SECOND SLIDE -->
                    <li data-transition="fade" data-slotamount="7" data-masterspeed="300" data-delay="9400" data-thumb="../assets/frontend/pages/img/revolutionslider/thumbs/thumb2.jpg">
                        <img src="../images/slider/NguoiTieuDungThongMinh.PNG" alt="" />
                        <div class="caption lft slide_subtitle slide_item_left subtitle_2 bold"
                            data-x="0"
                            data-y="360"
                            data-speed="400"
                            data-start="2000"
                            data-easing="easeOutExpo">
                            NGƯỜI TIÊU DÙNG THÔNG MINH
                        </div>
                        <a class="caption lft btn green slide_item_left" href="#"
                            data-x="0"
                            data-y="410"
                            data-speed="400"
                            data-start="3000"
                            data-easing="easeOutExpo">Xem thêm !
                        </a>
                    </li>

                    <!-- THE THIRD SLIDE -->
                    <li data-transition="fade" data-slotamount="8" data-masterspeed="700" data-delay="9400" data-thumb="../assets/frontend/pages/img/revolutionslider/thumbs/thumb2.jpg">
                        <img src="../images/slider/hoinghifta2.jpg" alt="" />
                        <div class="caption lft slide_subtitle slide_item_left subtitle_2 bold"
                            data-x="0"
                            data-y="360"
                            data-speed="400"
                            data-start="2000"
                            data-easing="easeOutExpo">
                            GIA NHẬP GIA ĐÌNH THỰC PHẨM MINH BẠCH
                        </div>
                        <a class="caption lft btn green slide_item_left" href="#"
                            data-x="0"
                            data-y="410"
                            data-speed="400"
                            data-start="3000"
                            data-easing="easeOutExpo">Xem thêm !
                        </a>
                    </li>

                    <!-- THE FORTH SLIDE -->
                    <%--<li data-transition="fade" data-slotamount="8" data-masterspeed="700" data-delay="9400" data-thumb="../assets/frontend/pages/img/revolutionslider/thumbs/thumb2.jpg">
                        <!-- THE MAIN IMAGE IN THE FIRST SLIDE -->
                        <img src="../assets/frontend/pages/img/revolutionslider/bg4.jpg" alt="" />
                        <div class="caption lft slide_title"
                            data-x="30"
                            data-y="105"
                            data-speed="400"
                            data-start="1500"
                            data-easing="easeOutExpo">
                            What else included ?
                           
                        </div>
                        <div class="caption lft slide_subtitle"
                            data-x="30"
                            data-y="180"
                            data-speed="400"
                            data-start="2000"
                            data-easing="easeOutExpo">
                            The Most Complete Admin Theme
                           
                        </div>
                        <div class="caption lft slide_desc"
                            data-x="30"
                            data-y="225"
                            data-speed="400"
                            data-start="2500"
                            data-easing="easeOutExpo">
                            Lorem ipsum dolor sit amet, consectetuer elit sed diam<br />
                            nonummy amet euismod dolore.
                           
                        </div>
                        <a class="caption lft slide_btn btn red slide_item_left" href="#" target="_blank"
                            data-x="30"
                            data-y="300"
                            data-speed="400"
                            data-start="3000"
                            data-easing="easeOutExpo">Learn More!
                        </a>
                        <div class="caption lft start"
                            data-x="670"
                            data-y="55"
                            data-speed="400"
                            data-start="2000"
                            data-easing="easeOutBack">
                            <img src="../assets/frontend/pages/img/revolutionslider/iphone_left.png" alt="Image 2" />
                        </div>

                        <div class="caption lft start"
                            data-x="850"
                            data-y="55"
                            data-speed="400"
                            data-start="2400"
                            data-easing="easeOutBack">
                            <img src="../assets/frontend/pages/img/revolutionslider/iphone_right.png" alt="Image 3" />
                        </div>
                    </li>--%>
                </ul>
                <div class="tp-bannertimer tp-bottom"></div>
            </div>
        </div>
    </div>
    <!-- END SLIDER -->

    <div class="main">
        <div class="container">


            <%-- NGUOI TIEU DUNG SLIDE 2 --%>

            <div class="row margin-bottom-40">
                <%--<div class="col-lg-12">
                    <h3 class="margin-bottom-15">NGƯỜI TIÊU DÙNG</h3>
                    <div class="col-lg-6">
                        <div class="videonguoitieudung">
                            <iframe width="560" height="315" src="https://www.youtube.com/embed/A60b9KuOsI0" frameborder="0" allowfullscreen></iframe>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <h1>TRUY XUẤT NGUỒN GỐC ĐIỆN TỬ</h1>
                        <label>YOUTUBE, VIMEO AND OTHERS.</label>
                        <ul>
                            <li>Ứng dụng điện thoại di động để tra cứu thông tin minh bạch về sản phẩm
                            </li>
                            <li>Nhập thông tin nhanh, đơn giản, theo nhu cầu của doanh nghiệp
                            </li>
                            <li>Người tiêu dùng tra cứu thông tin bằng cách quét mã vạch sản phẩm
                            </li>
                            <li>Công cụ tiếp thị mà không làm thay đổi bao bì
                            </li>
                            <li>Chi phí thấp và hiệu quả.
                            </li>
                        </ul>
                        <a class="btn btn-warning">Đăng ký người dùng</a>
                    </div>
                </div>--%>
                <%--<h3 class="margin-bottom-15"></h3>--%>
                <div class="col-lg-12">
                    <div class="col-lg-6">
                        <div class="col-lg-12 margin-bottom-60"></div>
                        <h3>Ứng dụng tra cứu thông tin minh bạch</h3>
                        <p>Ứng dụng hỗ trợ trên nền tảng thiết bị Android & IOS</p>
                        <%-- Btn App Store --%>
                        <a href="#" class="btn btn-app-store disabled"><i class="fa fa-apple"></i><span class="small">Download on the</span> <span class="big">App Store</span></a>
                        <%-- Btn Google store --%>
                        <a href="#" class="btn btn-app-store disabled">
                            <img width="60" class="pull-left" src="http://www.userlogos.org/files/logos/jumpordie/google_play_04.png" />
                            <span class="small">Download on the</span> <span class="big">Google play</span></a>

                    </div>
                    <div class="col-lg-4">
                        <img src="../images/content/nguoitieudung/fta2_iphone-hand-mockup-drop-1000x640.png" style="width: 100%; height: auto;" />
                    </div>
                    <div class="col-lg-2">
                        <div class="col-lg-12 margin-bottom-65"></div>
                        <%--<img src="../images/content/nguoitieudung/checkQ-Code.png" style="width: 100%; height: auto;" />--%>
                    </div>
                </div>
            </div>

            <%-- END NGUOI TIEU DUNG SLIDE 2 --%>

            <%-- BEGIN NEWS --%>
            <div class="row margin-bottom-40">
                <div class="col-lg-12">
                    <h3 class="margin-bottom-20">TIN TỨC</h3>
                    <div class="row">
                        <div class="col-md-5">
                            <div id="myCarousel" class="carousel image-carousel slide">
                                <div class="carousel-inner">
                                    <asp:Repeater ID="rptSubSlider" runat="server">
                                        <ItemTemplate>
                                            <div class='<%# (Container.ItemIndex==0)?"active item":"item" %>'>
                                                <img src='<%# "../" + Eval("ImagesUrl") %>' class="img-responsive" alt='<%# Eval("Title") %>' />
                                                <div class="carousel-caption">
                                                    <h4>
                                                        <a href="#"><%# Eval("Title") %> </a>
                                                    </h4>
                                                    <p>
                                                        <%# Eval("Descriptions") %>
                                                    </p>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <!-- Carousel nav -->
                                <a class="carousel-control left" href="#myCarousel" data-slide="prev">
                                    <i class="m-icon-big-swapleft m-icon-white"></i>
                                </a>
                                <a class="carousel-control right" href="#myCarousel" data-slide="next">
                                    <i class="m-icon-big-swapright m-icon-white"></i>
                                </a>
                                <ol class="carousel-indicators">
                                    <asp:Repeater ID="rptindicators" runat="server">
                                        <ItemTemplate>
                                            <li data-target="#myCarousel" data-slide-to='<%# Container.ItemIndex.ToString() %>' class='<%# (Container.ItemIndex==0)?"active":"" %>'></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ol>
                            </div>
                            <div class="top-news margin-top-10">
                                <%--<a href="bao-chi-noi-ve-fta-16" class="btn red">
                                    <span>
                                        <asp:Label ID="lblNewsMidTop" runat="server" Text="Label"></asp:Label>
                                    </span>
                                    <em>
                                        <i class="fa fa-tags"></i>
                                        UK, Canada, Asia </em>
                                    <i class="fa fa-globe top-news-icon"></i>
                                </a>--%>
                            </div>
                            <asp:Repeater ID="rptLeftBlockNews" runat="server">
                                <ItemTemplate>
                                    <div class="news-blocks">
                                        <h3>
                                            <a href='<%# "Category-"+ XoaKyTuDacBiet(Eval("MetaTitle").ToString())+"-"+Eval("ID") %>'><%# Eval("TitleVN") %> </a>
                                        </h3>
                                        <div class="news-block-tags">
                                            <%--<strong>CA, USA</strong>--%>
                                            <em><i class="fa fa-calendar"></i>&nbsp<%# Eval("PostTime","{0:dd-MM-yyyy}") %></em>
                                        </div>
                                        <p>
                                            <img class="news-block-img pull-right" src='<%# "../../"+Eval("ImagesUrl") %>' alt="">
                                            <%# Limit(Eval("MetaDescriptions"),500) %>
                                        </p>
                                        <a href="page_news_item.html" class="news-block-btn">Read more <i class="m-icon-swapright m-icon-black"></i>
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <!--end col-md-5-->
                        <div class="col-md-4">
                            <div class="top-news">
                                <a href="bao-chi-noi-ve-fta-16" class="btn blue">
                                    <span>
                                        <asp:Label ID="lblLeftBlockNews" runat="server" Text="Label"></asp:Label>
                                    </span>
                                    <%--<em>
                                        <i class="fa fa-tags"></i>
                                        USA, Business, Apple </em>--%>
                                    <i class="fa fa- icon-bullhorn top-news-icon"></i>
                                </a>
                            </div>

                            <asp:Repeater ID="rptNewsMidTop" runat="server">
                                <ItemTemplate>
                                    <div class="news-blocks">
                                        <h3>
                                            <a href='<%# "Category-"+ XoaKyTuDacBiet(Eval("MetaTitle").ToString())+"-"+Eval("ID") %>'><%# Eval("TitleVN") %> </a>
                                        </h3>
                                        <div class="news-block-tags">
                                            <%--<strong>CA, USA</strong>--%>
                                            <em><i class="fa fa-calendar"></i>&nbsp<%# Eval("PostTime","{0:dd-MM-yyyy}") %></em>
                                        </div>
                                        <p>
                                            <img class="news-block-img pull-right" src='<%# "../../"+Eval("ImagesUrl") %>' alt="">
                                            <%# Limit(Eval("MetaDescriptions"),500) %>
                                        </p>
                                        <a href="page_news_item.html" class="news-block-btn">Read more <i class="m-icon-swapright m-icon-black"></i>
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <%-- <div class="top-news">
                                <a href="nguoi-tieu-dung-1" class="btn green">
                                    <span>
                                        <asp:Label ID="lblNewsMidBotom" runat="server" Text="Label"></asp:Label>
                                    </span>
                                    <em>
                                        <i class="fa fa-tags"></i>
                                        Money, Business, Google </em>
                                    <i class="fa fa-briefcase top-news-icon"></i>
                                </a>
                            </div>--%>
                            <asp:Repeater ID="rptNewsMidBotom" runat="server">
                                <ItemTemplate>
                                    <div class="news-blocks">
                                        <h3>
                                            <a href='<%# "Category-"+ XoaKyTuDacBiet(Eval("MetaTitle").ToString())+"-"+Eval("ID") %>'><%# Eval("TitleVN") %> </a>
                                        </h3>
                                        <div class="news-block-tags">
                                            <%--<strong>CA, USA</strong>--%>
                                            <em><i class="fa fa-calendar"></i>&nbsp<%# Eval("PostTime","{0:dd-MM-yyyy}") %></em>
                                        </div>
                                        <p>
                                            <img class="news-block-img pull-right" src='<%# "../../"+Eval("ImagesUrl") %>' alt="">
                                            <%# Limit(Eval("MetaDescriptions"),500) %>
                                        </p>
                                        <a href="page_news_item.html" class="news-block-btn">Read more <i class="m-icon-swapright m-icon-black"></i>
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <!--end col-md-4-->
                        <div class="col-md-3">
                            <%--<div class="top-news">
                                <a href="scienece-6" class="btn purple">
                                    <span>
                                        <asp:Label ID="lblNewsRight" runat="server" Text="Label"></asp:Label>
                                    </span>
                                    <em>
                                        <i class="fa fa-tags"></i>
                                        Hi-Tech, Medicine, Space </em>
                                    <i class="fa fa-beaker top-news-icon"></i>
                                </a>
                            </div>--%>
                            <asp:Repeater ID="rptNewsRight" runat="server">
                                <ItemTemplate>
                                    <div class="news-blocks">
                                        <h3>
                                            <a href='<%# "Category-"+ XoaKyTuDacBiet(Eval("MetaTitle").ToString())+"-"+Eval("ID") %>'><%# Eval("TitleVN") %> </a>
                                        </h3>
                                        <div class="news-block-tags">
                                            <%--<strong>CA, USA</strong>--%>
                                            <em><i class="fa fa-calendar"></i>&nbsp<%# Eval("PostTime","{0:dd-MM-yyyy}") %></em>
                                        </div>
                                        <p>
                                            <img class="news-block-img pull-right" src='<%# "../../"+Eval("ImagesUrl") %>' alt="">
                                            <%# Limit(Eval("MetaDescriptions"),500) %>
                                        </p>
                                        <a href="page_news_item.html" class="news-block-btn">Read more <i class="m-icon-swapright m-icon-black"></i>
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <!--end col-md-3-->
                    </div>
                    <div class="row">
                        <div class="col-md-5"></div>
                        <div class="col-md-4"></div>
                        <div class="col-md-3">
                            <a class="btn btn-info btn-block" href="Tin-noi-bat-3">Xem thêm các tin tức</a>
                        </div>
                    </div>
                </div>
            </div>
            <%-- END NEWS --%>
            <%-- BEGIN EVENT --%>
            <div class="row margin-bottom-40">
                <div class="col-lg-12">
                    <h3 class="margin-bottom-30">SỰ KIỆN</h3>
                    <div class="row">
                        <div class="col-md-8 article-block">
                            <%--<h3><strong>Sự kiện thành lập Hiệp Hội Thực Phẩm Minh Bạch</strong></h3>--%>
                            <h3><strong>
                                <asp:Label ID="lblEventNew" runat="server" Text="Label"></asp:Label></strong></h3>
                            <div class="blog-tag-data">
                                <img src="../../assets/admin/pages/media/gallery/item_img.jpg" id="imgEventNew" runat="server" class="img-responsive" alt="" />
                                <div class="row">
                                    <div class="col-md-6">
                                        <ul class="list-inline blog-tags">
                                            <li>
                                                <i class="fa fa-tags"></i>
                                                <asp:Repeater ID="rptTagsEventNew" runat="server">
                                                    <ItemTemplate>
                                                        <a href="#"><%# Eval("TagsName") %> </a>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="col-md-6 blog-tag-data-inner">
                                        <ul class="list-inline">
                                            <li>
                                                <i class="fa fa-calendar"></i>
                                                <a href="#">
                                                    <asp:Label ID="lblEventNewTimePost" runat="server" Text="Label"></asp:Label>
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <!--end news-tag-data-->
                            <div>
                                <p class="bold">
                                    <asp:Label ID="lblEventNewContent" runat="server" Text="Label"></asp:Label>
                                </p>

                            </div>
                        </div>
                        <!--end col-md-9-->
                        <div class="col-md-4 blog-sidebar">
                            <div class="space20">
                            </div>
                            <h3>Sự kiện đã diễn ra</h3>
                            <div class="top-news margin-bottom-30">

                                <asp:Repeater ID="rptTheEventTookPlace" runat="server">
                                    <ItemTemplate>
                                        <a href="#" title='<%# Eval("TitleVN") %>'
                                            class='<%# (Container.ItemIndex==0)?"btn red":(Container.ItemIndex==1)?"btn green":(Container.ItemIndex==2)?"btn blue":(Container.ItemIndex==3)?"btn yellow":"btn purple" %>'>
                                            <span><%# Limit(Eval("TitleVN").ToString(),30) %> </span>
                                            <em><i class="fa fa-calendar"></i>&nbsp <%# Eval("PostTime","{0:dd-MM-yyyy}") %></em>
                                            <i class="fa fa-briefcase top-news-icon"></i>
                                        </a>
                                    </ItemTemplate>
                                </asp:Repeater>

                                <%--<a href="#" class="btn red">
                                    <span>Tranparency News </span>
                                    <em>Posted on: April 16, 2013</em>
                                    <em>
                                        <i class="fa fa-tags"></i>
                                        Money, Business, Google </em>
                                    <i class="fa fa-briefcase top-news-icon"></i>
                                </a>
                                <a href="#" class="btn green">
                                    <span>Top Week </span>
                                    <em>Posted on: April 15, 2013</em>
                                    <em>
                                        <i class="fa fa-tags"></i>
                                        Internet, Music, People </em>
                                    <i class="fa fa-music top-news-icon"></i>
                                </a>
                                <a href="#" class="btn blue">
                                    <span>Gold Price Falls </span>
                                    <em>Posted on: April 14, 2013</em>
                                    <em>
                                        <i class="fa fa-tags"></i>
                                        USA, Business, Apple </em>
                                    <i class="fa fa-globe top-news-icon"></i>
                                </a>
                                <a href="#" class="btn yellow">
                                    <span>Study Abroad </span>
                                    <em>Posted on: April 13, 2013</em>
                                    <em>
                                        <i class="fa fa-tags"></i>
                                        Education, Students, Canada </em>
                                    <i class="fa fa-book top-news-icon"></i>
                                </a>
                                <a href="#" class="btn purple">
                                    <span>Top Destinations </span>
                                    <em>Posted on: April 12, 2013</em>
                                    <em>
                                        <i class="fa fa-tags"></i>
                                        Places, Internet, Google Map </em>
                                    <i class="fa fa-bolt top-news-icon"></i>
                                </a>--%>
                            </div>
                            <a class="btn btn-info btn-block" href="#">Xem tất cả các sự kiện</a>
                        </div>
                        <!--end col-md-3-->
                    </div>

                </div>
            </div>
            <%-- END EVENT --%>
            <!-- BEGIN CLIENTS -->
            <div class="row margin-bottom-40 our-clients">

                <h2><a href="#">Thành Viên</a></h2>

                <div class="col-md-12">
                    <!-- BEGIN BRANDS -->
                    <div class="brands">
                        <div class="container">
                            <div class="owl-carousel owl-carousel6-brands">
                                <a href="http://truyxuatnguongoc.com/">
                                    <img src="../../images/logo/TRACEVERIFIED.png" alt="canon" title="traceverified" />
                                    <%--<img src="../../assets/frontend/pages/img/brands/esprit.jpg" alt="esprit" title="esprit">--%>
                                </a>
                                <%--<a href="shop-product-list.html">
                                    <img src="../../assets/frontend/pages/img/brands/esprit.jpg" alt="esprit" title="esprit">
                                    <img src="../../assets/frontend/pages/img/brands/zara.jpg" alt="zara" title="zara">
                                </a>
                                <a href="shop-product-list.html">
                                    <img src="../../assets/frontend/pages/img/brands/gap.jpg" alt="gap" title="gap">
                                    <img src="../../assets/frontend/pages/img/brands/zara.jpg" alt="zara" title="zara">
                                </a>
                                <a href="shop-product-list.html">
                                    <img src="../../assets/frontend/pages/img/brands/next.jpg" alt="next" title="next">
                                    <img src="../../assets/frontend/pages/img/brands/next.jpg" alt="next" title="next">
                                </a>
                                <a href="shop-product-list.html">
                                    <img src="../../assets/frontend/pages/img/brands/puma.jpg" alt="puma" title="puma">
                                    <img src="../../assets/frontend/pages/img/brands/zara.jpg" alt="zara" title="zara">
                                </a>
                                <a href="shop-product-list.html">
                                    <img src="../../assets/frontend/pages/img/brands/zara.jpg" alt="zara" title="zara">
                                    <img src="../../assets/frontend/pages/img/brands/canon.jpg" alt="canon" title="canon">
                                </a>
                                <a href="shop-product-list.html">
                                    <img src="../../assets/frontend/pages/img/brands/canon.jpg" alt="canon" title="canon">
                                    <img src="../../assets/frontend/pages/img/brands/next.jpg" alt="next" title="next">
                                </a>
                                <a href="shop-product-list.html">
                                    <img src="../../assets/frontend/pages/img/brands/esprit.jpg" alt="esprit" title="esprit">
                                    <img src="../../assets/frontend/pages/img/brands/zara.jpg" alt="zara" title="zara">
                                </a>
                                <a href="shop-product-list.html">
                                    <img src="../../assets/frontend/pages/img/brands/gap.jpg" alt="gap" title="gap">
                                    <img src="../../assets/frontend/pages/img/brands/canon.jpg" alt="canon" title="canon">
                                </a>
                                <a href="shop-product-list.html">
                                    <img src="../../assets/frontend/pages/img/brands/next.jpg" alt="next" title="next">
                                    <img src="../../assets/frontend/pages/img/brands/canon.jpg" alt="canon" title="canon">
                                </a>
                                <a href="shop-product-list.html">
                                    <img src="../../assets/frontend/pages/img/brands/puma.jpg" alt="puma" title="puma">
                                    <img src="../../assets/frontend/pages/img/brands/next.jpg" alt="next" title="next">
                                </a>
                                <a href="shop-product-list.html">
                                    <img src="../../assets/frontend/pages/img/brands/zara.jpg" alt="zara" title="zara">
                                    <img src="../../assets/frontend/pages/img/brands/next.jpg" alt="next" title="next">
                                </a>--%>
                            </div>
                        </div>
                    </div>
                    <!-- END BRANDS -->
                </div>
            </div>
            <!-- END CLIENTS -->
        </div>
    </div>
    <script src="../libs/homeycombs/js/jquery.homeycombs.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.honeycombs').honeycombs({
                combWidth: 150,  // width of the hexagon
                margin: 4,      // spacing between hexagon
                threshold: 3    // hide placeholder hexagons when number of hexagons in a row is more than the threshold number
            });
        });
    </script>
</asp:Content>
