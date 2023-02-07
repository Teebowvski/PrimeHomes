﻿using System;
using System.Collections.Generic;

namespace PrimeHomes.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderDetail> OrderLines { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public int AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public double OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
    }
}
