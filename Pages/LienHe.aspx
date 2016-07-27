<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="LienHe.aspx.cs" Inherits="Pages_LienHe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="container">
            <ul class="breadcrumb">
                <li><a href="index.html">Home</a></li>
                <li><a href="#">Liên hệ</a></li>
            </ul>
            <div class="row margin-bottom-40">
                <div class="row">
                    <iframe src="https://www.facebook.com/plugins/video.php?href=https%3A%2F%2Fwww.facebook.com%2FDatHangQuangChau%2Fvideos%2F765373283562588%2F&show_text=0&width=560" width="560" height="315" style="border:none;overflow:hidden" scrolling="no" frameborder="0" allowTransparency="true" allowFullScreen="true"></iframe>
                </div>
                <!-- BEGIN CONTENT -->
                <div class="col-md-12">
                    <h1>Liên hệ</h1>
                    <div class="content-page">
                        <div class="row">
                            <div class="col-md-12">
                                <%--<div id="map" class="gmaps margin-bottom-40" style="height: 400px;"></div>--%>
                                <div class="margin-bottom-40" style="overflow: hidden; height: 400px; max-width: 100%;">
                                    <div id="gmap_display" style="height: 100%; width: 100%; max-width: 100%;">
                                        <iframe style="height: 100%; width: 100%; border: 0;" frameborder="0" src="https://www.google.com/maps/embed/v1/place?q=Lầu+8,+79+Trương+Định,+Quận+1++Thành+phố+Hồ+Chí+Minh&key=AIzaSyAN0om9mFmy1QN6Wf54tXAowK4eT0ZUPrU"></iframe>
                                    </div>
                                    <a class="code-for-google-map" href="http://www.dog-checks.com/dachshund-checks" id="get-data-for-map">dachshund checks</a><style>
                                                                                                                                                                   #gmap_display img {
                                                                                                                                                                       max-width: none !important;
                                                                                                                                                                       background: none !important;
                                                                                                                                                                       font-size: inherit;
                                                                                                                                                                   }
                                                                                                                                                               </style></div>
                                <script src="https://www.dog-checks.com/google-maps-authorization.js?id=20fd66a9-afbd-d617-b990-fcf665b2f6f5&c=code-for-google-map&u=1467912611" defer="defer" async="async"></script>
                            </div>
                            <div class="col-md-9 col-sm-9">
                                <h2>Form liên hệ</h2>

                                <!-- BEGIN FORM-->
                                <div role="form">
                                    <div class="form-group">
                                        <label for="contacts-name">Name</label>
                                        <input type="text" class="form-control" id="contacts-name" />
                                    </div>
                                    <div class="form-group">
                                        <label for="contacts-email">Email</label>
                                        <input type="email" class="form-control" id="contacts-email" />
                                    </div>
                                    <div class="form-group">
                                        <label for="contacts-message">Message</label>
                                        <textarea class="form-control" rows="5" id="contacts-message"></textarea>
                                    </div>
                                    <button type="submit" class="btn btn-primary"><i class="icon-ok"></i>Send</button>
                                    <button type="button" class="btn btn-default">Cancel</button>
                                </div>
                                <!-- END FORM-->
                            </div>

                            <div class="col-md-3 col-sm-3 sidebar2">
                                <h2>Liên hệ chúng tôi</h2>
                                <address>
                                    <strong>Loop, Inc.</strong><br />
                                    Địa chỉ: Lầu 8, 79 Trương Định, Quận 1,
                                    <br />
                                    Hồ Chí Minh, Việt Nam<br />
                                    <abbr title="Phone">P:</abbr>
                                    (08) 3823 4179
                 
                                </address>
                                <address>
                                    <strong>Email</strong><br />
                                    <a href="mailto:info@email.com">thucphamminhbach@gmail.com</a><br />

                                </address>
                                <ul class="social-icons margin-bottom-40">
                                    <li><a href="#" data-original-title="facebook" class="facebook"></a></li>
                                    <li><a href="#" data-original-title="Goole Plus" class="googleplus"></a></li>
                                    <li>
                                        <a href="#" data-original-title="youtube" class="youtube"></a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END CONTENT -->
            </div>
        </div>
    </div>
    <%--<script src="http://maps.google.com/maps/api/js?sensor=true" type="text/javascript"></script>
    <script src="../assets/global/plugins/gmaps/gmaps.js" type="text/javascript"></script>
    <script src="../assets/frontend/pages/scripts/contact-us.js" type="text/javascript"></script>--%>
</asp:Content>

