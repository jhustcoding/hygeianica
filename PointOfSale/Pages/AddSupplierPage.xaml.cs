using Backend.Server.DataLayer;
using Structures;

namespace PointOfSale.Pages;

public partial class AddSupplierPage : ContentPage
{
	public AddSupplierPage()
	{
		InitializeComponent();
    }
    private void SaveCustomer_Button_Clicked(object sender, EventArgs e)
    {
        CreateDocument();
    }

    public async Task CreateDocument()
    {
        var dbHelper = new DBHelper();
        var supplier = new Supplier()
        {
            SupplierName = SupplierName.Text,
            AgentName = AgentName.Text,
            City = City.Text,
            Country = Country.Text,
            LTOExpiration = LTOExpi.Text,
            LTORegistration = LTORegsNumber.Text,
            MobileNumber = MobileNumber.Text,
            OfficeAddress = OfficeAddress.Text,
            Phone = Phone.Text,
            PostalCode = PostalCode.Text,
            PreviousBalance = PreviousBalance.Text,
            Type = Type.Text
        };

        await dbHelper.CreateDocument<Supplier>("hygeneiaca", "suppliers", supplier);
    }


}