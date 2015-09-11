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

namespace ErrorHedging
{
    class MainWindowViewModel : BindableBase
    {

        private ComponentInfo selectedComponent;
        public ObservableCollection<ComponentInfo> ComponentInfoList { get; private set; }
        public ICommand ClickCommand { get; private set; }
        public PlotModel MyModel { get; private set; }
        

        public ComponentInfo SelectedComponent
        {
            get { return selectedComponent; }
            set
            {
                SetProperty(ref selectedComponent, value);
                Console.WriteLine("Component " + selectedComponent.Name + " is selected");
            }
        }


        public MainWindowViewModel()
        {
            var listComp = GetComponents();
            ComponentInfoList = new ObservableCollection<ComponentInfo>(listComp);
            ClickCommand = new DelegateCommand(ExtractComponents);
            
            
        }

        

        private void SetUpModel()
        {
            MyModel = new PlotModel();
            MyModel.LegendTitle = "Legend";
            MyModel.LegendOrientation = LegendOrientation.Horizontal;
            MyModel.LegendPlacement = LegendPlacement.Outside;
            MyModel.LegendPosition = LegendPosition.TopRight;
            MyModel.LegendBackground = OxyColor.FromAColor(200, OxyColors.White);
            MyModel.LegendBorder = OxyColors.Black;

            var dateAxis = new DateTimeAxis(AxisPosition.Bottom, "Date", "dd/MM/yy HH:mm") { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, IntervalLength = 80 };
            MyModel.Axes.Add(dateAxis);
            var valueAxis = new LinearAxis(AxisPosition.Left, 0) { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Title = "Value" };
            MyModel.Axes.Add(valueAxis);
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

        private void ExtractComponents()
        {
            //foreach (var comp in ComponentInfoList)
            //{
            //    if (comp.IsSelected)
            //    {
            //        Console.WriteLine(comp.Name);
            //        Console.WriteLine(comp.Poids);
            //    }
            //}
            //Console.WriteLine(maturite);
            //Console.WriteLine(strikePrice);
            //Console.WriteLine(dateDebut);
            //Console.WriteLine(typeDonnees);
            //Console.WriteLine(dureeEstimation);
            //SetUpModel();
            //this.MyModel = new PlotModel { Title = "Example 1" };
            //this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            MyModel = new PlotModel();
            OxyPlot.Series.LineSeries courbe = new OxyPlot.Series.LineSeries();
            courbe.Points.Add(new OxyPlot.DataPoint(0, 1));
            courbe.Points.Add(new OxyPlot.DataPoint(0, 2));
            courbe.Points.Add(new OxyPlot.DataPoint(0, 1));
            MyModel.Series.Add(courbe);
            
        }

        private List<ComponentInfo> GetComponents()
        {
            return new List<ComponentInfo>()
            {
                new ComponentInfo() {Name = "Axa", IsSelected = false},
                new ComponentInfo() {Name = "Accor", IsSelected = false},
                new ComponentInfo() {Name = "Bnp", IsSelected = false},
                new ComponentInfo() {Name = "Vivendi", IsSelected = false},
                new ComponentInfo() {Name = "Dexia", IsSelected = false},
                new ComponentInfo() {Name = "Carrefour", IsSelected = false}
            };
        }



        private string _maturite;
        public string maturite
        {
            get { return _maturite; }
            set { SetProperty(ref _maturite, value); }
        }

            

        private string _strikePrice;
        public string strikePrice
        {
            get { return _strikePrice; }
            set { SetProperty(ref _strikePrice, value); }
        }


        private string _dateDebut;
        public string dateDebut
        {
            get { return _dateDebut; }
            set { SetProperty(ref _dateDebut, value); }
        }


        private string _typeDonnees;
        public string typeDonnees
        {
            get { return _typeDonnees; }
            set { SetProperty(ref _typeDonnees, value); }
        }


        private string _dureeEstimation;
        public string dureeEstimation
        {
            get { return _dureeEstimation; }
            set { SetProperty(ref _dureeEstimation, value); }
        }

    }
}




