using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Entities
{
    public class House
    {
        [Key]
        public int HouseID { get; set; }
        public int Block { get; set; }
        public bool IsEmpty { get; set; }
        public string HouseType { get; set; }
        public int Floor { get; set; }
        public int HouseNo { get; set; }
        public int Subscription { get; set; }
        public int? UserID { get; set; }
        public User User { get; set; }
    }
}
