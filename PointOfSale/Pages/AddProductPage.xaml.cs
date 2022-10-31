
using Backend.Server.DataLayer;
using CommunityToolkit.Maui.Views;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Structures;
using Syncfusion.DataSource;
using Syncfusion.Maui.DataGrid;
using System.Diagnostics.Metrics;

namespace PointOfSale.Pages;

public partial class AddProductPage : ContentPage
{
	public AddProductPage()
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
        var product = new Product()
        {
            BrandName = BrandName.Text,
            DosageForm = DosageForm.Text,
            Description = ProductDescription.Text,
            DosageStrength = DosageStrength.Text,
            GenericName = GenericName.Text,
            MedicationType = MedicationType.Text,
            Price = Price.Text,
            TherapeuticCategory = TherapeuticCategory.Text,
            Units = Unit.Text,
            SupplierName = SupplierName.Text,
            SupplierPrice = SupplierPrice.Text
            
        };

        await dbHelper.CreateDocument<Product>("hygeneiaca", "products", product);
    }

    private void dataGrid_CellTapped(object sender, DataGridCellTappedEventArgs e)
    {
        var rowData = e.RowData.ToBson();


        var temp = BsonSerializer.Deserialize<Product>(rowData);
        DosageStrength.Text = temp.DosageStrength;
        DosageForm.Text = temp.DosageForm;
        ProductDescription.Text = temp.Description;
        TherapeuticCategory.Text = temp.TherapeuticCategory;
        MedicationType.Text = temp.MedicationType;
        SupplierName.Text = temp.SupplierName;
        SupplierPrice.Text = temp.SupplierPrice;
        GenericName.Text = temp.GenericName;
        BrandName.Text = temp.BrandName;
        Unit.Text = temp.Units;
        Price.Text = temp.Price;
    }
}