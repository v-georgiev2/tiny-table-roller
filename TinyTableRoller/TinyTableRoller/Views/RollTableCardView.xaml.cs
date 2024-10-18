using TinyTableRoller.Data;

namespace TinyTableRoller.Views;

public partial class RollTableCardView : ContentView
{
	public RollTableCardView()
	{
		InitializeComponent();
	}

	protected RollTable RollTable { get; set; }
}