using System;
namespace FantasyWealth.Models
{
    public class ChartVM
    {
        public string date { get; set; }
        public decimal open { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal close { get; set; }
        public int volume { get; set; }
        public decimal unadjustedClose { get; set; }
        public int unadjustedVolume { get; set; }
        public decimal change { get; set; }
        public decimal changePercent { get; set; }
        public decimal vwap { get; set; }
        public string label { get; set; }
        public decimal changeOverTime { get; set; }
    }
}