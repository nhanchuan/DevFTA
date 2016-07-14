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
}