using System;
using System.ComponentModel.DataAnnotations;

namespace FantasyWealth.Models
{
    public class TickerSymbol
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Symbol { get; set; }
        public string Name { get; set; }
        public bool isEnabled { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate{get;set;}
    }
}