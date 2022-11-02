using CommunityToolkit.Maui.Views;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using Newtonsoft.Json.Linq;
using Structures;
using Syncfusion.Maui.DataGrid;

namespace PointOfSale.Pages;

public partial class CustomerPage : ContentPage
{
    private string _email = "";
	public CustomerPage()
	{
		InitializeComponent();
        //this.dataGrid.SelectionChanged += DataGrid_SelectionChanged;
       // this.dataGrid.SelectedRows += DataGrid_SelectionChanged
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        this.ShowPopup(new AddCustomerPage());
    }

    private void DataGrid_SelectionChanged(object sender, Syncfusion.Maui.DataGrid.DataGridSelectionChangedEventArgs e)
    {
       // var selectedItem = e.AddedRows[0];
    }

    private void dataGrid_CellTapped(object sender, DataGridCellTappedEventArgs e)
    {
        var rowData = e.RowData.ToBsonDocument();
        _email = rowData["Email"].ToString();
    }

    private void MedicineImage_Clicked(object sender, EventArgs e)
    {
        this.ShowPopup(new GiveMedicinePage(_email));
    }

    private void QRImage_Clicked(object sender, EventArgs e)
    {

    }

    private void EditImage_Clicked(object sender, EventArgs e)
    {

    }

    private void ConsultationImage_Clicked(object sender, EventArgs e)
    {
        this.ShowPopup(new ConsultationPage(_email));
    }

    //private void Image_MouseDown(object sender, MouseButtonEventArgs e)
    //{

    //}
}