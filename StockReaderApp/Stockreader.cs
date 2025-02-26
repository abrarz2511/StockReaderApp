using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockReaderApp
{
    internal class Stockreader
    {
        public Stockreader() { }            //Constructor for stockreader

        public List<Candlestick> ReadCandlesticksFromCsv(string filepath)   ///The function to be used to read and filter data from csv file
        {
            List<Candlestick> candlesticks = new List<Candlestick>();           //A list of Candlesticks is initialized

            using (StreamReader sr = new StreamReader(filepath))                //StreamReader iterates through the file and reads one file at a time
            {
                string? line;                                           //Variable to store each line
                sr.ReadLine();     //skip the header line

                while ((line = sr.ReadLine()) != null)      //Until the reader reacher EOF
                {
                    string[] data = line.Split(',');        //Splits based on commas
                    string Date1 = data[0].Trim('"');       //The "" encircling the dates are removed

                    if (data.Length >= 6)   //If all the values are read in the line
                    {
                        
                        candlesticks.Add(new Candlestick                                        ///A candlestick instance
                        {
                            Date = DateTime.ParseExact(Date1 ,"yyyy-MM-dd", CultureInfo.InvariantCulture),                   //Dates are parsed based on the given format
                            Open = double.Parse(data[1]),                           //The OHLC values are parsed from the list of strings
                            High = double.Parse(data[2]),
                            Low = double.Parse(data[3]),
                            Close = double.Parse(data[4]),
                            Volume = double.Parse(data[5])

                        });
                    }
                }

                return candlesticks;            //List is returned
            }

        }
    }
}
