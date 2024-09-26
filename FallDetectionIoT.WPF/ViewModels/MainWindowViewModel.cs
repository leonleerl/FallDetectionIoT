using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        public MainWindowViewModel(ISensorDataService sensorDataService)
        {
            _sensorDataService = sensorDataService;
            LoadSensorData();
        }

        private async void LoadSensorData()
        {
            var data = await _sensorDataService.GetAll();
            foreach (var sensor in data)
            {
                SensorData.Add(sensor);
            }
        }

        [ObservableProperty]
        private string _sensorName = "Yes";

        [RelayCommand]
        public void Click()
        {
            MessageBox.Show("Hello");
        }

        [ObservableProperty]
        private ObservableCollection<SensorDataModel> _sensorData = new ObservableCollection<SensorDataModel>();
    }
}
