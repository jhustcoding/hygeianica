using Backend.Server.DataLayer;
using CommunityToolkit.Maui.Views;
using Structures;
using System.Text.Json;

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

    private async void SaveCustomer_Button_Clicked(object sender, EventArgs e)
    {
        CreateDocument();
        Result.Text = "Successfully saved";
        GivenName.Text = "";
        Address.Text = "";
        Age.Text = "";
        BirthDate.Text = "";
        Contact.Text = "";
        Email.Text = "";
        LastName.Text = "";
        Gender.Text = "";
        Discount.Text = "";
    }

    public async Task CreateDocument()
    {
        var dbHelper = new DBHelper();
        var customer = new customers() { GivenName = GivenName.Text, Address = Address.Text, Age = Age.Text, BirthDate = BirthDate.Text, Contact = Contact.Text, Email = Email.Text, LastName = LastName.Text,
            Gender = Gender.Text, Discount = Discount.Text};

       await dbHelper.CreateDocument<customers>("hygeneiaca", "customers", customer);
    }
}