//using HtmlAgilityPack;
//using RestSharp;

//var client = new RestClient("https://www.sahibinden.com/");
//var request = new RestRequest(Method.Get.ToString());
//request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.54 Safari/537.36");
//request.AddHeader("Cookie", "vid=227; cdid=1HNaPzID8weTrUXA62151281; MS1=https://www.google.com/; showPremiumBanner=false; nwsh=std; OptanonAlertBoxClosed=2022-02-22T16:44:05.389Z; h28s1ZLRQ2=A1Le6X5_AQAANgHhow1JUGmBLLjpCG8_QGTq2fdRKsg-LBAC0FAaQ26QRDu4AV56IQuucpMswH8AAEB3AAAAAA|1|0|77e4a3dad4e5106db5394fb4cc3ec163d3728027; h28s1ZLRQ2=A1Le6X5_AQAANgHhow1JUGmBLLjpCG8_QGTq2fdRKsg-LBAC0FAaQ26QRDu4AV56IQuucpMswH8AAEB3AAAAAA|1|0|77e4a3dad4e5106db5394fb4cc3ec163d3728027; rememberedUserName=cmkskn12; st=b777992bafc9648b399fd6a35551eb58d3e0753e00b2a8e7dc3cdc78a919b0492eef0470c329d6451e1fc33d83e25133946585155f6974e31; acc_type=bireysel_uye; kno=albJcyKVB3veXw_Oh1pSZsA; priceHistorySplashClosed=true; xsrf-token=014703653a2287ad634f3db42a229427982283ba; SL_G_WPT_TO=tr; SL_wptGlobTipTmp=1; SL_GWPT_Show_Hide_tmp=1; pasuid=8e5b3abd64e942b3b5e0557526979eb2; myPriceHistorySplashClosed=1; dp=1920*1080-landscape; geoipCity=istanbul; geoipIsp=turknet; gcd=20220509204225; MDR=20160223; lastVisit=20220509; userType=yeni_bireysel; shuid=co9thOAeMBqSTO3pYjUQGdg; dopingPurchase=false; getPurchase=false; OptanonConsent=isGpcEnabled=0&datestamp=Mon+May+09+2022+20:52:36+GMT+0300+(GMT+03:00)&version=6.22.0&isIABGlobal=false&hosts=&consentId=55faad8a-bb27-494e-aeec-13aa46916566&interactionCount=2&landingPath=NotLandingPage&groups=C0001:1,C0004:1&AwaitingReconsent=false&geolocation=;; cdid=9HhbhkjxnoTFRpmf6279194c; st=a9728905edf9e47d0ab8f4fb42b47bc098f594ab40c1a82884b8d3a9c012fd664d020cf1fd11325e0a6be82602961451dd9763708bbe6040d; vid=31");
//request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
//request.AddHeader("Accept-Encoding", "gzip, deflate, br");
//request.AddHeader("Accept-Language", "tr-TR,tr;q=0.9,en-US;q=0.8,en;q=0.7");
//var response = await client.ExecuteAsync(request);
//Console.WriteLine(response.Content);



//string html = client.DownloadStreamAsync();
//HtmlDocument document = new();
//document.OptionFixNestedTags = true;
//document.LoadHtml(html);


//want to get the title site of the URL 
//want to get canceled classes information site of the URL 
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

var urlstring = "https://www.ead.tut.ac.jp/board/main.aspx";

//Get HTML for the specified site stream 
var doc = default(IHtmlDocument);
using (var client = new HttpClient())
using (var stream = await client.GetStreamAsync(new Uri(urlstring)))
{

    //to parse the HTML to AngleSharp.Parser.Html.HtmlParser object 

    var parser = new HtmlParser();

    doc = await parser.ParseDocumentAsync(stream);
}



//Get the class cancellation information table portions specifying a query selector 
var items = doc.QuerySelectorAll("#grvCancel > tr")

   .Skip(1)

   .Select(item =>

   {

       a//td units plurality of data get to 

       var data = item.GetElementsByTagName("td");



        //class cancellations Date 

        var date = data[1].TextContent;



        //timed 

        var period = data[2].TextContent;



        //The name of the class 

        var subject = data[3].TextContent;



       return new { Date = date, Period = period, Subject = subject };

   });



//outputs the acquired canceled classes information 
items.ToList().ForEach(item =>
{

    Debug.WriteLine("${item.Date}({item.Period}) {item.Subject}");
});
