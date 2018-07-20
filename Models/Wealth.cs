using System;
using System.ComponentModel.DataAnnotations;
using FantasyWealth.Areas.Identity.Data;

namespace FantasyWealth.Models
{
    public class Wealth
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
        public DateTime CreattionDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        //relationships  between the following entities
        public FantasyWealthUser User { get; set; }
    }
}