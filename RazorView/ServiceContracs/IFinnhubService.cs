namespace RazorView.ServiceContracs;

public interface IFinnhubService
{
  Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
}
