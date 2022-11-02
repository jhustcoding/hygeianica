using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Drawing;

namespace Structures
{
    public class customers
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }
        public string? GivenName { get; set; }
        public string? LastName { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? BirthDate { get; set; }
        public string? Age { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? Discount { get; set; }
        // public Bitmap QR { get; set; }
    }

    public class Manufacturer
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }
        public string? ManufacturerName { get; set; }
        public string? Phone { get; set; }
        public string? OfficeAddress { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? MobileNumber { get; set; }
        public string? ProductValidityEmail { get; set; }
    }

    public class Supplier
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }
        public string? SupplierName { get; set; }
        public string? Phone { get; set; }
        public string? OfficeAddress { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? MobileNumber { get; set; }
        public string? AgentName { get; set; }
        public string? LTORegistration { get; set; }
        public string? LTOExpiration { get; set; }
        public string? Type { get; set; }
        public string? PreviousBalance { get; set; }
       // public Bitmap LTOImage = null;
    }

    public class PrescribeConsultation
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }
        public string? CustomerEmail { get; set; }
        public string? Date { get; set; }  
        public string? PhysicianName { get; set; }
        public string? PhysicianContact { get; set; }
        public string? PRCLicenseNumber { get; set; }
        public string? S2LicenseNumber { get; set; }
        public PrescibeMedicine? PrescibeMedicine { get; set; }
    }

    public class PrescibeMedicine
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }
        public string? GenericName { get; set; }
        public string? DosageStrength { get; set; }
        public string? Description { get; set; }
        public string? PharmacyInstruction { get; set; }
        public string? Remarks { get; set; }
        public string? AmountPrescribed { get; set; }
        public string? IssuedBy { get; set; }
        // public Bitmap PrescriptionImage = null;
    }

    public class NonePrescribeConsultation
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }
        public string? CustomerEmail { get; set; }
        public string? Date { get; set; }
        public string? Symptoms { get; set; }
        public string? PharmacyRecommendation { get; set; }
        public string? IssuedBy { get; set; }
    }

    public class Product
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }
        public string? QRCode { get; set; }
        public string? DosageStrength { get; set; }
        public string? DosageForm { get; set; }
        public string? Description { get; set; }
        public string? TherapeuticCategory { get; set; }
        public string? MedicationType { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierPrice { get; set; }
        public string? GenericName { get; set; }
        public string? BrandName { get; set; }
        public string? Units { get; set; }
        public string? Price { get; set; }
        public string? ProductImage { get; set; }
    }



}