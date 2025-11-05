using System.Windows.Input;

namespace Goalify.Controls;

public partial class PrimaryEntry : ContentView
{
	public PrimaryEntry()
	{
		InitializeComponent();
		Container.BindingContext = this;
    }

	public static readonly BindableProperty LabelNameProperty = 
		BindableProperty.Create(nameof(LabelName), typeof(string), typeof(PrimaryEntry), string.Empty);

    public string LabelName
	{
		get
		{
			return (string)GetValue(LabelNameProperty);
		}
		set
		{
			SetValue(LabelNameProperty, value);
		}
	}

    public static readonly BindableProperty LabelColorProperty =
    BindableProperty.Create(nameof(LabelColor), typeof(Color), typeof(PrimaryEntry), Colors.Black);

    public Color LabelColor
    {
        get
        {
            return (Color)GetValue(LabelColorProperty);
        }
        set
        {
            SetValue(LabelColorProperty, value);
        }
    }

    public static readonly BindableProperty ButtonVisibleProperty =
        BindableProperty.Create(nameof(ButtonVisible), typeof(bool), typeof(PrimaryEntry), false);

    public bool ButtonVisible
    {
        get
        {
            return (bool)GetValue(ButtonVisibleProperty);
        }
        set
        {
            SetValue(ButtonVisibleProperty, value);
        }
    }

    public static readonly BindableProperty CommandButtonProperty =
    BindableProperty.Create(nameof(CommandButton), typeof(ICommand), typeof(PrimaryEntry));

    public ICommand CommandButton
    {
        get
        {
            return (ICommand)GetValue(CommandButtonProperty);
        }
        set
        {
            SetValue(CommandButtonProperty, value);
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}