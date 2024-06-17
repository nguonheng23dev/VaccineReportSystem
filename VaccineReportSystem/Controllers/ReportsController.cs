using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineReportSystem.Data;
using VaccineReportSystem.Models;

namespace VaccineReportSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Report
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetReport()
        {
            var report = await _context.Visitors
                .GroupBy(v => new { v.Province.Name, v.Doses, v.VaccineCard.CardType })
                .Select(g => new
                {
                    Province = g.Key.Name,
                    Doses = g.Key.Doses,
                    VisitorCount = g.Count(),
                    CardType = g.Key.CardType,
                })
                .ToListAsync();

            var groupedReport = report
                .GroupBy(r => r.Province)
                .Select(g => new
                {
                    Province = g.Key,
                    Doses = g.OrderByDescending(r => r.VisitorCount).First().Doses,
                    VisitorCount = g.Sum(r => r.VisitorCount),
                    CardTypes = g.GroupBy(r => r.CardType)
                                 .Select(ctg => new { CardType = ctg.Key, Count = ctg.Sum(r => r.VisitorCount) })
                });

            return Ok(groupedReport);
        }
    }
}
