using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Windows;


namespace ErrorHedging
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public PlotModel MyModel { get; private set; }

        private DateTime lastUpdate = DateTime.Now;

        
        public Window1()
        {
            MyModel = new PlotModel();
        }

        public void testPlot()
        {
            MyModel = LineSerieswithcustomTrackerFormatString();
        }

        public static PlotModel LineSerieswithcustomTrackerFormatString()
        {
            var plotModel1 = new PlotModel();
            plotModel1.Subtitle = "TrackerFormatString = \"X={2:0.0} Y={4:0.0}\"";
            plotModel1.Title = "LineSeries with custom TrackerFormatString";
            var linearAxis1 = new LinearAxis();
            linearAxis1.Position = AxisPosition.Bottom;
            plotModel1.Axes.Add(linearAxis1);
            var linearAxis2 = new LinearAxis();
            plotModel1.Axes.Add(linearAxis2);
            var lineSeries1 = new LineSeries();
            lineSeries1.TrackerFormatString = "X={2:0.0} Y={4:0.0}";
            lineSeries1.Points.Add(new DataPoint(0, 20));
            lineSeries1.Points.Add(new DataPoint(10, 21));
            lineSeries1.Points.Add(new DataPoint(20, 24));
            lineSeries1.Points.Add(new DataPoint(30, 22));
            lineSeries1.Points.Add(new DataPoint(40, 17));
            lineSeries1.Points.Add(new DataPoint(50, 21));
            lineSeries1.Points.Add(new DataPoint(60, 23));
            lineSeries1.Points.Add(new DataPoint(70, 27));
            lineSeries1.Points.Add(new DataPoint(80, 27));
            lineSeries1.Points.Add(new DataPoint(90, 22));
            lineSeries1.Points.Add(new DataPoint(100, 25));
            plotModel1.Series.Add(lineSeries1);
            return plotModel1;
        }
    }
}
