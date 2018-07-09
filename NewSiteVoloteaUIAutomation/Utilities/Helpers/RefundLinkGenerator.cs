
using System;
using System.Security.Cryptography;
using System.Text;
using VoloteaUIAutomation.Utilities.Configurations;

namespace VoloteaUIAutomation.Utilities.Helpers
{
    public class RefundLinkGenerator
    {
        public string GetMd5Hash(string surname, string name)
        {
            MD5 md5Hash = MD5.Create();
   
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(surname + "," + name));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }


        public string CreatRefundLink(string surname, string name, string email, string rlocator)
        {
            string md5HashCode = GetMd5Hash(surname, name);
            string base64Input = "email=" + email + "&recordlocator=" + rlocator + "&hash=" + md5HashCode;
            string base64Encode = Base64Encode(base64Input);

            string url = TestConfiguration.PageMainUrl;

            return url + "RefundConfirmation.aspx?id=" + base64Encode;
        }

        public string CreatMoveFlightsLink(string surname, string name, string email, string rlocator)
        {
            string md5HashCode = GetMd5Hash(surname, name);
            string base64Input = "email=" + email + "&recordlocator=" + rlocator + "&hash=" + md5HashCode;
            string base64Encode = Base64Encode(base64Input);

            string url = TestConfiguration.PageMainUrl;

            return url + "MoveFlights.aspx?id=" + base64Encode;
        }
    }
}
