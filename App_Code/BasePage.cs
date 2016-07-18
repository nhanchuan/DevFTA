using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Text;


/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void setcurenturl()
    {
        string url = "";
        url = Request.Url.AbsoluteUri;
        Session.SetCurrentURL(url);
    }
    //value Salt pasword
    protected string SaltPassword()
    {
        return "FTA@2d23";
    }
    //Create SHA-512 Hash string
    public static string CreateSHAHash(string Password, string Salt)
    {
        System.Security.Cryptography.SHA512Managed HashTool = new System.Security.Cryptography.SHA512Managed();
        Byte[] PasswordAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(Password, Salt));
        Byte[] EncryptedBytes = HashTool.ComputeHash(PasswordAsByte);
        HashTool.Clear();
        return Convert.ToBase64String(EncryptedBytes);
    }
    protected string RandomName
    {
        get
        {
            return new string(
                Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", 6)
                    .Select(s =>
                    {
                        var cryptoResult = new byte[6];
                        new RNGCryptoServiceProvider().GetBytes(cryptoResult);
                        return s[new Random(BitConverter.ToInt32(cryptoResult, 0)).Next(s.Length)];
                    })
                    .ToArray());
        }
    }
    public bool IsNumber(string pText)
    {
        Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
        return regex.IsMatch(pText);
    }
    protected ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FormatID == format.Guid)
            {
                return codec;
            }
        }
        return null;
    }
    //============================================================================================================

    /// <summary>
    /// Hiện thông báo
    /// </summary>
    /// <param name="isvalid">Bật/Tắt thông báo</param>
    /// <param name="validString">Chuỗi thông báo</param>
    /// <param name="divValid">Điều khiển html thông báo</param>
    /// <param name="lblvalid">Label nhận chuỗi thông báo</param>
    public void AlertPageValid(bool isvalid, string validString, System.Web.UI.HtmlControls.HtmlGenericControl divValid, Label lblvalid)
    {
        if (isvalid)
        {
            divValid.Attributes.Add("class", "alert alert-danger");
            lblvalid.Text = "<strong>Error!</strong>" + " " + validString.ToString();
        }
        else
        {
            divValid.Attributes.Add("class", "alert alert-danger display-none");
            lblvalid.Text = "";
        }
    }
    // LOAD DROPDOWNLIST()
    public void load_DropdownList(DropDownList dl, Object obj, string textfield, string valuefield)
    {
        dl.DataSource = obj;
        dl.DataTextField = textfield;
        dl.DataValueField = valuefield;
        dl.DataBind();
    }
    //=======================================================================

    /// <summary>
    /// Repeater Populate Page Event
    /// </summary>
    /// <param name="rptPager"> Populate </param>
    /// <param name="recordCount">Sum Record In Table</param>
    /// <param name="currentPage"></param>
    /// <param name="PageSize"></param>
    public void PopulatePager(Repeater rptPager, int recordCount, int currentPage, int PageSize)
    {
        List<ListItem> pages = new List<ListItem>();
        int startIndex, endIndex;
        int pagerSpan = 5;

        //Calculate the Start and End Index of pages to be displayed.
        double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
        endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
        if (currentPage > pagerSpan % 2)
        {
            if (currentPage == 2)
            {
                endIndex = 5;
            }
            else
            {
                endIndex = currentPage + 2;
            }
        }
        else
        {
            endIndex = (pagerSpan - currentPage) + 1;
        }

        if (endIndex - (pagerSpan - 1) > startIndex)
        {
            startIndex = endIndex - (pagerSpan - 1);
        }

        if (endIndex > pageCount)
        {
            endIndex = pageCount;
            startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
        }

        //Add the First Page Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("First", "1"));
        }

        //Add the Previous Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("<<", (currentPage - 1).ToString()));
        }

        for (int i = startIndex; i <= endIndex; i++)
        {
            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
        }

        //Add the Next Button.
        if (currentPage < pageCount)
        {
            pages.Add(new ListItem(">>", (currentPage + 1).ToString()));
        }

        //Add the Last Button.
        if (currentPage != pageCount)
        {
            pages.Add(new ListItem("Last", pageCount.ToString()));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }
    //========================================================================
}