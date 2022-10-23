using CommunityToolkit.Maui.Views;

namespace PointOfSale.Pages;

public partial class AddCustomerPage : Popup
{
	public AddCustomerPage()
	{
        InitializeComponent();
	}
    private void Button_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}