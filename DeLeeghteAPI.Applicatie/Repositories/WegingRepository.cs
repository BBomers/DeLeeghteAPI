using DeLeeghteAPI.Applicatie.Interfaces;
using DeLeeghteAPI.Domain.Data;
using DeLeeghteAPI.Domain.Entities;
using DeLeeghteAPI.Shared.DTOs.Weging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLeeghteAPI.Applicatie.Repositories
{
    public class WegingRepository : IWegingRepository
    {
        private readonly DeLeeghteContext deLeeghteContext;

        public WegingRepository(DeLeeghteContext deLeeghteContext)
        {
            this.deLeeghteContext = deLeeghteContext;
        }


        public async Task<IEnumerable<WegingListItem>> GetAllWegingen()
        {
            return await deLeeghteContext
                .weging
                .Select(static b => new WegingListItem
                {
                    id = b.id,
                    wedstrijd_id = b.wedstrijd_id,
                    inschrijvingen_id = b.inschrijvingen_id,
                    uuid_id = b.uuid_id,
                    weging = b.weging,
                    created_at = b.created_at,
                    updated_at = b.updated_at,
                }).ToListAsync();
        }


        public async Task<IEnumerable<WegingListItem>> GetWegingByData(int WedstrijdId, int InschrijvingId, int UuidId)
        {
            return await deLeeghteContext
                .weging
                .Where(b => b.wedstrijd_id == WedstrijdId)
                .Where(b => b.inschrijvingen_id == InschrijvingId)
                .Where(b => b.uuid_id == UuidId)
                .Select(static b => new WegingListItem
                {
                    id = b.id,
                    wedstrijd_id = b.wedstrijd_id,
                    inschrijvingen_id = b.inschrijvingen_id,
                    uuid_id = b.uuid_id,
                    weging = b.weging,
                    created_at = b.created_at,
                    updated_at = b.updated_at,
                }).ToListAsync();
        }






        public async Task<WegingListItem?> GetAllWegingenById(int id)
        {
            Weging? weging = await deLeeghteContext.weging.SingleOrDefaultAsync(n => n.id == id);
            return MapWeging(weging);
        }

        public async Task<int> CreateWegingAsync(CreateWeging b)
        {

            var wegingent = new Weging
            {
                wedstrijd_id = b.wedstrijd_id,
                inschrijvingen_id = b.inschrijvingen_id,
                uuid_id = b.uuid_id,
                weging = b.weging,
                created_at = b.created_at,
                updated_at = b.updated_at,
            };

            await deLeeghteContext.weging.AddAsync(wegingent);

            await deLeeghteContext.SaveChangesAsync();
            return wegingent.id;
        }

        public async Task UpdateWegingAsync(int id, WegingListItem weging)
        {
            if (id != weging.id)
            {
                throw new ValidationException("Ids are not corresponding");
            }

            Weging? wegingent = await deLeeghteContext.weging.SingleOrDefaultAsync(n => n.id == id);

            if (wegingent == null)
            {
                throw new Exception("No weging found");
            }
            MapWeging(wegingent, weging);

            await deLeeghteContext.SaveChangesAsync();
        }

        public async Task DeleteWegingAsync(int id)
        {
            var weging = await deLeeghteContext.weging.FindAsync(id);
            if (weging == null)
                throw new Exception("No uuid found");
            deLeeghteContext.weging.Remove(weging);
            await deLeeghteContext.SaveChangesAsync();
        }

        private static void MapWeging(Weging wegingent, WegingListItem weging)
        {
            wegingent.id = weging.id;
            wegingent.wedstrijd_id = weging.wedstrijd_id;
            wegingent.inschrijvingen_id = weging.inschrijvingen_id;
            wegingent.uuid_id = weging.uuid_id;
            wegingent.weging = weging.weging;
            wegingent.created_at = weging.created_at;
            wegingent.updated_at = weging.updated_at;
        }

        private static WegingListItem? MapWeging(Weging? weging)
        {
            if (weging == null) return null;
            return new WegingListItem()
            {
                id = weging.id,
                wedstrijd_id = weging.wedstrijd_id,
                inschrijvingen_id = weging.inschrijvingen_id,
                uuid_id = weging.uuid_id,
                weging = weging.weging,
                created_at = weging.created_at,
                updated_at = weging.updated_at,
            };
        }
    }
}
