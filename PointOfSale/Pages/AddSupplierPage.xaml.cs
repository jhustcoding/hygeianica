using Backend.Server.DataLayer;
using CommunityToolkit.Maui.Views;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Structures;
using Syncfusion.Maui.DataGrid;

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
        this.ShowPopup(new NewPage1());
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
            Type = Type1.Text
        };

        await dbHelper.CreateDocument<Supplier>("hygeneiaca", "suppliers", supplier);
    }

    private void dataGrid_CellTapped(object sender, DataGridCellTappedEventArgs e)
    {
        var rowData = e.RowData.ToBson();


        var temp = BsonSerializer.Deserialize<Supplier>(rowData);
        SupplierName.Text = temp.SupplierName;
        Phone.Text = temp.Phone;
        OfficeAddress.Text = temp.OfficeAddress;
        City.Text = temp.City;
        PostalCode.Text = temp.PostalCode;
        Country.Text = temp.Country;
        MobileNumber.Text = temp.MobileNumber;
        AgentName.Text = temp.AgentName;
        LTORegsNumber.Text = temp.LTORegistration;
        LTOExpi.Text = temp.LTOExpiration;
        Type1.Text = temp.Type;
        PreviousBalance.Text = temp.PreviousBalance;


    }


}