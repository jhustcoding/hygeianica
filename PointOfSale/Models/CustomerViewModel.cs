using Backend.Server.DataLayer;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class CustomerViewModel
    {
        private ObservableCollection<customers> _customersInfo;
        public ObservableCollection<customers> CustomersInfoCollection
        {
            get { return _customersInfo; }
            set { this._customersInfo = value; }
        }

        public CustomerViewModel()
        {
            _customersInfo = new ObservableCollection<customers>();
            this.GenerateCustomers();
        }

        public void GenerateCustomers()
        {
            var temp = GetDocuments();

            foreach (var item in temp)
            {
                    CustomersInfoCollection.Add(item);
            }
        }

        public IEnumerable<customers> GetDocuments()
        {
            var dbHelper = new DBHelper();
            return dbHelper.GetAllDocuments<customers>("hygeneiaca", "customers");
        }
    }
}
