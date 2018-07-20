using System;

namespace FantasyWealth.Models
{
      public enum TransactionType{
        Transfer,
        Deposit,
        Credit,
        Debit,
        Withdraw
    }
    public enum TradeType{
        Sell,
        Buy
    }
    public enum Status{
        Pending,
        Processing,
        Approved,
        Cancelled,
        Disabled
    }
}