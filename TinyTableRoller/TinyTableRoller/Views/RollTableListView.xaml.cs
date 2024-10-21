using TinyTableRoller.Helpers;
using TinyTableRoller.ViewModels;

namespace TinyTableRoller.Views;

public partial class RollTableListView : ContentView
{
	public RollTableListView()
	{
		InitializeComponent();

		var viewModel = ServiceHelper.GetService<RollTableListViewModel>()
			?? throw new ArgumentNullException(nameof(RollTableListViewModel));

        BindingContext = viewModel;
	}
}