﻿namespace FinalProject;

public class Bank
{
    private readonly List<Customer> _customersList = new();

    public void AddCustomers(Customer customer)
    {
        _customersList.Add(customer);
    }

    public List<Customer> GetCustomersList => _customersList;

    private Account GetAccountByNumber(long accountNumber)
    {
        foreach (var customer in _customersList)
            if (customer.HasAccount)
            {
                var account = customer.GetCustomerAccount;
                if (account.GetAccountNumber == accountNumber) return account;
            }

        return null;
    }


    public Account FindCustomerByName(string holderName)
    {
        foreach (var customer in _customersList)
            if (customer.HasAccount)
            {
                var account = customer.GetCustomerAccount;
                if (account.GetAccountHolder.ToLower() == holderName.ToLower()) return account;
            }

        return null;
    }


    public void MakeTransfer(long senderAccountNumber, decimal amount, long receiverAccountNumber)
    {
        var sender = GetAccountByNumber(senderAccountNumber);
        if (sender == null) throw new InvalidAccountException("Sender account does not exist.");

        var receiver = GetAccountByNumber(receiverAccountNumber);
        if (receiver == null) throw new InvalidAccountException("Receiver account does not exist.");

        sender.Transfer(receiver, amount);
    }


    public void MakeWithdrawal(long accountNumber, decimal amount)
    {
        var account = GetAccountByNumber(accountNumber);
        if (account == null) throw new InvalidAccountException("Account with provided number does not exist.");

        account.Withdraw(amount);
    }


    public void MakeDeposit(long accountNumber, decimal amount)
    {
        var account = GetAccountByNumber(accountNumber);
        if (account == null) throw new InvalidAccountException("Account with provided number does not exist.");

        account.Deposit(amount);
    }


    public void DisplayTransactionHistory(long accountNumber)
    {
        var account = GetAccountByNumber(accountNumber);
        if (account == null) throw new InvalidAccountException("Account with provided number does not exist.");

        account.DisplayAlertHistory();
    }


    private class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) : base(message)
        {
        }
    }
}