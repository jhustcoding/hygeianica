using CommunityToolkit.Maui.Views;

namespace PointOfSale.Pages;

public partial class CustomerPage : ContentPage
{
	public CustomerPage()
	{
		InitializeComponent();
	}

    private void OnCounterClicked(object sender, EventArgs e)
    {
        this.ShowPopup(new AddCustomerPage());
    }
}