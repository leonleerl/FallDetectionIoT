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
using System.Collections.ObjectModel;
using System.Collections.Specialized;

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

            //gmapControl.MapProvider = GoogleMapProvider.Instance;
            //gmapControl.Position = new PointLatLng(-31.9505, 115.8605);
            gmapControl.MinZoom = 1;
            gmapControl.MaxZoom = 20;
            gmapControl.Zoom = 12;
            gmapControl.ShowCenter = false;
            gmapControl.DragButton = MouseButton.Left;

            mainWindowViewModel.Markers.CollectionChanged += OnMarkersCollectionChanged;
        }

        // 当 Markers 集合发生变化时，更新 gmapControl.Markers
        private void OnMarkersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // 清空当前标记
            gmapControl.Markers.Clear();

            // 重新添加所有标记
            foreach (var marker in (sender as ObservableCollection<GMapMarker>))
            {
                gmapControl.Markers.Add(marker);
            }
        }

        private void Button_Click_ClearAll(object sender, RoutedEventArgs e)
        {
            // 获取 ViewModel
            var viewModel = (MainWindowViewModel)this.DataContext;

            // 清除复选框的选中状态
            foreach (var sensorData in viewModel.SensorData)
            {
                sensorData.IsChecked = false;
            }

            // 清空所有地图标记
            viewModel.Markers.Clear();
        }
    }
}