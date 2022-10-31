using Backend.Server.DataLayer;
using CommunityToolkit.Maui.Views;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using Structures;
using Syncfusion.Maui.DataGrid;
using System.Diagnostics.Metrics;

namespace PointOfSale.Pages;

public partial class ConsultationPage : Popup
{
	public ConsultationPage()
	{
		InitializeComponent();
    }

    private void SaveCustomer_Button_Clicked(object sender, EventArgs e)
    {
        CreateDocument();
    }
    private void SaveCustomer_Button_Clicked1(object sender, EventArgs e)
    {
        CreateDocument1();
        this.dataGrid.SelectionChanged += DataGrid_SelectionChanged;
    }

    public async Task CreateDocument()
    {
        var dbHelper = new DBHelper();
        var prescribeConsultation = new PrescribeConsultation()
        {
            PhysicianName = PhysicianName.Text,
            PhysicianContact = PhysicianContact.Text,
            PRCLicenseNumber = PRCLicenseNumber.Text,
            S2LicenseNumber = S2LicenseNumber.Text,
            Date = Date.Date.ToShortDateString(),
            PrescibeMedicine = new PrescibeMedicine() 
            {
                AmountPrescribed = AmountPrescribed.Text,
                GenericName = GenericName.Text,
                DosageStrength = DosageStrength.Text,
                Description = Description.Text,
                PharmacyInstruction = PharmacyIntruction.Text,
                Remarks = Remarks.Text,
                IssuedBy = IssuedBy1.Text
            }
        };

        await dbHelper.CreateDocument<PrescribeConsultation>("hygeneiaca", "prescribeconsultations", prescribeConsultation);
    }

    public async Task CreateDocument1()
    {
        var dbHelper = new DBHelper();
        var noneprescribeconsultation = new NonePrescribeConsultation()
        {
            Symptoms = Symptoms.Text,
            PharmacyRecommendation = PharmacistRecom.Text,
            IssuedBy = IssuedBy2.Text,
            Date = Date1.Date.ToShortDateString()
        };


        await dbHelper.CreateDocument<NonePrescribeConsultation>("hygeneiaca", "noneprescribeconsultations", noneprescribeconsultation);
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        //Close();
    }
    private void DataGrid_SelectionChanged(object sender, Syncfusion.Maui.DataGrid.DataGridSelectionChangedEventArgs e)
    {
        var selectedItem = e.AddedRows[0];
    }

    private void dataGrid_CellTapped(object sender, DataGridCellTappedEventArgs e)
    {
        var rowData = e.RowData.ToBson();


       var temp = BsonSerializer.Deserialize<PrescribeConsultation>(rowData);
        PhysicianName.Text = temp.PhysicianName;
        PhysicianContact.Text = temp.PhysicianContact;
        PRCLicenseNumber.Text = temp.PRCLicenseNumber;
        S2LicenseNumber.Text = temp.S2LicenseNumber;

        GenericName.Text = temp.PrescibeMedicine.GenericName;
        DosageStrength.Text = temp.PrescibeMedicine.DosageStrength;
        Description.Text = temp.PrescibeMedicine.Description;
        PharmacyIntruction.Text = temp.PrescibeMedicine.PharmacyInstruction;
        Remarks.Text = temp.PrescibeMedicine.Remarks;
        AmountPrescribed.Text = temp.PrescibeMedicine.AmountPrescribed;
        IssuedBy1.Text = temp.PrescibeMedicine.IssuedBy;

    }

    private void dataGrid_CellTapped1(object sender, DataGridCellTappedEventArgs e)
    {

        var rowData = e.RowData.ToBson();


        var temp = BsonSerializer.Deserialize<NonePrescribeConsultation>(rowData);
        IssuedBy2.Text = temp.IssuedBy;
        PharmacistRecom.Text = temp.PharmacyRecommendation;
        Symptoms.Text = temp.PharmacyRecommendation;

    }

}