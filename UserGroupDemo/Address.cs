using System;
using System.Collections.Generic;
using System.Text;

namespace UserGroupDemo
{
    public class Address
    {
        public string street1 { get; set; }
        public string zip { get; set; }

        public string GetFullAddress()
        {
            return street1 + ", " + zip;
        }
    }
}
