using Backend.Server.DataLayer;
using Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class SupplierViewModel
    {
        private ObservableCollection<Supplier> _customersInfo;
        public ObservableCollection<Supplier> SuppliersInfoCollection
        {
            get { return _customersInfo; }
            set { this._customersInfo = value; }
        }

        public SupplierViewModel()
        {
            _customersInfo = new ObservableCollection<Supplier>();
            this.GenerateCustomers();
        }

        public void GenerateCustomers()
        {
            var temp = GetDocuments();

            foreach (var item in temp)
            {
                SuppliersInfoCollection.Add(item);
            }
        }

        public IEnumerable<Supplier> GetDocuments()
        {
            var dbHelper = new DBHelper();
            return dbHelper.GetAllDocuments<Supplier>("hygeneiaca", "suppliers");
        }
    }
}
