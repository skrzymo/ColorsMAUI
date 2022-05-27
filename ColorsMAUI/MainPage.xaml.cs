namespace ColorsMAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        var (r, g, b) = Settings.Load();
        SliderR.Value = r;
        SliderG.Value = g;
        SliderB.Value = b;
	}

    void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Color color = Color.FromRgb(SliderR.Value, SliderG.Value, SliderB.Value);

        ColorRectangle.Fill = new SolidColorBrush(color);

        LabelR.Text = Math.Round(255 * color.Red).ToString();
        LabelG.Text = Math.Round(255 * color.Green).ToString();
        LabelB.Text = Math.Round(255 * color.Blue).ToString();

        Settings.Save(SliderR.Value, SliderG.Value, SliderB.Value);
    }

    //int count = 0;

    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //	count++;

    //	if (count == 1)
    //		CounterBtn.Text = $"Clicked {count} time";
    //	else
    //		CounterBtn.Text = $"Clicked {count} times";

    //	SemanticScreenReader.Announce(CounterBtn.Text);
    //}
}


