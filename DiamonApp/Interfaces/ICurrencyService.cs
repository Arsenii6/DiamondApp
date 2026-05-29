namespace DiamondApp.Interfaces
{
    public interface ICurrencyService
    {
        string CurrencyCode { get; }
        string CurrencySymbol { get; }
        double RateToRub { get; }
        string RateText { get; }

        void Update(string code, double rateToRub, string rateText);
        decimal Convert(decimal rubAmount);
        string Format(decimal rubAmount);
        Task<(double rate, string text)> FetchRateAsync(string currencyCode);
    }
}