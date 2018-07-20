using System;
using System.ComponentModel.DataAnnotations;
using FantasyWealth.Areas.Identity.Data;

namespace FantasyWealth.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }
        public int? TradeId { get; set; }
        public int TransactionType { get; set; }
        [StringLength(450)]
        public string FromAccount{get;set;}
        [StringLength(450)]
        public string ToAccount{get;set;}
        public decimal TotalAmount { get; set; }
        public string Comment { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Reconciled {get;set;}

        //relationships  between the following entities
        public FantasyWealthUser User { get; set; }
        public Trade Trade { get; set; }
    }
}