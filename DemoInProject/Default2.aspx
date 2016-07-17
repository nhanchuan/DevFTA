<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="DemoInProject_Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="http://www.jqueryscript.net/css/jquerysctipttop.css" rel="stylesheet" type="text/css" />
 
    <link href="../css/frontend/homeycombs.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="honeycombs">
        <div class="comb"> <img src="../images/content/doanhnghiep/picture_0.jpg" /> <span>jQueryScript.Net</span> </div>
        <div class="comb">
            <img src="../images/content/doanhnghiep/picture_1.jpg" /> <span>
                <b>This is</b><br />
                a test
            </span>
        </div>
        <div class="comb">
            <img src="../images/content/doanhnghiep/picture_2.jpg" /> <span>
                <b>This is</b><br />
                a test
            </span>
        </div>
        <div class="comb"> <img src="../images/content/doanhnghiep/picture_3.jpg" /> </div>
        <div class="comb"> <img src="../images/content/doanhnghiep/picture_4.jpg" /> </div>
        <div class="comb"> <img src="../images/content/doanhnghiep/picture_0.jpg" /> </div>
        <div class="comb"> <img src="../images/content/doanhnghiep/picture_1.jpg" /> </div>
        <div class="comb"> <img src="../images/content/doanhnghiep/picture_2.jpg" /> </div>
        
        
    </div>

        <script src="../js/jquery.homeycombs.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.honeycombs').honeycombs({
                combWidth: 200,  // width of the hexagon
                margin: 2,      // spacing between hexagon
                threshold: 3    // hide placeholder hexagons when number of hexagons in a row is more than the threshold number
            });
        });
    </script>
    </form>
</body>
</html>
