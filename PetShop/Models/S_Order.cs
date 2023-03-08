using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PetShop.Models
{
    public class S_Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string Region { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string DateOrder { get; set; }

    }
}
