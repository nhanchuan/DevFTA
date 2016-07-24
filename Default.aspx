﻿<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
    <!-- BEGIN SLIDER -->
    <div class="page-slider margin-bottom-40">
        <div class="fullwidthbanner-container revolution-slider" style="height: 500px;">
            <div class="fullwidthabnner">
                <ul id="revolutionul">
                    <!-- THE NEW SLIDE -->
                    <li data-transition="fade" data-slotamount="8" data-masterspeed="700" data-delay="9400" data-thumb="../assets/frontend/pages/img/revolutionslider/thumbs/thumb2.jpg">
                        <!-- THE MAIN IMAGE IN THE FIRST SLIDE -->
                        <img src="../assets/frontend/pages/img/revolutionslider/bg5.jpg" alt="" />

                        <div class="caption lft slide_title_white slide_item_left" style="color: black; font: 300 47px/66px, 'Open Sans', sans-serif;"
                            data-x="640"
                            data-y="90"
                            data-speed="400"
                            data-start="1500"
                            data-easing="easeOutExpo">
                            THỰC PHẨM AN TOÀN
                            <br />
                            <span class="slide_title_white_bold">CẦN MINH BẠCH</span>
                        </div>
                        <div class="caption lft slide_subtitle_white slide_item_left" style="color: black;"
                            data-x="697"
                            data-y="245"
                            data-speed="400"
                            data-start="2000"
                            data-easing="easeOutExpo">
                            Food safety requires transparency
                        </div>
                        <a class="caption lft btn dark btn-danger slide_item_left" href="#"
                            data-x="797"
                            data-y="315"
                            data-speed="400"
                            data-start="3000"
                            data-easing="easeOutExpo">Đăng ký ngay!
                        </a>
                        <div class="caption lfb"
                            data-x="30"
                            data-y="40"
                            data-speed="700"
                            data-start="1000"
                            data-easing="easeOutExpo">
                            <img src="../images/logo/LogoftaFN.png" alt="Image 1" />
                        </div>
                    </li>

                    <!-- THE FIRST SLIDE -->
                    <li data-transition="fade" data-slotamount="8" data-masterspeed="700" data-delay="9400" data-thumb="../assets/frontend/pages/img/revolutionslider/thumbs/thumb2.jpg">
                        <!-- THE MAIN IMAGE IN THE FIRST SLIDE -->
                        <img src="../images/slider/background/hoinghifta2.jpg" alt="" />

                        <%--<div class="caption lft slide_title slide_item_left"
                            data-x="30"
                            data-y="105"
                            data-speed="400"
                            data-start="1500"
                            data-easing="easeOutExpo">
                            Hội thảo vận động thành lập FTA Hà Nội - Hồ Chí Minh 
             
                        </div>--%>
                        <div class="caption lft slide_subtitle slide_item_left"
                            data-x="0"
                            data-y="410"
                            data-speed="400"
                            data-start="2000"
                            data-easing="easeOutExpo">
                            Hội thảo vận động thành lập FTA Hà Nội - Hồ Chí Minh
             
                        </div>
                        <%--<div class="caption lft slide_desc slide_item_left"
                            data-x="30"
                            data-y="220"
                            data-speed="400"
                            data-start="2500"
                            data-easing="easeOutExpo">
                            Lorem ipsum dolor sit amet, dolore eiusmod<br />
                            quis tempor incididunt. Sed unde omnis iste.
             
                        </div>--%>
                        <a class="caption lft btn green slide_btn slide_item_left" href="http://themeforest.net/item/metronic-responsive-admin-dashboard-template/4021469?ref=keenthemes"
                            data-x="0"
                            data-y="450"
                            data-speed="400"
                            data-start="3000"
                            data-easing="easeOutExpo">Xem thêm !
                        </a>
                        <%--<div class="caption lfb"
                            data-x="640"
                            data-y="55"
                            data-speed="700"
                            data-start="1000"
                            data-easing="easeOutExpo">
                            <img src="../assets/frontend/pages/img/revolutionslider/man-winner.png" alt="Image 1" />
                        </div>--%>
                    </li>

                    <!-- THE SECOND SLIDE -->
                    <%--<li data-transition="fade" data-slotamount="7" data-masterspeed="300" data-delay="9400" data-thumb="../assets/frontend/pages/img/revolutionslider/thumbs/thumb2.jpg">
                        <img src="../assets/frontend/pages/img/revolutionslider/bg2.jpg" alt="" />
                        <div class="caption lfl slide_title slide_item_left"
                            data-x="30"
                            data-y="125"
                            data-speed="400"
                            data-start="3500"
                            data-easing="easeOutExpo">
                            Powerfull &amp; Clean
             
                        </div>
                        <div class="caption lfl slide_subtitle slide_item_left"
                            data-x="30"
                            data-y="200"
                            data-speed="400"
                            data-start="4000"
                            data-easing="easeOutExpo">
                            Responsive Admin &amp; Website Theme
             
                        </div>
                        <div class="caption lfl slide_desc slide_item_left"
                            data-x="30"
                            data-y="245"
                            data-speed="400"
                            data-start="4500"
                            data-easing="easeOutExpo">
                            Lorem ipsum dolor sit amet, consectetuer elit sed diam<br />
                            nonummy amet euismod dolore.
             
                        </div>
                        <div class="caption lfr slide_item_right"
                            data-x="635"
                            data-y="105"
                            data-speed="1200"
                            data-start="1500"
                            data-easing="easeOutBack">
                            <img src="../assets/frontend/pages/img/revolutionslider/mac.png" alt="Image 1" />
                        </div>
                        <div class="caption lfr slide_item_right"
                            data-x="580"
                            data-y="245"
                            data-speed="1200"
                            data-start="2000"
                            data-easing="easeOutBack">
                            <img src="../assets/frontend/pages/img/revolutionslider/ipad.png" alt="Image 1" />
                        </div>
                        <div class="caption lfr slide_item_right"
                            data-x="735"
                            data-y="290"
                            data-speed="1200"
                            data-start="2500"
                            data-easing="easeOutBack">
                            <img src="../assets/frontend/pages/img/revolutionslider/iphone.png" alt="Image 1" />
                        </div>
                        <div class="caption lfr slide_item_right"
                            data-x="835"
                            data-y="230"
                            data-speed="1200"
                            data-start="3000"
                            data-easing="easeOutBack">
                            <img src="../assets/frontend/pages/img/revolutionslider/macbook.png" alt="Image 1" />
                        </div>
                        <div class="caption lft slide_item_right"
                            data-x="865"
                            data-y="45"
                            data-speed="500"
                            data-start="5000"
                            data-easing="easeOutBack">
                            <img src="../assets/frontend/pages/img/revolutionslider/hint1-red.png" id="rev-hint1" alt="Image 1" />
                        </div>
                        <div class="caption lfb slide_item_right"
                            data-x="355"
                            data-y="355"
                            data-speed="500"
                            data-start="5500"
                            data-easing="easeOutBack">
                            <img src="../assets/frontend/pages/img/revolutionslider/hint2-red.png" id="rev-hint2" alt="Image 1" />
                        </div>
                    </li>

                    <!-- THE THIRD SLIDE -->
                    <li data-transition="fade" data-slotamount="8" data-masterspeed="700" data-delay="9400" data-thumb="../assets/frontend/pages/img/revolutionslider/thumbs/thumb2.jpg">
                        <img src="../assets/frontend/pages/img/revolutionslider/bg3.jpg" alt="" />
                        <div class="caption lfl slide_item_left"
                            data-x="30"
                            data-y="95"
                            data-speed="400"
                            data-start="1500"
                            data-easing="easeOutBack">
                            <iframe src="http://player.vimeo.com/video/56974716?portrait=0" width="420" height="240" style="border: 0"></iframe>
                        </div>
                        <div class="caption lfr slide_title"
                            data-x="470"
                            data-y="100"
                            data-speed="400"
                            data-start="2000"
                            data-easing="easeOutExpo">
                            Responsive Video Support
             
                        </div>
                        <div class="caption lfr slide_subtitle"
                            data-x="470"
                            data-y="170"
                            data-speed="400"
                            data-start="2500"
                            data-easing="easeOutExpo">
                            Youtube, Vimeo and others.
             
                        </div>
                        <div class="caption lfr slide_desc"
                            data-x="470"
                            data-y="220"
                            data-speed="400"
                            data-start="3000"
                            data-easing="easeOutExpo">
                            Lorem ipsum dolor sit amet, consectetuer elit sed diam<br />
                            nonummy amet euismod dolore.
             
                        </div>
                        <a class="caption lfr btn yellow slide_btn" href="#"
                            data-x="470"
                            data-y="280"
                            data-speed="400"
                            data-start="3500"
                            data-easing="easeOutExpo">Watch more Videos!
                        </a>
                    </li>

                    <!-- THE FORTH SLIDE -->
                    <li data-transition="fade" data-slotamount="8" data-masterspeed="700" data-delay="9400" data-thumb="../assets/frontend/pages/img/revolutionslider/thumbs/thumb2.jpg">
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
            <div class="row">
                <div class="col-lg-12">
                    <h3 class="margin-bottom-15">DOANH NGHIỆP</h3>
                    <div class="honeycombs">
                        <div class="comb">
                            <img src="../images/picture_0.jpg" />
                            <span>1</span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_1.jpg" />
                            <span>
                                <span>2</span>
                            </span>
                        </div>
                        <div class="comb">
                            <img src="../images/logo/LogoftaFN.png" />
                            <span>3</span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_3.jpg" />
                            <span>4</span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_4.jpg" />
                            <span>5</span>
                        </div>
                        <div class="comb">
                            <img src="../images/properties/Quytrinhsanxuat.jpg" />
                            <span>6</span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_1.jpg" />
                            <span>7</span>
                        </div>
                        <div class="comb">
                            <img src="../images/logo/LogoftaFN.png" />
                            <span>8</span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_3.jpg" />
                            <span>9</span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_4.jpg" />
                            <span>10</span>
                        </div>
                        <div class="comb">
                            <img src="../images/properties/Quytrinhsanxuat.jpg" />
                            <span>11</span>
                        </div>
                        <div class="comb">
                            <img src="../images/properties/cac-loai-rau.jpg" />
                            <span>12</span>
                        </div>
                        <div class="comb">
                            <img src="../images/properties/Chatbaoquan.jpg" />
                            <span>13</span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_3.jpg" />
                            <span>14</span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_4.jpg" />
                            <span>15</span>
                        </div>
                        <div class="comb">
                            <img src="../images/properties/Vietnam.jpg" />
                            <span>16</span>
                        </div>
                        <div class="comb">
                            <img src="../images/properties/MinhBach.jpg" />
                            <span>17</span>
                        </div>
                        <div class="comb">
                            <img src="../images/logo/LogoftaFN2.jpg" />
                            <span>FTA</span>
                        </div>
                        <div class="comb">
                            <img src="../images/properties/Probiotics.jpg" />
                            <span>18</span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_4.jpg" />
                            <span>19</span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_2.jpg" />
                            <span>20</span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_3.jpg" />
                            <span>21</span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_4.jpg" />
                            <span>22</span>
                        </div>
                        <div class="comb">
                            <img src="../images/properties/Quytrinhsanxuat.jpg" />
                            <span>23</span>
                        </div>
                        <div class="comb">
                            <img src="../images/properties/dohop.jpg" />
                            <span>24</span>
                        </div>
                        <div class="comb">
                            <img src="../images/properties/Quytrinhsanxuat.jpg" />
                            <span>25</span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_1.jpg" />
                            <span>26</span>
                        </div>
                        <%--<div class="comb">
                            <img src="../images/picture_2.jpg" />
                            <span>27</span>
                        </div>--%>
                    </div>
                </div>
            </div>

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
                <h3 class="margin-bottom-15">NGƯỜI TIÊU DÙNG</h3>
                <div class="col-lg-12">
                    <div class="col-lg-4">
                        <div class="col-lg-12 margin-bottom-60"></div>
                        <h3>United On The Go</h3>
                        <p>Their newest device is the Blu Life Pure mini, a 4.5” smartphone with a 1280 x 720 IPS display.</p>
                        <a href="#" class="btn btn-app-store"><i class="fa fa-apple"></i><span class="small">Download on the</span> <span class="big">App Store</span></a>
                        <a href="#" class="btn btn-app-store">
                            <img width="60" class="pull-left" src="http://www.userlogos.org/files/logos/jumpordie/google_play_04.png" />
                            <span class="small">Download on the</span> <span class="big">Google play</span></a>

                    </div>
                    <div class="col-lg-4">
                        <img src="../images/content/nguoitieudung/iphone-hand-mockup-drop-1000x640.png" style="width: 100%; height: auto;" />
                    </div>
                    <div class="col-lg-4">
                        <div class="col-lg-12 margin-bottom-65"></div>
                        <img src="../images/content/nguoitieudung/checkQ-Code.png" style="width: 100%; height: auto;" />
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
                                                        <a href="page_news_item.html"><%# Eval("Title") %> </a>
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
                                <a href="kinh-te-13" class="btn blue">
                                    <span>
                                        <asp:Label ID="lblLeftBlockNews" runat="server" Text="Label"></asp:Label>
                                    </span>
                                    <em>
                                        <i class="fa fa-tags"></i>
                                        USA, Business, Apple </em>
                                    <i class="fa fa- icon-bullhorn top-news-icon"></i>
                                </a>
                            </div>
                            <asp:Repeater ID="rptLeftBlockNews" runat="server">
                                <ItemTemplate>
                                    <div class="news-blocks">
                                        <h3>
                                            <a href="#"><%# Eval("TitleVN") %> </a>
                                        </h3>
                                        <div class="news-block-tags">
                                            <strong>CA, USA</strong>
                                            <em><i class="fa fa-calendar"></i><%# Eval("PostTime","{0:dd-MM-yyyy}") %></em>
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
                                <a href="thi-truong-14" class="btn red">
                                    <span>
                                        <asp:Label ID="lblNewsMidTop" runat="server" Text="Label"></asp:Label>
                                    </span>
                                    <em>
                                        <i class="fa fa-tags"></i>
                                        UK, Canada, Asia </em>
                                    <i class="fa fa-globe top-news-icon"></i>
                                </a>
                            </div>
                            <asp:Repeater ID="rptNewsMidTop" runat="server">
                                <ItemTemplate>
                                    <div class="news-blocks">
                                        <h3>
                                            <a href="#"><%# Eval("TitleVN") %> </a>
                                        </h3>
                                        <div class="news-block-tags">
                                            <strong>CA, USA</strong>
                                            <em><i class="fa fa-calendar"></i><%# Eval("PostTime","{0:dd-MM-yyyy}") %></em>
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
                            <div class="top-news">
                                <a href="nguoi-tieu-dung-1" class="btn green">
                                    <span>
                                        <asp:Label ID="lblNewsMidBotom" runat="server" Text="Label"></asp:Label>
                                    </span>
                                    <em>
                                        <i class="fa fa-tags"></i>
                                        Money, Business, Google </em>
                                    <i class="fa fa-briefcase top-news-icon"></i>
                                </a>
                            </div>
                            <asp:Repeater ID="rptNewsMidBotom" runat="server">
                                <ItemTemplate>
                                    <div class="news-blocks">
                                        <h3>
                                            <a href="#"><%# Eval("TitleVN") %> </a>
                                        </h3>
                                        <div class="news-block-tags">
                                            <strong>CA, USA</strong>
                                            <em><i class="fa fa-calendar"></i><%# Eval("PostTime","{0:dd-MM-yyyy}") %></em>
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
                            <div class="top-news">
                                <a href="scienece-6" class="btn purple">
                                    <span>
                                        <asp:Label ID="lblNewsRight" runat="server" Text="Label"></asp:Label>
                                    </span>
                                    <em>
                                        <i class="fa fa-tags"></i>
                                        Hi-Tech, Medicine, Space </em>
                                    <i class="fa fa-beaker top-news-icon"></i>
                                </a>
                            </div>
                            <asp:Repeater ID="rptNewsRight" runat="server">
                                <ItemTemplate>
                                    <div class="news-blocks">
                                        <h3>
                                            <a href="#"><%# Eval("TitleVN") %> </a>
                                        </h3>
                                        <div class="news-block-tags">
                                            <strong>CA, USA</strong>
                                            <em><i class="fa fa-calendar"></i><%# Eval("PostTime","{0:dd-MM-yyyy}") %></em>
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
                    <a class="btn btn-info btn-block" href="../Pages/TinTucVaSuKien.aspx">Xem thêm các tin tức</a>
                </div>
            </div>
            <%-- END NEWS --%>
            <%-- BEGIN EVENT --%>
            <div class="row margin-bottom-40">
                <div class="col-lg-12">
                    <h3 class="margin-bottom-30">SỰ KIỆN</h3>
                    <div class="row">
                        <div class="col-md-8 article-block">
                            <h3><strong>Sự kiện thành lập Hiệp Hội Thực Phẩm Minh Bạch</strong></h3>
                            <div class="blog-tag-data">
                                <img src="../../assets/admin/pages/media/gallery/item_img.jpg" class="img-responsive" alt="">
                                <div class="row">
                                    <div class="col-md-6">
                                        <ul class="list-inline blog-tags">
                                            <li>
                                                <i class="fa fa-tags"></i>
                                                <a href="#">Technology </a>
                                                <a href="#">Education </a>
                                                <a href="#">Internet </a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="col-md-6 blog-tag-data-inner">
                                        <ul class="list-inline">
                                            <li>
                                                <i class="fa fa-calendar"></i>
                                                <a href="#">April 16, 2013 </a>
                                            </li>
                                            <li>
                                                <i class="fa fa-comments"></i>
                                                <a href="#">38 Comments </a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <!--end news-tag-data-->
                            <div>
                                <p>
                                    At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non libero consectetur adipiscing elit magna. Sed et quam lacus. Fusce condimentum eleifend enim a feugiat. Pellentesque viverra vehicula sem ut volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non libero magna. Sed et quam lacus. Fusce condimentum eleifend enim a feugiat.
                                </p>
                                <blockquote class="hero">
                                    <p>
                                        Lorem ipsum dolor sit amet, consectetur adipiscing elit posuere erat a ante.
                                    </p>
                                    <small>Someone famous <cite title="Source Title">Source Title</cite></small>
                                </blockquote>
                            </div>
                        </div>
                        <!--end col-md-9-->
                        <div class="col-md-4 blog-sidebar">
                            <div class="space20">
                            </div>
                            <h3>Sự kiện đã diễn ra</h3>
                            <div class="top-news margin-bottom-30">
                                <a href="#" class="btn red">
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
                                </a>
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
                                <a href="shop-product-list.html">
                                    <img src="../../assets/frontend/pages/img/brands/canon.jpg" alt="canon" title="canon">
                                    <img src="../../assets/frontend/pages/img/brands/esprit.jpg" alt="esprit" title="esprit">
                                </a>
                                <a href="shop-product-list.html">
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
                                </a>
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
