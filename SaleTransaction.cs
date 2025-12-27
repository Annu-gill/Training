namespace QuickMartTraders
{
    /// <summary>
    /// Represents a single sales transaction in QuickMart Traders.
    /// Stores details about the invoice, customer, item sold,
    /// quantities, pricing, and profit or loss calculation.
    /// </summary>
    public class SaleTransaction
    {
        public string InvoiceNo { get; set; }
        public string CustomerName { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal SellingAmount { get; set; }
        public string ProfitOrLossStatus { get; set; }
        public decimal ProfitOrLossAmount { get; set; }
        public decimal ProfitMarginPercent { get; set; }
    }
}
