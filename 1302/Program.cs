using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

namespace _1302
{
    class Program
    {
        static void print(object a)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(a);
            Console.ResetColor();
        }

        static decimal dollar()
        {
            string data = string.Empty;
            string url = "https://www.cbr.ru/currency_base/daily/?UniDbQuery.Posted=True&UniDbQuery.To=";
            string html = string.Empty;
            string pattern = @"<td>Доллар США</td>
          <td>(.*)</td>";
            DateTime today = DateTime.Now;
            data = today.Date.ToShortDateString();
            url += data;
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            html = streamReader.ReadToEnd();
            Match match = Regex.Match(html, pattern);
            return Convert.ToDecimal(match.Groups[1].ToString());
        }

        static decimal euro()
        {
            string data = string.Empty;
            string url = "https://www.cbr.ru/currency_base/daily/?UniDbQuery.Posted=True&UniDbQuery.To=";
            string html = string.Empty;
            string pattern = @"<td>Евро</td>
          <td>(.*)</td>";
            DateTime today = DateTime.Now;
            data = today.Date.ToShortDateString();
            url += data;
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            html = streamReader.ReadToEnd();
            Match match = Regex.Match(html, pattern);
            return Convert.ToDecimal(match.Groups[1].ToString());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\aрублъ: ");
            try
            {
                decimal rub = decimal.Parse(Console.ReadLine());
                Console.WriteLine("доллор: " + decimal.Round(rub / dollar(), 4));
                Console.WriteLine("евро: " + decimal.Round(rub / euro(), 4));
            }
            catch
            {
                Exception exception = new Exception();
                Console.WriteLine(exception);
            }
            finally
            {
                print("доллар - "+dollar()+"\n");
                print("евро - "+euro());
            }
        }
    }
}
