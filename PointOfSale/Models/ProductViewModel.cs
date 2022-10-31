using Backend.Server.DataLayer;
using Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Product> _customersInfo;
        public ObservableCollection<Product> ProductsInfoCollection
        {
            get { return _customersInfo; }
            set { this._customersInfo = value; }
        }

        public ProductViewModel()
        {
            _customersInfo = new ObservableCollection<Product>();
            this.GenerateCustomers();
        }

        public void GenerateCustomers()
        {
            var temp = GetDocuments();

            foreach (var item in temp)
            {
                ProductsInfoCollection.Add(item);
            }
        }

        public IEnumerable<Product> GetDocuments()
        {
            var dbHelper = new DBHelper();
            return dbHelper.GetAllDocuments<Product>("hygeneiaca", "products");
        }
    }
}
