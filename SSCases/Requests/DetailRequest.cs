using HtmlAgilityPack;
using SSCases.RequestHeaders;
using System.Net;

namespace SSCases.Requests
{
    public class DetailRequest
    {
        public HtmlDocument DetailConnection(string selectedItem)
        {
            Uri detailUrl = new Uri(RequestHeader.BaseUrl + selectedItem);
            WebClient client = new();

            //client headers added because if you dont use headers, the page will see it as a robot.
            client.Headers.Add("User-Agent", RequestHeader.UserAgent);
            client.Headers.Add("Accept", RequestHeader.Accept);
            client.Headers.Add("Cookie", RequestHeader.Cookie);
            client.Headers.Add("Accept-Language", RequestHeader.AcceptLanguage);

            //download all html text
            string html = client.DownloadString(detailUrl);
            HtmlDocument document = new();
            document.LoadHtml(html);

            //return html values
            return document;
        }
    }
}
