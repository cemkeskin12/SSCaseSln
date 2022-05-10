using HtmlAgilityPack;
using SSCases.Entities;
using SSCases.Requests;
using SSCases.Services;

var showCaseRequest = new ShowCaseRequest();
var detailRequest = new DetailRequest();
var setPriceFormat = new SetPriceFormat();

var itemList = new List<Item>();
var priceList = new List<int>();

#region All show case lists.

//find nodes in div class = uiBox showcase inside ul/li

HtmlNodeCollection nodeCollection = showCaseRequest.UrlConnection().DocumentNode.SelectNodes(@"//div[@class=""uiBox showcase""]/ul/li");
int i = 1;
foreach (var nodes in nodeCollection)
{
    itemList.Add(new Item()
    {
        //loop for auto id.
        Id = i,
        //the texts in a tags.
        Name = nodes.ChildNodes["a"].InnerText,
        //Urls in a on the href attribute.
        DetailUrl = nodes.ChildNodes["a"].Attributes["href"].Value
    });
    i++;
}
//list all showcase values without spaces (the trim was used for this)
foreach (var item in itemList)
    if (item.Name != null)
        Console.WriteLine(item.Id + ":" + item.Name.Trim());

#endregion


Console.Write("Please select an item for details or enter ['-1'] for average all product prices: ");
var selectedItem = Convert.ToInt32(Console.ReadLine());

#region List all prices and calculate averages
//an item selected in Item list. If selected value "-1", the program will list all showcase prices and its averaging.
if (selectedItem == -1)
{
    switch (selectedItem.ToString())
    {
        //when the value is -1
        case "-1":
            //I'm listing the first 10 because the server is banned.
            for (int y = 0; y < 10; y++)
            {
                HtmlNodeCollection nodeCollectionForPriceAverages = detailRequest.DetailConnection(itemList[y].DetailUrl).DocumentNode.SelectNodes(@"//div[@class=""classifiedInfo ""]/h3");
                if (nodeCollectionForPriceAverages != null)
                {
                    foreach (var details in nodeCollectionForPriceAverages)
                    {
                        int intPrice = 0;
                        var price = details.InnerHtml.Trim();
                        var newPrice = setPriceFormat.SetPrice(price);
                        Console.WriteLine($"Fiyat : {newPrice} TL");
                        //checks if the price in the showcase is in dollars.
                        var successed = Int32.TryParse(newPrice, out intPrice);
                        if (successed)
                        {
                            priceList.Add(intPrice);

                        }
                        Task.Delay(1000).Wait();

                    }
                }
            }
            AveragePrice averagePriceCalculator = new AveragePrice();
            averagePriceCalculator.Calculate($"Average Price : {priceList.Average()}");
            break;
    }

}
#endregion


//select an item in Item list by selected value
if (selectedItem == -1)
{
    goto endProject;
    
}
var firstItem = itemList.ElementAt(selectedItem - 1);
Console.WriteLine(firstItem.Name.Trim());


#region List all details by selected items.

//Get all details selected item's detail url.
HtmlNodeCollection nodeCollectionForPriceDetail = detailRequest.DetailConnection(firstItem.DetailUrl).DocumentNode.SelectNodes(@"//div[@class=""classifiedInfo ""]");
if (nodeCollectionForPriceDetail != null)
{
    foreach (var details in nodeCollectionForPriceDetail)
    {
        var price = details.ChildNodes["h3"].InnerText.Trim();
        var newPrice = setPriceFormat.SetPrice(price);
        Console.WriteLine($"Fiyat : {newPrice} TL");

        var allDetails = details.SelectNodes("ul/li");
        if (allDetails != null)
        {
            foreach (var item in allDetails)
            {
                if(item.ChildNodes["strong"] != null)
                {
                    Console.WriteLine(item.ChildNodes["strong"].InnerText.Trim() + item.ChildNodes["span"].InnerText.Trim());

                }
            }
        }
    }
}

#endregion

endProject:

Console.ReadKey();