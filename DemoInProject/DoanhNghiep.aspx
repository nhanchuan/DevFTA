<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="DoanhNghiep.aspx.cs" Inherits="DemoInProject_DoanhNghiep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../libs/homeycombs/css/homeycombs.css" rel="stylesheet" />
    <div class="main">
        <div class="container">
            <div class="row">
               
                    <div class="honeycombs">
                        <div class="comb">
                            <img src="../images/picture_0.jpg" />
                            <span>jQueryScript.Net</span> </div>
                        <div class="comb">
                            <img src="../images/picture_1.jpg" />
                            <span>
                                <b>This is</b><br>
                                a test
                            </span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_2.jpg" />
                            <span>
                                <b>This is</b><br>
                                a test
                            </span>
                        </div>
                        <div class="comb">
                            <img src="../images/picture_3.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_4.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_0.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_1.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_2.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_3.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_4.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_0.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_1.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_2.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_3.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_4.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_0.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_1.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_2.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_3.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_4.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_2.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_3.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_4.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_0.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_4.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_0.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_1.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_2.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_4.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_0.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_1.jpg" />
                        </div>
                        <div class="comb">
                            <img src="../images/picture_2.jpg" />
                        </div>
                    </div>
                
            </div>
        </div>
    </div>
    
    <script src="../libs/homeycombs/js/jquery.homeycombs.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.honeycombs').honeycombs({
                combWidth: 180,  // width of the hexagon
                margin: 4,      // spacing between hexagon
                threshold: 3    // hide placeholder hexagons when number of hexagons in a row is more than the threshold number
            });
        });
    </script>
</asp:Content>

