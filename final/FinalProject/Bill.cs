﻿namespace FinalProject;

public class Bill
{
    private Account _account;
    private DateTime _billDate;


    public Bill(Account account)
    {
        _account = account;
        _billDate = DateTime.Now;
    }

    public void SendBill(Transaction transaction, EmailMaker emailMaker)
    {
        
    }
}