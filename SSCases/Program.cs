

//using System.Net;

//string adress = "https://www.sahibinden.com/";
//WebRequest request = HttpWebRequest.Create(adress);
//WebResponse response = request.GetResponse();

//StreamReader streamReader = new StreamReader(response.GetResponseStream());
//string data = streamReader.ReadToEnd();
//int startTag = data.IndexOf("<ul class=\"vitrin-list clearfix\">");
//int endTag = data.Substring(startTag).IndexOf("<ul>");
//string tag = data.Substring(startTag, endTag);
//Console.WriteLine(tag);


using HtmlAgilityPack;
using System.Net;
using System.Text;

Uri url = new Uri("https://www.sahibinden.com/");
//Uri url = new Uri("https://onedio.com/");

WebClient client = new();
client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.54 Safari/537.36");
client.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
client.Headers.Add("Cookie", "vid=227; cdid=1HNaPzID8weTrUXA62151281; MS1=https://www.google.com/; showPremiumBanner=false; nwsh=std; OptanonAlertBoxClosed=2022-02-22T16:44:05.389Z; h28s1ZLRQ2=A1Le6X5_AQAANgHhow1JUGmBLLjpCG8_QGTq2fdRKsg-LBAC0FAaQ26QRDu4AV56IQuucpMswH8AAEB3AAAAAA|1|0|77e4a3dad4e5106db5394fb4cc3ec163d3728027; h28s1ZLRQ2=A1Le6X5_AQAANgHhow1JUGmBLLjpCG8_QGTq2fdRKsg-LBAC0FAaQ26QRDu4AV56IQuucpMswH8AAEB3AAAAAA|1|0|77e4a3dad4e5106db5394fb4cc3ec163d3728027; rememberedUserName=cmkskn12; st=b777992bafc9648b399fd6a35551eb58d3e0753e00b2a8e7dc3cdc78a919b0492eef0470c329d6451e1fc33d83e25133946585155f6974e31; acc_type=bireysel_uye; kno=albJcyKVB3veXw_Oh1pSZsA; priceHistorySplashClosed=true; xsrf-token=014703653a2287ad634f3db42a229427982283ba; SL_G_WPT_TO=tr; SL_GWPT_Show_Hide_tmp=1; SL_wptGlobTipTmp=1; pasuid=8e5b3abd64e942b3b5e0557526979eb2; myPriceHistorySplashClosed=1; geoipCity=istanbul; geoipIsp=turknet; gcd=20220509204225; MDR=20160223; lastVisit=20220509; userType=yeni_bireysel; shuid=co9thOAeMBqSTO3pYjUQGdg; dopingPurchase=false; getPurchase=false; dp=1920*1080-landscape; OptanonConsent=isGpcEnabled=0&datestamp=Mon+May+09+2022+21:37:56+GMT+0300+(GMT+03:00)&version=6.22.0&isIABGlobal=false&hosts=&consentId=55faad8a-bb27-494e-aeec-13aa46916566&interactionCount=2&landingPath=NotLandingPage&groups=C0001:1,C0004:1&AwaitingReconsent=false&geolocation=;");
//client.Headers.Add("Accept-Encoding", "gzip, deflate, br");
client.Headers.Add("Accept-Language", "tr-TR,tr;q=0.9,en-US;q=0.8,en;q=0.7");

string html = client.DownloadString(url);
HtmlDocument document = new();
document.OptionOutputAsXml = true;
document.OptionFixNestedTags = true;
document.LoadHtml(html);

var listData = new List<string>();

//HtmlNodeCollection titles = document.DocumentNode.SelectNodes(@"//*[@id=""container""]/div[3]/div/div[3]/div[3]/ul");
HtmlNodeCollection nodeCollection = document.DocumentNode.SelectNodes(@"//*[@id=""container""]/div[3]/div/div[3]/div[3]/ul");

foreach (var nodes in nodeCollection)
{
    var link = nodes.ChildNodes["li"];
    listData.Add(nodes.InnerHtml);
    //Console.WriteLine(listData);
    //var chld = title.ChildNodes["a"].Attributes["href"].Value;
    //Console.WriteLine(chld);
}
int i = 1;
foreach (var list in listData)
{
    Console.WriteLine($"{i} : {list}");
    i++;
}
Console.Write("Please select an item for details: ");
int selectedItem = Convert.ToInt32(Console.ReadLine());
var smt = selectedItem.ToString();

if (smt == listData[selectedItem])
{

}

Console.WriteLine(listData[selectedItem]);

//*[@id="container"]/div[3]/div/div[3]/div[3]/ul/li[1]
//*[@id="container"]/div[3]/div/div[3]/div[3]/ul/li[2]

