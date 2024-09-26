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


        // 控制抽屉的打开状态
        [ObservableProperty]
        private bool _isDrawerOpen = true;

        // 抽屉的宽度，默认展开时为 500，收起时为 60
        [ObservableProperty]
        private string _drawerWidth = "500";

        // 切换抽屉状态
        [RelayCommand]
        private void ToggleDrawer()
        {
            if (IsDrawerOpen)
            {
                DrawerWidth = "160"; // 抽屉收起时保留一部分按钮
            }
            else
            {
                DrawerWidth = "500"; // 抽屉完全展开
            }
            IsDrawerOpen = !IsDrawerOpen;
        }

        [ObservableProperty]
        private ObservableCollection<SensorDataModelDto> _sensorData = new ObservableCollection<SensorDataModelDto>();
    }
}
