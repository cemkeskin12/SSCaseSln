using HtmlAgilityPack;
using SSCases.RequestHeaders;
using System.Net;

namespace SSCases.Requests
{
    public class ShowCaseRequest
    {
        public HtmlDocument UrlConnection()
        {
            Uri url = new Uri(RequestHeader.BaseUrl);

            WebClient client = new();

            //client headers added because if you dont use headers, the page will see it as a robot.
            client.Headers.Add("User-Agent", RequestHeader.UserAgent);
            client.Headers.Add("Accept", RequestHeader.Accept);
            client.Headers.Add("Cookie", RequestHeader.Cookie);
            client.Headers.Add("Accept-Language", RequestHeader.AcceptLanguage);

            //download all html tags in url
            string html = client.DownloadString(url);
            HtmlDocument document = new();
            document.LoadHtml(html);

            //return html document
            return document;
        }
    }
}
