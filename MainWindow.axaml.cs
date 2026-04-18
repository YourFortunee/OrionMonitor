using Avalonia;
using Avalonia.Controls;
using System;
//using OrionMonitor.ViewModels;

namespace MonitoringSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OpenSettingsButton_OnClick(object? sender, EventArgs e)
        {
            var settingsWindow = new SettingsWindow
            {
                DataContext = new SettingsWindowViewModel()
            };

            await settingsWindow.ShowDialog(this);
        }

        private void OpenWidgetButton_OnClick(object? sender, EventArgs e)
        {
            if (_widgetWindow == null || !_widgetWindow.IsVisible)
            {
                _widgetWindow = new WidgetWindow
                {
                    DataContext = new WidgetWindowViewModel()
                };

                // Позиционируем в правый верхний угол
                var screen = Screens.Primary;
                if (screen != null)
                {
                    _widgetWindow.Position = new PixelPoint(
                        screen.Bounds.Width - 300,
                        50
                    );
                }

                _widgetWindow.Show();

                // Закрываем виджет вместе с главным окном
                _widgetWindow.Closed += (s, args) => _widgetWindow = null;
            }
            else
            {
                _widgetWindow.Activate();
            }
        }
    }
}
