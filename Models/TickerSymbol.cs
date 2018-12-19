using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using FantasyWealth.Models;

namespace FantasyWealth.Models
{
    public class TickerSymbol
    {
          public TickerSymbol()
        {
            this.UpdatedDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Symbol { get; set; }
        public string Name { get; set; }
        public bool isEnabled { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate{get;set;}
        public List<Wealth> Wealths { get; set; }
        public List<Trade> Trades { get; set; }
        public List<Offer> Offers { get; set; }
    }
}