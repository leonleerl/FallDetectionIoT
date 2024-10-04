using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FallDetectionIoT.Shared.ModelDtos;
using FallDetectionIoT.Shared.Models;
using FallDetectionIoT.WPF.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace FallDetectionIoT.WPF.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly ISensorDataService _sensorDataService;
        private readonly IMapper _mapper;

        public MainWindowViewModel(ISensorDataService sensorDataService, IMapper mapper)
        {
            _sensorDataService = sensorDataService;
            _mapper = mapper;
            LoadSensorData();

            MapProvider = GoogleMapProvider.Instance;
            Position = new PointLatLng(-31.9505, 115.8605);  // 例如：珀斯的经纬度
            Zoom = 12;
            Markers = new ObservableCollection<GMapMarker>();

        }

        private async void LoadSensorData()
        {
            var data = await _sensorDataService.GetAll();
            foreach (var sensorDataModel in data)
            {
                var sensorDataDto = _mapper.Map<SensorDataModelDto>(sensorDataModel);
                SensorData.Add(sensorDataDto);
            }
        }

        [RelayCommand]
        private void ToggleDrawer()
        {
            if (IsDrawerOpen)
            {
                DrawerWidth = "160";
            }
            else
            {
                DrawerWidth = "500";
            }
            IsDrawerOpen = !IsDrawerOpen;
        }

        [RelayCommand]
        private async Task Search()
        {
            var results = await _sensorDataService.GetAll(SearchContent);
            SensorData.Clear();
            foreach (var sensorDataModel in results)
            {
                var sensorDataDto = _mapper.Map<SensorDataModelDto>(sensorDataModel);
                SensorData.Add(sensorDataDto);
            }
        }

        [RelayCommand]
        private void CheckboxChanged(SensorDataModelDto sensorDataModelDto)
        {
            if (sensorDataModelDto.IsChecked == false)
            {
                foreach (var senserData in SensorData)
                {
                    if (senserData.Id == sensorDataModelDto.Id)
                    {
                        senserData.IsChecked = true;

                        // 用户勾选，向地图添加新标记
                        if (double.TryParse(sensorDataModelDto.Latitude, out double latitude) &&
                            double.TryParse(sensorDataModelDto.Longitude, out double longitude))
                        {
                            // 创建 Ellipse 形状作为 Marker
                            var ellipse = new Ellipse
                            {
                                Width = 10,  // 初始大小
                                Height = 10,
                                Stroke = Brushes.Red,
                                StrokeThickness = 2,
                                Fill = Brushes.Red,
                                Opacity = 1.0, // 初始不透明度
                                RenderTransform = new ScaleTransform(1, 1),  // 用于扩展的变换
                                RenderTransformOrigin = new System.Windows.Point(0.5, 0.5)
                            };

                            var marker = new GMapMarker(new PointLatLng(latitude, longitude))
                            {
                                Shape = ellipse
                            };

                            // 将 Marker 添加到地图
                            Markers.Add(marker);

                            // 动态扩散效果
                            var expandAnimation = new DoubleAnimation
                            {
                                From = 1, // 起始大小
                                To = 5,   // 扩散到5倍大小
                                Duration = TimeSpan.FromSeconds(2),  // 持续2秒
                                RepeatBehavior = RepeatBehavior.Forever,  // 无限循环
                                AutoReverse = false  // 动画反转，变小后再次扩展
                            };

                            // 动态透明度效果
                            var fadeAnimation = new DoubleAnimation
                            {
                                From = 1.0, // 初始不透明度
                                To = 0.3,   // 最终半透明，但不完全消失
                                Duration = TimeSpan.FromSeconds(2),  // 持续2秒
                                RepeatBehavior = RepeatBehavior.Forever,  // 无限循环
                                AutoReverse = false  // 动画反转，透明度恢复后再次减弱
                            };

                            // 应用扩展动画到 ScaleTransform
                            var transform = (ScaleTransform)ellipse.RenderTransform;
                            transform.BeginAnimation(ScaleTransform.ScaleXProperty, expandAnimation);
                            transform.BeginAnimation(ScaleTransform.ScaleYProperty, expandAnimation);

                            // 应用透明度动画到 Ellipse
                            ellipse.BeginAnimation(UIElement.OpacityProperty, fadeAnimation);
                        }
                        else
                        {
                            MessageBox.Show("Invalid GPS coordinates");
                        }
                    }
                }
            }
            else
            {
                foreach (var senserData in SensorData)
                {
                    if (senserData.Id == sensorDataModelDto.Id)
                    {
                        senserData.IsChecked = false;

                        // 用户取消勾选，移除地图上的标记
                        var markerToRemove = Markers.FirstOrDefault(m =>
                            m.Position.Lat == double.Parse(sensorDataModelDto.Latitude) &&
                            m.Position.Lng == double.Parse(sensorDataModelDto.Longitude));

                        if (markerToRemove != null)
                        {
                            Markers.Remove(markerToRemove);
                        }
                    }
                }
            }
        }


        //[RelayCommand]
        //private void CheckboxChanged(SensorDataModelDto sensorDataModelDto)
        //{
        //    if (sensorDataModelDto.IsChecked == false)
        //    {
        //        // 切换 IsChecked 状态
        //        foreach (var senserData in SensorData)
        //        {
        //            if (senserData.Id == sensorDataModelDto.Id)
        //            {
        //                senserData.IsChecked = true;

        //                // 用户勾选，向地图添加新标记
        //                if (double.TryParse(sensorDataModelDto.Latitude, out double latitude) &&
        //                    double.TryParse(sensorDataModelDto.Longitude, out double longitude))
        //                {
        //                    var marker = new GMapMarker(new PointLatLng(latitude, longitude))
        //                    {

        //                    };



        //                    Markers.Add(marker);
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Invalid GPS coordinates");
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (var senserData in SensorData)
        //        {
        //            if (senserData.Id == sensorDataModelDto.Id)
        //            {
        //                senserData.IsChecked = false;

        //                // 用户取消勾选，移除地图上的标记
        //                var markerToRemove = Markers.FirstOrDefault(m =>
        //                    m.Position.Lat == double.Parse(sensorDataModelDto.Latitude) &&
        //                    m.Position.Lng == double.Parse(sensorDataModelDto.Longitude));

        //                if (markerToRemove != null)
        //                {
        //                    Markers.Remove(markerToRemove);
        //                }
        //            }
        //        }

        //    }
        //}

        [ObservableProperty]
        private ObservableCollection<SensorDataModelDto> _sensorData = new ObservableCollection<SensorDataModelDto>();


        [ObservableProperty]
        private bool _isDrawerOpen = true;


        [ObservableProperty]
        private string _drawerWidth = "500";

        [ObservableProperty]
        private string _searchContent = "";

        [ObservableProperty]
        private GMapProvider _mapProvider;

        [ObservableProperty]
        private PointLatLng _position;

        [ObservableProperty]
        private int _zoom;

        [ObservableProperty]
        private ObservableCollection<GMapMarker> _markers;

    }
}