using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockReaderApp
{
    public class Candlestick            ///A class for the Candlestick object
    {
        public DateTime? Date { get; set; }             //The properties recieving and storing the values for OHLC
        public double? Open { get; set; }
        public double? Close { get; set; }
        public double? Volume { get; set; }
        public double? High { get; set; }

        public double? Low { get; set; }

        public Candlestick() { }            //Empty constructor

        public Candlestick( DateTime date, double open, double close, double high, double low, double volume)       ///Constructor function
        {
            Date = date;
            Open = open;
            Close = close; 
            Volume = volume;
            High = high;
            Low = low;
        }

        public override string ToString()           ///ToString method to convert to string
        {
            return $"{Date:yyyy-MM-dd} | Open: {Open}, High: {High}, Low: {Low}, Close: {Close}";   
        }
    }
}
