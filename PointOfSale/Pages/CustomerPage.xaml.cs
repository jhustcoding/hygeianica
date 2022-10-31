using CommunityToolkit.Maui.Views;
using Syncfusion.Maui.DataGrid;

namespace PointOfSale.Pages;

public partial class CustomerPage : ContentPage
{
	public CustomerPage()
	{
		InitializeComponent();
        this.dataGrid.SelectionChanged += DataGrid_SelectionChanged;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        this.ShowPopup(new AddCustomerPage());
    }

    private void DataGrid_SelectionChanged(object sender, Syncfusion.Maui.DataGrid.DataGridSelectionChangedEventArgs e)
    {
        var selectedItem = e.AddedRows[0];
    }

    private void dataGrid_CellTapped(object sender, DataGridCellTappedEventArgs e)
    {
        //var rowIndex = e.RowColumnIndex.RowIndex;
        var rowData = e.RowData;
        //var columnIndex = e.RowColumnIndex.ColumnIndex;
        //var column = e.Column;

        //this.ShowPopup(new ConsultationPage());
    }
}