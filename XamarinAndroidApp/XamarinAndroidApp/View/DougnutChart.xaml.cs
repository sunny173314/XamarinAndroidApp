using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microcharts;
using Entry = Microcharts.ChartEntry;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;

namespace XamarinAndroidApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DougnutChart : ContentPage
    {
        readonly List<Entry> entries = new List<Entry>()
        {
            new Entry(3)
            {
                Label = "windows", 
                ValueLabel = "3%",
                Color = SKColor.Parse("#2c3e50")
            },

            new Entry (55)
            {
                Label = "Android", 
                ValueLabel = "55%",
                Color = SKColor.Parse("#77d065")
            },

            new Entry (50)
            {
                Label = "ios",
                ValueLabel = "50%",
                Color = SKColor.Parse("#b455b6")
            },

            new Entry (2)
            {
                Label = "Others",
                ValueLabel = "2%",
                Color = SKColor.Parse("#3498db")
            },
        };
        public DougnutChart()
        {
            InitializeComponent();

            Chart1.Chart = new RadialGaugeChart() { LabelTextSize = 38, Entries = entries };
            Chart2.Chart = new LineChart() { LabelTextSize = 38, Entries = entries };
            Chart3.Chart = new DonutChart() 
            {
                MinValue = 0,
                MaxValue = 100,
                LabelTextSize = 38,
                HoleRadius = 0.5f,
                Margin = 10,
                BackgroundColor = SKColor.Parse("#ffffff"),
                Entries = entries
            };
            Chart4.Chart = new BarChart() { LabelTextSize = 38, Entries = entries };
            Chart5.Chart = new PointChart() { LabelTextSize = 38, Entries = entries };
            Chart6.Chart = new RadarChart() { LabelTextSize = 38, Entries = entries };
        }
    }
}