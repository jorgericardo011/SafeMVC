using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;

namespace SalesWebMvc.Services
{
    public class SalesRecordsService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordsService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
                var result = from obj in _context.SalesRecord select obj;
                if (minDate.HasValue)
                {
                    result = result.Where(x => x.Data >= minDate.Value);
                }
                if (maxDate.HasValue)
                {
                    result = result.Where(x => x.Data <= maxDate.Value);
                }
                return await result
                    .Include(x => x.Seller)
                    .Include(x => x.Seller.Department)
                    .OrderByDescending(x => x.Data)
                    .ToListAsync();
         }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }

            var data = await result
                .Include(s => s.Seller)
                .Include(s => s.Seller.Department)
                .OrderByDescending(se => se.Data)
                .ToListAsync();

            return data.GroupBy(s => s.Seller.Department).ToList();
        }


    }
}
