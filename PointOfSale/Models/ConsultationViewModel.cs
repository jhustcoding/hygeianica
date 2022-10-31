using Backend.Server.DataLayer;
using Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class ConsultationViewModel
    {
        private ObservableCollection<PrescribeConsultation> _customersInfo;
        public ObservableCollection<PrescribeConsultation> PrescribeConsultationInfoCollection
        {
            get { return _customersInfo; }
            set { this._customersInfo = value; }
        }

        private ObservableCollection<NonePrescribeConsultation> _nonePrescribeConsultationInfo;
        public ObservableCollection<NonePrescribeConsultation> NonePrescribeConsultationInfoCollection
        {
            get { return _nonePrescribeConsultationInfo; }
            set { this._nonePrescribeConsultationInfo = value; }
        }

        public ConsultationViewModel()
        {
            _customersInfo = new ObservableCollection<PrescribeConsultation>();
            _nonePrescribeConsultationInfo = new ObservableCollection<NonePrescribeConsultation>();
            this.GeneratePrescribeConsultation();
            this.GenerateNonePrescribeConsultation();
        }

        public void GeneratePrescribeConsultation()
        {
            var temp = GetDocuments<PrescribeConsultation>("prescribeconsultations");

            foreach (var item in temp)
            {
                PrescribeConsultationInfoCollection.Add(item);
            }
        }

        public void GenerateNonePrescribeConsultation()
        {
            var temp = GetDocuments<NonePrescribeConsultation>("noneprescribeconsultations");

            foreach (var item in temp)
            {
                NonePrescribeConsultationInfoCollection.Add(item);
            }
        }

        public IEnumerable<T> GetDocuments<T>(string collection)
        {
            var dbHelper = new DBHelper();
            return dbHelper.GetAllDocuments<T>("hygeneiaca", collection);
        }
    }
}
