using DeLeeghteAPI.Applicatie.Interfaces;
using DeLeeghteAPI.Domain.Data;
using DeLeeghteAPI.Domain.Entities;
using DeLeeghteAPI.Shared.DTOs.Inschrijving;
using DeLeeghteAPI.Shared.DTOs.Uuid;
using DeLeeghteAPI.Shared.DTOs.Wedstrijd;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DeLeeghteAPI.Applicatie.Repositories
{
    public class InschrijvingenRepository : IInschrijvingRepository
    {
        private readonly DeLeeghteContext deLeeghteContext;

        public InschrijvingenRepository(DeLeeghteContext deLeeghteContext)
        {
            this.deLeeghteContext = deLeeghteContext;
        }

        public async Task<IEnumerable<InschrijvingListItem>> GetAllInschrijvingenbywedstrijdID(int wedstrijdID)
        {
            return await deLeeghteContext
            .inschrijving
                .Where(n => n.wedstrijd_id == wedstrijdID)
                .Select(static b => new InschrijvingListItem
                {
                    id = b.id,
                    wedstrijd_id = b.wedstrijd_id,
                    uuid_id = b.uuid_id,
                    stek = b.stek,
                    uuid_id_two = b.uuid_id_two,
                    stek_two = b.stek_two,
                    uuid_id_tree = b.uuid_id_tree,
                    stek_tree = b.stek_tree,
                    uuid_id_four = b.uuid_id_four,
                    stek_four = b.stek_four,
                    created_at = b.created_at,
                    updated_at = b.updated_at,
                }).ToListAsync();
        }
        public async Task<IEnumerable<InschrijvingListItem>> GetAllInschrijvingen()
        {
            return await deLeeghteContext
                .inschrijving
                .Select(static b => new InschrijvingListItem
                {
                    id = b.id,
                    wedstrijd_id = b.wedstrijd_id,
                    uuid_id = b.uuid_id,
                    stek = b.stek,
                    uuid_id_two = b.uuid_id_two,
                    stek_two = b.stek_two,
                    uuid_id_tree = b.uuid_id_tree,
                    stek_tree = b.stek_tree,
                    uuid_id_four = b.uuid_id_four,
                    stek_four = b.stek_four,
                    created_at = b.created_at,
                    updated_at = b.updated_at,
                }).ToListAsync();
        }


        public async Task<IEnumerable<InschrijvingListItem>> GetAllInschrijvingenByDate(DateTime date)
        {
            return await deLeeghteContext
                .inschrijving
                .Where(n => n.updated_at != null && n.updated_at > date)
                .OrderBy(n => n.updated_at) // optioneel: eerstvolgende wijziging
                .Select(static b => new InschrijvingListItem
                {
                    id = b.id,
                    wedstrijd_id = b.wedstrijd_id,
                    uuid_id = b.uuid_id,
                    stek = b.stek,
                    uuid_id_two = b.uuid_id_two,
                    stek_two = b.stek_two,
                    uuid_id_tree = b.uuid_id_tree,
                    stek_tree = b.stek_tree,
                    uuid_id_four = b.uuid_id_four,
                    stek_four = b.stek_four,
                    created_at = b.created_at,
                    updated_at = b.updated_at,
                }).ToListAsync();
        }

        public async Task<int> CreateInschrijvingenAsync(CreateInschrijving b)
        {

            var inschrijvingent = new Inschrijving
            {
                wedstrijd_id = b.wedstrijd_id,
                uuid_id = b.uuid_id,
                stek = b.stek,
                uuid_id_two = b.uuid_id_two,
                stek_two = b.stek_two,
                uuid_id_tree = b.uuid_id_tree,
                stek_tree = b.stek_tree,
                uuid_id_four = b.uuid_id_four,
                stek_four = b.stek_four,
                created_at = b.created_at,
                updated_at = b.updated_at,
            };

            await deLeeghteContext.inschrijving.AddAsync(inschrijvingent);

            await deLeeghteContext.SaveChangesAsync();
            return inschrijvingent.id;
        }

        public async Task UpdateInschrijvingAsync(int id, InschrijvingListItem inschrijving)
        {
            if (id != inschrijving.id)
            {
                throw new ValidationException("Ids are not corresponding");
            }

            Inschrijving? inschrijvingent = await deLeeghteContext.inschrijving.SingleOrDefaultAsync(n => n.id == id);

            if (inschrijvingent == null)
            {
                throw new Exception("No inschrijving found");
            }
            MapInschrijving(inschrijvingent, inschrijving);

            await deLeeghteContext.SaveChangesAsync();
        }
        private static void MapInschrijving(Inschrijving Inschrvingent, InschrijvingListItem inschrijving)
        {



            Inschrvingent.id = inschrijving.id;
            Inschrvingent.wedstrijd_id = inschrijving.wedstrijd_id;
            Inschrvingent.uuid_id = inschrijving.uuid_id;
            Inschrvingent.stek = inschrijving.stek;
            Inschrvingent.uuid_id_two = inschrijving.uuid_id_two;
            Inschrvingent.stek_two = inschrijving.stek_two;
            Inschrvingent.uuid_id_tree = inschrijving.uuid_id_tree;
            Inschrvingent.stek_tree = inschrijving.stek_tree;
            Inschrvingent.uuid_id_four = inschrijving.uuid_id_four;
            Inschrvingent.stek_four = inschrijving.stek_four;
            Inschrvingent.created_at = inschrijving.created_at;
            Inschrvingent.updated_at = inschrijving.updated_at;
        }
        public async Task DeleteInschrijvingAsync(int id)
        {
            var inschrijving = await deLeeghteContext.inschrijving.FindAsync(id);
            if (inschrijving == null)
                throw new Exception("No inschrijving found");
            deLeeghteContext.inschrijving.Remove(inschrijving);
            await deLeeghteContext.SaveChangesAsync();
        }

    }

}