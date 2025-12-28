using System;

public class Account
{
    public string Name { get; set; }
    public int AccountId { get; set; }

    public string GetAccountDetails()
    {
        return $"I am Base account. My Id is {AccountId}";
    }
}

public class SalesAccount : Account
{
    public string GetSalesAccountDetails()
    {
        return base.GetAccountDetails() + " I am from Sales Derived class";
    }
}

public class PurchaseAccount : Account
{
    public string PurchaseInfo { get; set; }
}
