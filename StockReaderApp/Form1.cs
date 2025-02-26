using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockReaderApp
{
    public partial class Form1 : Form
    {
        private DateTime? StartingDate;                   //These variables are declared in a global scope since I  need to use them in a different function   
        private DateTime? EndingDate;                     //The ? is so that the variables are nullable

        


        Stockreader stockreader;                                            //A variable of the type Stockreader will be needed in multiple classes. This is why it is declared globally.
        List<Candlestick> filteredsticks = new List<Candlestick>();          //The list filteredsticks is instantialized in a global scope.

        public Form1()
        {
            InitializeComponent();
            stockreader = new Stockreader();                                //A new stockreader is instancialized

        }

        private void button1_loadData_Click(object sender, EventArgs e)                ///The eventhandler for button1
        {
            openFileDialog_loadData.ShowDialog();                           //When the load button is clicked, the openFiledialog appears







        }

        private void openFileDialog_loadData_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

            string filePath = openFileDialog_loadData.FileName;                 //The filename that is selected is stored in the string variable filepath

            List<Candlestick> candlesticks = stockreader.ReadCandlesticksFromCsv(filePath);                    //Using the stockreader, we read the data provided in the csv file. We then store it in a list of candlesticks.

            var filtered = from candlestick in candlesticks                                                     //The var variable reads the candlestick data of type IEnumerable<Candlestick> and stores it
                           where candlestick.Date >= StartingDate && candlestick.Date <= EndingDate             //Using LINQ, we find the data from starting date to end date
                           select candlestick;

            filteredsticks = filtered.ToList();                                                   //filtered is converted to a list


            dataGridView1.DataSource = filteredsticks;                                          //The filteredsticks list is binded with the dataGridView as a datasource

            DisplayStock(filteredsticks);                                                       //The filetered sticks is passed to DisplayStock for the chart. Thus, The chart uses the same candlesticks as the datagridview

            //string[] files = openFileDialog_loadData.FileNames;



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)           ///The eventhandler for the Stating dateTime picker
        {
            StartingDate = dateTimePicker1.Value.Date;                  //The variable StartingDate was declared earlier. The picked date is stored here.

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)              ///The eventhandler for the Ending dateTime picker
            {
            EndingDate = dateTimePicker2.Value.Date;                    //Similar to StartingDate
        }

        private void normalizeChart(List<Candlestick> candlesticks)                                     ///A chart Normalizer function to use maximum range of the chart
        { 
            double minPrice = candlesticks.Where(c => c.Low.HasValue).Select(c => c.Low.Value).DefaultIfEmpty(0).Min();        //Minimum, Maximum and Maxvolume values are found from the list of candlesticks
            double maxPrice = candlesticks.Where(c => c.High.HasValue).Select(c => c.High.Value).DefaultIfEmpty(0).Max();           //DefaultIfEmpty is used for list entries that do not have a value for High, Low or Volume. 0 is assigned by default. 
            double maxVolume = candlesticks.Where(c => c.Volume.HasValue).Select(c => c.Volume.Value).DefaultIfEmpty(0).Max();      // The first arrow functions ensure that these are only processes when the values are present and the second arrow functions return the value of each candlestick.

            chart_ShowData.ChartAreas["ChartArea_OHLC"].AxisY.Minimum = Math.Floor((minPrice * 0.98));          //The 98% of the minimum price is rounded down so that the lowest part of the chart is below the minimum price
            chart_ShowData.ChartAreas["ChartArea_OHLC"].AxisY.Maximum = Math.Ceiling(maxPrice * 1.02);          //Similarly, 102% of the maximum price is taken and rounded up.


        }

        public void DisplayStock(List<Candlestick> candlesticks)                            ///This is the function that takes the list of candlesticks (we pass the filteredsticks to it) and displays the visualization in a chart and a column.
        {
            

            chart_ShowData.Series.Clear();                                   //Clear all series data 

            Series series = new Series("Candlesticks")                       //Create new instance of a series of Candlesticks
            {
                ChartType = SeriesChartType.Candlestick,                        // The series is of chartType Candlestick since we are displaying candlesticks




                XValueType = ChartValueType.DateTime                                //The X axis is specified to be of type DateTime
            };

            series["Open"] = "1";                                                  //The Y values of the chart are mapped to values in series.
            series["High"] = "2";
            series["Low"] = "3";
            series["Close"] = "4";

            ChartArea chartArea = chart_ShowData.ChartAreas["ChartArea_OHLC"];              //the variable of type ChartArea stores a reference to teh CharArea "ChartArea_OHLC"
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;                  //Dashes are added to each axis in the chart from ChartDashStyle
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;           //Colour of the lines of both axes
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea.Position.Height = 65;                     //The height of ChartArea is 65 so that the columns are 

            chart_ShowData.Series.Add(series);                  //The series is added to the chart to be displayed
            normalizeChart(candlesticks);                       //NormalizeChart adjusts the values of the chart for using max range

            

           

           

            ChartArea chartArea_Volume = new ChartArea("ChartArea_Volume");       //Another instance of ChartArea for displaying the volume part
            chartArea_Volume.AlignWithChartArea = "ChartArea_OHLC";               //Aligned with the main chart
             
            
            chartArea_Volume.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;       //The grid is similarly customized for ChartArea for the volume
            chartArea_Volume.Position.Y = 65;                                           //The position of the ChartArea_Volume is also adjusted to fit with the Candlestick chart
            chartArea_Volume.Position.Height = 35;

            chart_ShowData.ChartAreas.Add(chartArea_Volume);                            //The ChartArea for volume is added to the chart

            Series seriesVolume = new Series("Volume")                                  //A new series is created to add the volumes to be displayed in the chart
            {
                ChartType = SeriesChartType.Column,                                     //Chart type is specified
                XValueType = ChartValueType.DateTime,                                   //The x axis value type is specified
                ChartArea = "ChartArea_Volume",                                         //ChartArea is chosen
                Color = Color.Blue                                                      //Color of the columns
            };

            chart_ShowData.Series.Add(seriesVolume);                                  //The series is added to the charArea

            foreach (var candle in candlesticks)                                        //A for loop going through each element in the list of candlesticks
            {   
                if (candle.Date.HasValue)                                               //Ensures that a datapoint is created only if the element in non null
                {
                    DataPoint dp = new DataPoint                                            //New datapoint is created 
                    {
                        XValue = candle.Date.Value.ToOADate()                           //The date value is converted for chart use
                    };
                    dp.YValues = new double[] { (double)candle.Open, (double)candle.High, (double)candle.Low, (double)candle.Close };       //A new list of doubles is used to hold OHLC values after type casting them to double

                    if (candle.Close > candle.Open)         //This if statement determines the color of the candlesticks
                    {
                        dp.Color = System.Drawing.Color.Green;              
                    }
                    else
                    {
                        dp.Color = System.Drawing.Color.Red;
                    }
                    seriesVolume.Points.AddXY(candle.Date.Value, candle.Volume);            //Add the points to the chartArea Volume
                    series.Points.Add(dp);                                                  //Add the points to the charArea Candlesticks

                }
            }
        }


    }
}
