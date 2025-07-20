using DeLeeghteAPI.Applicatie.Interfaces;
using DeLeeghteAPI.Domain.Data;
using DeLeeghteAPI.Domain.Entities;
using DeLeeghteAPI.Shared.DTOs.Uuid;
using DeLeeghteAPI.Shared.DTOs.Wedstrijd;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DeLeeghteAPI.Applicatie.Repositories
{
    public class WedstrijdRepository : IWedstrijdRepository
    {
        private readonly DeLeeghteContext deLeeghteContext;

        public WedstrijdRepository(DeLeeghteContext deLeeghteContext)
        {
            this.deLeeghteContext = deLeeghteContext;
        }


        public async Task<IEnumerable<WedstrijdListItem>> GetAllWedstrijden()
        {
            return await deLeeghteContext
                .wedstrijd
                .Select(static b => new WedstrijdListItem
                {
                    id = b.id,
                    naam = b.naam,
                    categorie_id = b.categorie_id,
                    zichtbaarheid = b.zichtbaarheid,
                    date = b.date,
                    created_at = b.created_at,
                    updated_at = b.updated_at,
                }).ToListAsync();
        }





        public async Task<IEnumerable<WedstrijdListItem>> GetAllWedstrijdenByDate(DateTime date)
        {
            return await deLeeghteContext
                .wedstrijd
                .Where(n => n.updated_at != null && n.updated_at > date)
                .OrderBy(n => n.updated_at) // optioneel: eerstvolgende wijziging
                .Select(static b => new WedstrijdListItem
                {
                    id = b.id,
                    naam = b.naam,
                    categorie_id = b.categorie_id,
                    zichtbaarheid = b.zichtbaarheid,
                    date = b.date,
                    created_at = b.created_at,
                    updated_at = b.updated_at,
                }).ToListAsync();
        }

        public async Task<WedstrijdListItem?> GetAllWedstrijdenById(int id)
        {
            Wedstrijd? wedstrijd = await deLeeghteContext.wedstrijd.SingleOrDefaultAsync(n => n.id == id);
            return MapWedstrijd(wedstrijd);
        }

        public async Task<int> CreateWedstrijdAsync(CreateWedstrijd b)
        {

            var wedstrijdent = new Wedstrijd
            {
                naam = b.naam,
                categorie_id = b.categorie_id,
                zichtbaarheid = b.zichtbaarheid,
                date = b.date,
                created_at = b.created_at,
                updated_at = b.updated_at
            };

            await deLeeghteContext.wedstrijd.AddAsync(wedstrijdent);

            await deLeeghteContext.SaveChangesAsync();
            return wedstrijdent.id;
        }

        public async Task UpdateWedstrijdAsync(int id, WedstrijdListItem wedstrijd)
        {
            if (id != wedstrijd.id)
            {
                throw new ValidationException("Ids are not corresponding");
            }

            Wedstrijd? wedstrijdent = await deLeeghteContext.wedstrijd.SingleOrDefaultAsync(n => n.id == id);

            if (wedstrijdent == null)
            {
                throw new Exception("No Wedstrijd found");
            }
            MapWedstrijd(wedstrijdent, wedstrijd);

            await deLeeghteContext.SaveChangesAsync();
        }

        public async Task DeleteWedstrijdAsync(int id)
        {
            var wedstrijd = await deLeeghteContext.wedstrijd.FindAsync(id);
            if (wedstrijd == null)
                throw new Exception("No uuid found");
            deLeeghteContext.wedstrijd.Remove(wedstrijd);
            await deLeeghteContext.SaveChangesAsync();
        }

        private static void MapWedstrijd(Wedstrijd wedstrijdent, WedstrijdListItem wedstrijd)
        {
            wedstrijdent.id = wedstrijd.id;
            wedstrijdent.naam = wedstrijd.naam;
            wedstrijdent.categorie_id = wedstrijd.categorie_id;
            wedstrijdent.zichtbaarheid = wedstrijd.zichtbaarheid;
            wedstrijdent.date = wedstrijd.date;
            wedstrijdent.created_at = wedstrijd.created_at;
            wedstrijdent.updated_at = wedstrijd.updated_at;
        }

        private static WedstrijdListItem? MapWedstrijd(Wedstrijd? wedstrijd)
        {
            if (wedstrijd == null) return null;
            return new WedstrijdListItem()
            {
                id = wedstrijd.id,
                naam = wedstrijd.naam,
                categorie_id = wedstrijd.categorie_id,
                zichtbaarheid = wedstrijd.zichtbaarheid,
                date = wedstrijd.date,
                created_at = wedstrijd.created_at,
                updated_at = wedstrijd.updated_at
            };
        }
    }
}
