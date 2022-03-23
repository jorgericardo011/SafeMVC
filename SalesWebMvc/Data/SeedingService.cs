using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; //DB has been seeded
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Food");
            Department d4 = new Department(4, "Sport");

            Seller s1 = new Seller(1, "Bob Marley", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Marley", "bobilon@gmail.com", new DateTime(1978, 4, 11), 1400.0, d2);
            Seller s3 = new Seller(3, "Boby", "bobidilon@gmail.com", new DateTime(1948, 5, 14), 14400.0, d1);
            Seller s4 = new Seller(4, "Boblon", "bobibabicutis@gmail.com", new DateTime(1988, 4, 13), 1010.0, d4);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2018, 09, 25), 1555, SalesStatus.Billed, s2);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2018, 09, 25), 1775.0, SalesStatus.Pending, s1);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2018, 10, 28), 1575.0, SalesStatus.Billed, s3);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2020, 11, 25), 1455.0, SalesStatus.Canceled, s4);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2019, 09, 01), 2555.0, SalesStatus.Pending, s1);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5);

            _context.SaveChanges();
            
        }
    }
}
