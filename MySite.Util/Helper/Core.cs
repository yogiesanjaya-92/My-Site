using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace MySite.Util.Helper
{
    public class Core
    {
        public static void Disable_CertificateValidation(bool isDisable)
        {
            if (isDisable)
            {
                // Disabling certificate validation can expose you to a man-in-the-middle attack
                // which may allow your encrypted message to be read by an attacker
                // https://stackoverflow.com/a/14907718/740639
                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (
                        object s,
                        X509Certificate certificate,
                        X509Chain chain,
                        SslPolicyErrors sslPolicyErrors
                    )
                    {
                        return true;
                    };
            }
        }

        public static string getValueFromXML(string pathNode, string pathXML)
        {
            string valueFromXML = string.Empty;

            XmlDocument doc = new XmlDocument();
            doc.Load(pathXML);
            XmlNodeList nodeListPath = doc.SelectNodes(pathNode);
            XmlNode selectNode = nodeListPath.Cast<XmlNode>().FirstOrDefault();

            if (selectNode != null && selectNode.Attributes.Count < 1)
            {
                valueFromXML = selectNode.FirstChild.Value.Trim();
            }
            doc = null;
            return valueFromXML;
        }

        public static string createBase64StringFromStream(Stream FileStream, String FileContentType)
        {
            string fileBase64;
            using (Stream fs = FileStream)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.Position = 0;
                    fs.CopyTo(ms);
                    Byte[] fileByte = ms.ToArray();
                    fileBase64 = String.Format("data:{0};base64,{1}", FileContentType, Convert.ToBase64String(fileByte));
                }
            }
            return fileBase64;
        }

        public static DataTable AddObjectToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
