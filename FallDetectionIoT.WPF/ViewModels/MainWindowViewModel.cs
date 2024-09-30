using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FallDetectionIoT.Shared.ModelDtos;
using FallDetectionIoT.Shared.Models;
using FallDetectionIoT.WPF.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

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
        private void CheckboxChanged(object param)
        {
            SensorDataModelDto? sensorData = param as SensorDataModelDto;
            if (sensorData != null)
            {
                // 在这里处理点击事件，比如获取选中的行数据
                if (sensorData.IsChecked)
                {
                    // 处理选中
                    Console.WriteLine($"Selected: {sensorData.Name}, Fall Date: {sensorData.FallDate}");
                }
                else
                {
                    // 处理取消选中
                    Console.WriteLine($"Deselected: {sensorData.Name}, Fall Date: {sensorData.FallDate}");
                }
            }
        }

        [ObservableProperty]
        private ObservableCollection<SensorDataModelDto> _sensorData = new ObservableCollection<SensorDataModelDto>();


        [ObservableProperty]
        private bool _isDrawerOpen = true;


        [ObservableProperty]
        private string _drawerWidth = "500";

        [ObservableProperty]
        private string _searchContent = "";

    }
}