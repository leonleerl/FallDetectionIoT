using FallDetectionIoT.WPF.ViewModels;
using GMap.NET.MapProviders;
using GMap.NET;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET.WindowsPresentation;

namespace FallDetectionIoT.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            this.DataContext = mainWindowViewModel;

            // 初始化 GMap 控件
            gmapControl.MapProvider = GoogleMapProvider.Instance;
            gmapControl.Position = new PointLatLng(-31.9505, 115.8605);
            gmapControl.MinZoom = 1;
            gmapControl.MaxZoom = 20;
            gmapControl.Zoom = 12;
            gmapControl.ShowCenter = false;
        }

        // 在地图上添加标记
        private void AddMarker(double lat, double lng)
        {
            var marker = new GMapMarker(new PointLatLng(lat, lng))
            {
                Shape = new System.Windows.Shapes.Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Stroke = Brushes.Red,
                    StrokeThickness = 2,
                    Fill = Brushes.Red
                }
            };

            gmapControl.Markers.Add(marker);
        }

        // 向地图发送坐标
        public void SendCoordinates(double latitude, double longitude)
        {
            gmapControl.Position = new PointLatLng(latitude, longitude);
            AddMarker(latitude, longitude);
        }
    }
}