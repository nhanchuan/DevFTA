<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="LichSuHinhThanh.aspx.cs" Inherits="Pages_LichSuHinhThanh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="container">
            <ul class="breadcrumb">
                <li><a href="index.html">Home</a></li>
                <li><a href="#">Về chúng tôi</a></li>
                <li class="active">Lịch sử hình thành</li>
            </ul>
            <%-- /Row Timeline --%>
            <div class="row">
                <div class="col-lg-4">
                    <h2 class="margin-bottom-15">2011-2014</h2>
                    <p>
                        Dự án Truy xuất nguồn gốc điện tử được khởi xướng và nhận được sự tài trợ từ quỹ GCF (chính phủ Đan Mạch).
                    </p>
                </div>
                <div class="col-lg-4">
                    <h2 class="margin-bottom-15">2015</h2>
                    <p>
                        Nằm trong top 30 dự án khởi nghiệp tác động xã hội được tài trợ tham gia hội nghị khởi nghiệp lớn nhất toàn cầu SLUSH tổ chức ở Helsinki.
                    </p>
                </div>
                <div class="col-lg-4">
                    <h2 class="margin-bottom-15">2016</h2>
                    <p>
                        Thành lập công ty độc lập Công ty CP Giải pháp và dịch vụ Truy xuất nguồn gốc, khởi xướng thành lập Hiệp hội thực phẩm minh bạch Việt Nam.
                    </p>
                </div>
            </div>
            <%-- /Row Tầm nhìn --%>
            <div class="row">
                <div class="col-lg-12">
                    <h2 class="margin-bottom-15">Tầm nhìn</h2>
                    <p>
                        Trở thành nhà cung cấp dịch vụ Truy xuất nguồn gốc điện tử hàng đầu, phục vụ 70% các nhà sản xuất thực phẩm có trách nhiệm ở Việt Nam đến năm 2020 với mạng lưới đối tác phát triển bền vững và rộng khắp
                    </p>
                </div>
            </div>
            <%-- /Row Sứ mệnh --%>
            <div class="row">
                <div class="col-lg-12">
                    <h2 class="margin-bottom-15">Sứ mệnh</h2>
                    <p>
                        Trở thành trung tâm cầu nối tin tưởng giữa người sản xuất và người tiêu dùng, công bố với người tiêu dùng chính xác về quy trình sản xuất, thời gian thực của quá trình tạo ra sản phẩm
                    </p>
                    <img class="img-responsive" style="margin-left:25%;" src="../images/content/Tam-nhin-TraceVerified.gif" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

