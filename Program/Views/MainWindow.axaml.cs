using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using CustomTitleBarTemplate.ViewModels;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace CustomTitleBarTemplate.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

#if DEBUG
            this.AttachDevTools();
            #endif


            // Do not use a custom title bar on Linux, because there are too many possible options.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) == true)
            {
                UseNativeTitleBar();
            }

            this.DataContext = new MainWindowViewModel(this);

            this.Height = 400;
            this.Width = 600;
            this.Padding = new Thickness(
                            this.OffScreenMargin.Left,
                            this.OffScreenMargin.Top,
                            this.OffScreenMargin.Right,
                            this.OffScreenMargin.Bottom);

            Application.Current.Styles[1] = App.FluentLight;
        }

        private void UseNativeTitleBar()
        {
            ExtendClientAreaChromeHints = Avalonia.Platform.ExtendClientAreaChromeHints.SystemChrome;
            ExtendClientAreaTitleBarHeightHint = -1;
            ExtendClientAreaToDecorationsHint = false;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
