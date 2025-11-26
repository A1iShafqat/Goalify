using System.Windows.Input;

namespace Goalify.CustomControls;

public partial class NavigationBar : ContentView
{
    public NavigationBar()
    {
        InitializeComponent();
        Container.BindingContext = this;
    }

    public static readonly BindableProperty LeftButtonSourceProperty =
        BindableProperty.Create(nameof(LeftButtonSource), typeof(string), typeof(NavigationBar));

    public string LeftButtonSource
    {
        get => (string)GetValue(LeftButtonSourceProperty);
        set => SetValue(LeftButtonSourceProperty, value);
    }

    public static readonly BindableProperty RightButtonSecondarySourceProperty =
        BindableProperty.Create(nameof(RightButtonSecondarySource), typeof(string), typeof(NavigationBar));

    public string RightButtonSecondarySource
    {
        get => (string)GetValue(RightButtonSecondarySourceProperty);
        set => SetValue(RightButtonSecondarySourceProperty, value);
    }

    public static readonly BindableProperty RightButtonSourceProperty =
        BindableProperty.Create(nameof(RightButtonSource), typeof(string), typeof(NavigationBar));

    public string RightButtonSource
    {
        get => (string)GetValue(RightButtonSourceProperty);
        set => SetValue(RightButtonSourceProperty, value);
    }

    public static readonly BindableProperty LeftIconCommandProperty =
        BindableProperty.Create(nameof(LeftIconCommand), typeof(ICommand), typeof(NavigationBar));

    public ICommand LeftIconCommand
    {
        get => (ICommand)GetValue(LeftIconCommandProperty);
        set => SetValue(LeftIconCommandProperty, value);
    }

    public static readonly BindableProperty ArrowVisibleProperty =
        BindableProperty.Create(nameof(ArrowVisible), typeof(bool), typeof(NavigationBar), true);

    public bool ArrowVisible
    {
        get => (bool)GetValue(ArrowVisibleProperty);
        set => SetValue(ArrowVisibleProperty, value);
    }

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(NavigationBar));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty SubTitleProperty =
        BindableProperty.Create(nameof(SubTitle), typeof(string), typeof(NavigationBar));

    public string SubTitle
    {
        get => (string)GetValue(SubTitleProperty);
        set => SetValue(SubTitleProperty, value);
    }

    public static readonly BindableProperty DescriptionVisibleProperty =
        BindableProperty.Create(nameof(DescriptionVisible), typeof(bool), typeof(NavigationBar), true);

    public bool DescriptionVisible
    {
        get => (bool)GetValue(DescriptionVisibleProperty);
        set => SetValue(DescriptionVisibleProperty, value);
    }

    public static readonly BindableProperty AlertsCountProperty =
        BindableProperty.Create(nameof(AlertsCount), typeof(string), typeof(NavigationBar));

    public string AlertsCount
    {
        get => (string)GetValue(AlertsCountProperty);
        set => SetValue(AlertsCountProperty, value);
    }

    public static readonly BindableProperty AlertPriceVisibleProperty =
        BindableProperty.Create(nameof(AlertPriceVisible), typeof(bool), typeof(NavigationBar));

    public bool AlertPriceVisible
    {
        get => (bool)GetValue(AlertPriceVisibleProperty);
        set => SetValue(AlertPriceVisibleProperty, value);
    }

    public static readonly BindableProperty AlertsPriceProperty =
        BindableProperty.Create(nameof(AlertsPrice), typeof(string), typeof(NavigationBar));

    public string AlertsPrice
    {
        get => (string)GetValue(AlertsPriceProperty);
        set => SetValue(AlertsPriceProperty, value);
    }

    public static readonly BindableProperty AlertsVisibleProperty =
        BindableProperty.Create(nameof(AlertsVisible), typeof(bool), typeof(NavigationBar), true);

    public bool AlertsVisible
    {
        get => (bool)GetValue(AlertsVisibleProperty);
        set => SetValue(AlertsVisibleProperty, value);
    }

    public static readonly BindableProperty AlertsColorProperty =
        BindableProperty.Create(nameof(AlertsColor), typeof(Color), typeof(NavigationBar));

    public Color AlertsColor
    {
        get => (Color)GetValue(AlertsColorProperty);
        set => SetValue(AlertsColorProperty, value);
    }

    public static readonly BindableProperty RightIconCommandProperty =
        BindableProperty.Create(nameof(RightIconCommand), typeof(ICommand), typeof(NavigationBar));

    public ICommand RightIconCommand
    {
        get => (ICommand)GetValue(RightIconCommandProperty);
        set => SetValue(RightIconCommandProperty, value);
    }

    public static readonly BindableProperty RightSecondaryIconCommandProperty =
        BindableProperty.Create(nameof(RightSecondaryIconCommand), typeof(ICommand), typeof(NavigationBar));

    public ICommand RightSecondaryIconCommand
    {
        get => (ICommand)GetValue(RightSecondaryIconCommandProperty);
        set => SetValue(RightSecondaryIconCommandProperty, value);
    }

    public int CountLabel
    {
        get => (int)GetValue(CountLabelProperty);
        set => SetValue(CountLabelProperty, value);
    }

    public static readonly BindableProperty CountLabelProperty =
        BindableProperty.Create(nameof(CountLabel), typeof(int), typeof(NavigationBar));

    public Style CountStyle
    {
        get => (Style)GetValue(CountStyleProperty);
        set => SetValue(CountStyleProperty, value);
    }

    public static readonly BindableProperty CountStyleProperty =
        BindableProperty.Create(nameof(CountStyle), typeof(Style), typeof(NavigationBar));

    void ImageButton_Clicked(object sender, EventArgs e)
    {
        //if (LeftButtonSource == Icons.Menu_icon)
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
            Shell.Current.FlyoutIsPresented = true;
            //Work Around of a Known shell issue
            //github.com/dotnet/maui/issues/8532
            //Shell.Current.CurrentPage.Layout(new Rect(0, 0, Shell.Current.CurrentPage.Width + 1,
            //                                          Shell.Current.CurrentPage.Height + 1));

            return;
        }

        if (LeftIconCommand is not null && LeftIconCommand.CanExecute(e))
        {
            LeftIconCommand.Execute(e);
        }
    }
}
