using NUnit.Framework;
using System;

/// <summary>
/// Unit test class for testing deposit and withdrawal operations
/// of the bank account.
/// </summary>
[TestFixture]
public class UnitTest
{
    /// <summary>
    /// Tests whether depositing a valid amount
    /// correctly increases the account balance.
    /// </summary>
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        // Arrange: create account with initial balance
        Program account = new Program(1000);

        // Act: deposit a valid amount
        account.Deposit(500);

        // Assert: check updated balance
        Assert.AreEqual(1500, account.Balance);
    }

    /// <summary>
    /// Tests whether depositing a negative amount
    /// throws the expected exception.
    /// </summary>
    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        // Arrange: create account
        Program account = new Program(1000);

        // Assert: verify exception message
        Assert.AreEqual(
            "Deposit amount cannot be negative",
            Assert.Throws<Exception>(() => account.Deposit(-200)).Message
        );
    }

    /// <summary>
    /// Tests whether withdrawing a valid amount
    /// correctly decreases the account balance.
    /// </summary>
    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        // Arrange: create account with sufficient balance
        Program account = new Program(1000);

        // Act: withdraw a valid amount
        account.Withdraw(400);

        // Assert: check updated balance
        Assert.AreEqual(600, account.Balance);
    }

    /// <summary>
    /// Tests whether withdrawing more than the available balance
    /// throws the expected exception.
    /// </summary>
    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        // Arrange: create account
        Program account = new Program(500);

        // Assert: verify exception message
        Assert.AreEqual(
            "Insufficient funds.",
            Assert.Throws<Exception>(() => account.Withdraw(800)).Message
        );
    }
}
