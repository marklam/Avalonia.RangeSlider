using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Themes.Fluent;
using RangeSlider.Avalonia.Enums;

namespace RangeSlider.Avalonia.SampleApp.Views;

public partial class MainWindow : Window
{
    private bool _isMatherial;

    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Application.Current?.Styles.Clear();

        var appUri = new Uri("avares://RangeSlider.Avalonia.SampleApp/App.axaml");
        var rStyle = new RangeSliderStyle(appUri);

        if (!_isMatherial)
        {
            var baseAppUri = new Uri("avares://RangeSlider.Avalonia.SampleApp");

            var styleInclude = new StyleInclude(baseAppUri)
            {
                Source = new Uri("avares://Material.Avalonia/Material.Avalonia.Templates.xaml")
            };

            Application.Current?.Styles.Add(styleInclude);
            rStyle.Theme = StyleTheme.Material;
            Application.Current?.Styles.Add(rStyle);
		}
        else
        {
            var fluent = new FluentTheme();
            Application.Current?.Styles.Add(fluent);
            Application.Current?.Styles.Add(rStyle);
        }

        _isMatherial = !_isMatherial;
    }
}