using System.ComponentModel.DataAnnotations.Schema;

namespace CvStorage.Core
{
    public class Address : Entity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string StreetNumber { get; set; }
        public virtual Cv Cv { get; set; }

    }
}