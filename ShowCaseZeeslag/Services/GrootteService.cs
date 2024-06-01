using ShowCaseZeeslag.Data;
using ShowCaseZeeslag.Models;

namespace ShowCaseZeeslag.Services
{


    public class GrootteService
    {
        private readonly ApplicationDbContext _context;

        public GrootteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdateVeldGrootte(int grootte)
        {
            var existingGrootte = _context.VeldGroottes.FirstOrDefault();
            if (existingGrootte == null)
            {
                _context.VeldGroottes.Add(new VeldGrootte { Grootte = grootte });
            }
            else
            {
                existingGrootte.Grootte = grootte;
            }

            _context.SaveChanges();
        }
        public int? GetVeldGrootte()
        {
            var existingGrootte = _context.VeldGroottes.FirstOrDefault();
            return existingGrootte?.Grootte;
        }

    }
}

