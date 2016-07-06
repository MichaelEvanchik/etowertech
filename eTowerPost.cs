using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

public class eTowerPost
{

        public eTower.eTowerOrderRespone PostJsonETowerOrder(string smethod, object s, string path, string accept)
        {
            string wRespStatusCode = string.Empty;
            string responseText = string.Empty;
            bool bwaserror = false;
            string WALLTECH_SERVER = "http://qa-us.etowertech.com" + path;
            string ACCESS_TOKEN = "yourtoken";
            string SECRET_KEY = "yourkey";
            
            eTower.eTowerOrderRespone[] n = new eTower.eTowerOrderRespone[1];
            
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(s);

            var http = (HttpWebRequest)WebRequest.Create(new Uri(WALLTECH_SERVER));
            http.Accept = accept;
            http.ContentType = "application/json";
            http.Method = smethod;
            string walltech_date = DateTime.UtcNow.ToString("ddd, dd MMM yyyy HH:mm:ss") + " GMT";
            StringBuilder auth = new StringBuilder();
            auth.Append(smethod);
            auth.Append("\n");
            auth.Append(walltech_date);
            auth.Append("\n");
            auth.Append("http://qa-us.etowertech.com" + path);
     
            string hash = EncodeHMAC(auth.ToString(), Encoding.UTF8.GetBytes(SECRET_KEY));
            
            http.Headers.Add("X-WallTech-Date", walltech_date);
            http.Headers.Add("Authorization", "WallTech " + ACCESS_TOKEN + ':' + hash);

            http.KeepAlive = false;
            var encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(sJSON);

            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)http.GetResponse();
            }
            catch (WebException we)
            {
                wRespStatusCode = ((HttpWebResponse)we.Response).StatusCode.ToString();
                bwaserror = true;
                using (var reader = new System.IO.StreamReader(we.Response.GetResponseStream(), encoding))
                {
                    responseText = reader.ReadToEnd();
                    var sData = JsonConvert.DeserializeObject<List<eTower.eTowerOrderRespone>>(responseText);
                    n[0] = (eTower.eTowerOrderRespone)sData[0];
                }
            }

            if (bwaserror == false)
            {
                if (wRespStatusCode == "")
                {
                    wRespStatusCode = response.StatusCode.ToString();
                }

                using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                {
                    string data = reader.ReadToEnd();
                    var sData = JsonConvert.DeserializeObject<List<eTower.eTowerOrderRespone>>(data);
                    n[0] = (eTower.eTowerOrderRespone)sData[0];
                }
            }
            try
            {
                response.Close();
            }
            catch { }
            try
            {
                newStream.Dispose();
            }
            catch { }
            try
            {
                response.Dispose();
            }
            catch { }
            try
            {
                bytes = null;
            }
            catch { }

            return n[0];
        }
        
        private string EncodeHMAC(string input, byte[] key)
        {
            byte[] hashedValue;
            using (HMACSHA1 hmac = new HMACSHA1(key))
            {
                byte[] stringBytes = Encoding.UTF8.GetBytes(input);
                hashedValue = hmac.ComputeHash(stringBytes);
            }
            return Convert.ToBase64String(hashedValue);
        }
}
