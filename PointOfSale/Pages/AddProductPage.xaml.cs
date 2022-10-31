using Backend.Server.DataLayer;
using Structures;
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

        await dbHelper.CreateDocument<Product>("hygeneiaca", "suppliers", product);
    }
}