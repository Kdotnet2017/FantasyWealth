using System;
using System.ComponentModel.DataAnnotations;
using FantasyWealth.Areas.Identity.Data;

namespace FantasyWealth.Models
{
    public class Trade
    {
        [Key]
        public int Id { get; set; }
         [Required]
        [StringLength(450)]
        public string UserId { get; set; }
         [Required]
        [StringLength(15)]
        public string TickerSymbol { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int TradeType { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public string Reserved { get; set; }
        //relationships  between the following entities
        public FantasyWealthUser User { get; set; }
        public Transaction Transaction { get; set; }

    }
}