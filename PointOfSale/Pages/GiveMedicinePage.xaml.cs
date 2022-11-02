using Backend.Server.DataLayer;
using CommunityToolkit.Maui.Views;
using MongoDB.Driver;
using Structures;

namespace PointOfSale.Pages;

public partial class GiveMedicinePage : Popup
{
	private DBHelper _dbHelper = null;
	private string _email = "";
    public GiveMedicinePage(string email)
	{
		InitializeComponent();
		_email = email;
        _dbHelper = new DBHelper();
    }
	private bool _isPrescribe = true;
	private void Entry_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (_isPrescribe)
		{
            var filter = Builders<PrescribeConsultation>.Filter.And(
				Builders<PrescribeConsultation>.Filter.Where(p => p.PrescibeMedicine.GenericName.ToLower().Contains(this.GenericNameEntry.Text.ToLower())),
				Builders<PrescribeConsultation>.Filter.Where(p => p.CustomerEmail.ToLower().Contains(_email.ToLower())));
            var result = _dbHelper.GetFilteredDocuments<PrescribeConsultation>("hygeneiaca", "prescribeconsultations", filter);

			if (result.Count > 0)
			{
				this.AllowedLabel.Text = "Allowed dosage: " + result[0].PrescibeMedicine.AmountPrescribed;
            }
        }
		else
		{
            var filter = Builders<PrescribeConsultation>.Filter.And(
				Builders<PrescribeConsultation>.Filter.Where(p => p.PrescibeMedicine.GenericName.ToLower().Contains(this.GenericNameEntry.Text.ToLower())),
				Builders<PrescribeConsultation>.Filter.Where(p => p.CustomerEmail.ToLower().Contains(_email.ToLower())));
            _dbHelper.GetFilteredDocuments<PrescribeConsultation>("hygeneiaca", "noneprescribeconsultations", filter);
        }
	}

	private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		_isPrescribe = true;

    }

	private void RadioButton_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
	{
		_isPrescribe = false;

    }

}