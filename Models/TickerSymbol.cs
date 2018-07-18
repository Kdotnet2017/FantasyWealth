using System;
using System.ComponentModel.DataAnnotations;

namespace FantasyWealth.Models
{
    public class TickerSymbol
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Symbol { get; set; }
        public string Name { get; set; }
        public bool isEnabled { get; set; }
        public string Sector { get; set; }
        public int ExchangeTrader { get; set; }
        public DateTime Date { get; set; }
    }
    public enum ExchangeEnum{

    }
}