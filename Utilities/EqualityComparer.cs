using System;
using FantasyWealth.Models;
using System.Collections.Generic;

namespace FantasyWealth.Utilities
{
    public class SymbolEqualityComparer : IEqualityComparer<TickerSymbol>
    {
        public bool Equals(TickerSymbol x, TickerSymbol y)
        {
            if (x.Symbol.ToLower().Trim() == y.Symbol.ToLower().Trim() &&
                        x.Name.ToLower().Trim() == y.Name.ToLower().Trim() &&
                        x.isEnabled == y.isEnabled)
            { return true; }

            return false;
        }

        public int GetHashCode(TickerSymbol obj)
        {
            return obj.GetHashCode();
        }
    }
    public class SymbolNewRecordComparer : IEqualityComparer<TickerSymbol>
    {
        public bool Equals(TickerSymbol x, TickerSymbol y)
        {
            if (x.Symbol.ToLower().Trim() == y.Symbol.ToLower().Trim())
            { return true; }
            else
            {
                return false;
            }
        }

        public int GetHashCode(TickerSymbol obj)
        {
            return obj.GetHashCode();
        }
    }
}