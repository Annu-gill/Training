using System;
using System.Collections.Generic;
using System.Linq;

// ================= BASE =================
public interface IFinancialInstrument
{
    string Symbol { get; }
    decimal CurrentPrice { get; }
    InstrumentType Type { get; }
}

public enum InstrumentType { Stock, Bond, Option, Future }
public enum Trend { Upward, Downward, Sideways }

// ================= 1. GENERIC PORTFOLIO =================
public class Portfolio<T> where T : IFinancialInstrument
{
    private Dictionary<T, int> _holdings = new();

    public void Buy(T instrument, int quantity, decimal price)
    {
        if (quantity <= 0 || price <= 0)
            throw new ArgumentException("Invalid quantity or price");

        if (!_holdings.ContainsKey(instrument))
            _holdings[instrument] = 0;

        _holdings[instrument] += quantity;

        Console.WriteLine($"Bought {quantity} of {instrument.Symbol} at {price}");
    }

    public decimal? Sell(T instrument, int quantity, decimal currentPrice)
    {
        if (!_holdings.ContainsKey(instrument) || _holdings[instrument] < quantity)
        {
            Console.WriteLine("Not enough quantity to sell.");
            return null;
        }

        _holdings[instrument] -= quantity;

        if (_holdings[instrument] == 0)
            _holdings.Remove(instrument);

        decimal proceeds = quantity * currentPrice;
        Console.WriteLine($"Sold {quantity} of {instrument.Symbol}, Proceeds: {proceeds}");

        return proceeds;
    }

    public decimal CalculateTotalValue()
    {
        return _holdings.Sum(h => h.Key.CurrentPrice * h.Value);
    }

    public Dictionary<T, int> GetHoldings() => _holdings;

    public (T instrument, decimal returnPercentage)? GetTopPerformer(
        Dictionary<T, decimal> purchasePrices)
    {
        if (!purchasePrices.Any()) return null;

        var returns = new List<(T, decimal)>();

        foreach (var h in _holdings)
        {
            if (!purchasePrices.ContainsKey(h.Key)) continue;

            decimal purchase = purchasePrices[h.Key];
            decimal current = h.Key.CurrentPrice;

            decimal percent = ((current - purchase) / purchase) * 100;
            returns.Add((h.Key, percent));
        }

        if (!returns.Any()) return null;

        return returns.OrderByDescending(r => r.Item2).First();
    }
}

// ================= 2. SPECIALIZED INSTRUMENTS =================
public class Stock : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Stock;
    public string CompanyName { get; set; }
    public decimal DividendYield { get; set; }
}

public class Bond : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Bond;
    public DateTime MaturityDate { get; set; }
    public decimal CouponRate { get; set; }
}

// ================= 3. TRADING STRATEGY =================
public class TradingStrategy<T> where T : IFinancialInstrument
{
    public void Execute(Portfolio<T> portfolio,
        IEnumerable<T> marketData,
        Func<T, bool> buyCondition,
        Func<T, bool> sellCondition)
    {
        foreach (var instrument in marketData)
        {
            if (buyCondition(instrument))
                portfolio.Buy(instrument, 10, instrument.CurrentPrice);

            if (sellCondition(instrument))
                portfolio.Sell(instrument, 5, instrument.CurrentPrice);
        }
    }

    public Dictionary<string, decimal> CalculateRiskMetrics(IEnumerable<T> instruments)
    {
        var prices = instruments.Select(i => i.CurrentPrice).ToList();

        if (!prices.Any())
            return new Dictionary<string, decimal>();

        decimal avg = prices.Average();
        decimal variance = prices.Sum(p => (p - avg) * (p - avg)) / prices.Count;
        decimal volatility = (decimal)Math.Sqrt((double)variance);

        // Demo simplified metrics
        return new Dictionary<string, decimal>
        {
            { "Volatility", volatility },
            { "Beta", volatility / 10 }, 
            { "SharpeRatio", avg == 0 ? 0 : avg / volatility }
        };
    }
}

// ================= 4. PRICE HISTORY =================
public class PriceHistory<T> where T : IFinancialInstrument
{
    private Dictionary<T, List<(DateTime, decimal)>> _history = new();

    public void AddPrice(T instrument, DateTime timestamp, decimal price)
    {
        if (!_history.ContainsKey(instrument))
            _history[instrument] = new List<(DateTime, decimal)>();

        _history[instrument].Add((timestamp, price));
    }

    public decimal? GetMovingAverage(T instrument, int days)
    {
        if (!_history.ContainsKey(instrument)) return null;

        var recent = _history[instrument]
            .OrderByDescending(p => p.Item1)
            .Take(days)
            .Select(p => p.Item2);

        if (!recent.Any()) return null;

        return recent.Average();
    }

    public Trend DetectTrend(T instrument, int period)
    {
        if (!_history.ContainsKey(instrument)) return Trend.Sideways;

        var data = _history[instrument]
            .OrderByDescending(p => p.Item1)
            .Take(period)
            .Select(p => p.Item2)
            .ToList();

        if (data.Count < 2) return Trend.Sideways;

        if (data.First() > data.Last()) return Trend.Upward;
        if (data.First() < data.Last()) return Trend.Downward;

        return Trend.Sideways;
    }
}

// ================= 5. TEST SCENARIO =================
class Program
{
    static void Main()
    {
        var portfolio = new Portfolio<IFinancialInstrument>();
        var strategy = new TradingStrategy<IFinancialInstrument>();
        var history = new PriceHistory<IFinancialInstrument>();

        // Instruments
        var s1 = new Stock { Symbol = "TCS", CurrentPrice = 3500, CompanyName = "TCS" };
        var s2 = new Stock { Symbol = "INFY", CurrentPrice = 1500, CompanyName = "Infosys" };
        var b1 = new Bond { Symbol = "GOVT10Y", CurrentPrice = 102, CouponRate = 7 };

        var market = new List<IFinancialInstrument> { s1, s2, b1 };

        // Strategy: Buy undervalued, sell expensive
        strategy.Execute(
            portfolio,
            market,
            buyCondition: i => i.CurrentPrice < 2000,
            sellCondition: i => i.CurrentPrice > 3000
        );

        // Portfolio value
        Console.WriteLine("\nTotal Portfolio Value: " + portfolio.CalculateTotalValue());

        // Price history
        history.AddPrice(s1, DateTime.Now.AddDays(-3), 3200);
        history.AddPrice(s1, DateTime.Now.AddDays(-2), 3300);
        history.AddPrice(s1, DateTime.Now.AddDays(-1), 3400);
        history.AddPrice(s1, DateTime.Now, 3500);

        Console.WriteLine("\nMoving Average TCS: " + history.GetMovingAverage(s1, 3));
        Console.WriteLine("Trend TCS: " + history.DetectTrend(s1, 3));

        // Risk metrics
        var risk = strategy.CalculateRiskMetrics(market);
        Console.WriteLine("\nRisk Metrics:");
        foreach (var r in risk)
            Console.WriteLine($"{r.Key}: {r.Value}");

        // Performance
        var purchase = new Dictionary<IFinancialInstrument, decimal>
        {
            { s1, 3000 },
            { s2, 1200 }
        };

        var top = portfolio.GetTopPerformer(purchase);
        if (top != null)
            Console.WriteLine($"\nTop Performer: {top?.instrument.Symbol} {top?.returnPercentage}%");
    }
}
