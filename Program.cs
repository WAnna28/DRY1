using System;
using System.Collections.Generic;
using System.Linq;

namespace DRY1
{
    // The fact the two entities have the same functionality doesn’t mean they violate DRY.
    // In fact, both the School and the Car classes hold their own semantics.
    // It just happened that they do it using the identical code in this particular case.
    // From the domain’s point of view, these entities develop separately from each other.
    // They both represent different parts of the domain and thus don’t violate the DRY principle.
    public class School
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Car
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    class Program
    {
        static void Main()
        {
            PrintAddress();
            PrintAddressExtra();
            PrintAddressLong();
            
            // After refactoring
             PrintAddresses();
            Console.ReadLine();
        }

        private static void PrintAddress()
        {
            var country = "Armenia";
            var city = "Yerevan";
            var street = "Leo 9";

            Console.WriteLine($"\nCountry is: {country}\nCity is {city}\nStreet is: {street}\nFloor is: unknown\nThis is: Not enough information ");
        }

        private static void PrintAddressExtra()
        {
            var country = "Armenia";
            var city = "Yerevan";
            var street = "Alek Manukyan 1";
            var floor = 2;

            Console.WriteLine($"\nCountry is: {country}\nCity is {city}\nStreet is: {street}\nFloor is: {floor}\nThis is: Not enough information ");
        }

        private static void PrintAddressLong()
        {
            var country = "Armenia";
            var city = "Yerevan";
            var street = "Alek Manukyan 9";
            var floor = 4;
            var isOffice = true;

            Console.WriteLine($"\nCountry is: {country}\nCity is {city}\nStreet is: {street}\nFloor is: {floor}\nThis is: { (isOffice ? "Office" : "Home") } ");
        }

        public class Address
        {
            public string Country { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public int? Floor { get; set; }
            public bool? IsOffice { get; set; }
        }

        private static IEnumerable<Address> GetAddresses()
        {
            return new List<Address>()
            {
                new Address() { Country = "Armenia", City = "Yerevan", Street = "Leo 3"},
                new Address() { Country = "Armenia", City = "Yerevan", Street = "Alek Manukyan 1", Floor = 2 },
                new Address() { Country = "Armenia", City = "Yerevan", Street = "Alek Manukyan 9", Floor = 4, IsOffice = true }
            };
        }

        private static void PrintAddresses()
        {
            List<Address> addresses = GetAddresses().ToList();
            if (addresses.Count > 0)
            {
                foreach (var address in addresses)
                {
                    Console.WriteLine($"\nCountry is: {address.Country}\nCity is {address.City}\nStreet is: {address.Street}\n"+
$"Floor is: {(address.Floor.HasValue ? address.Floor.Value : "unknown") }\n" +
$"This is: { (address.IsOffice.HasValue ? (address.IsOffice.Value ? "Office" : "Home") : "Not enough information") } ");
                }
            }
        }
    }
}