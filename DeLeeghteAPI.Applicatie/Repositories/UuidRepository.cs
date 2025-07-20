using DeLeeghteAPI.Applicatie.Interfaces;
using DeLeeghteAPI.Domain.Data;
using DeLeeghteAPI.Domain.Entities;
using DeLeeghteAPI.Shared.DTOs.Uuid;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DeLeeghteAPI.Applicatie.Repositories
{
    public class UuidRepository : IUuidRepository
    {
        private readonly DeLeeghteContext deLeeghteContext;

        public UuidRepository(DeLeeghteContext deLeeghteContext)
        {
            this.deLeeghteContext = deLeeghteContext;
        }


        public async Task<IEnumerable<UuidListItem>> GetAllUuids()
        {
            return await deLeeghteContext
                .uuid
                .Select(static b => new UuidListItem
                {
                    id = b.id,
                    naam = b.naam,
                    nickname = b.nickname,
                    telefoon = b.telefoon,
                    email = b.email,
                    created_at = b.created_at,
                    updated_at = b.updated_at,
                }).ToListAsync();
        }
        public async Task<IEnumerable<UuidListItem>> GetAllUUIDSByDate(DateTime date)
        {
            return await deLeeghteContext
                .uuid
                .Where(n => n.updated_at != null && n.updated_at > date)
                .Select(static b => new UuidListItem
                {
                    id = b.id,
                    naam = b.naam,
                    nickname = b.nickname,
                    telefoon = b.telefoon,
                    email = b.email,
                    created_at = b.created_at,
                    updated_at = b.updated_at,
                }).ToListAsync();
        }

        public async Task<UuidListItem?> GetAllUuidsById(int id)
        {
            Uuid? uuid = await deLeeghteContext.uuid.SingleOrDefaultAsync(n => n.id == id);
            return MapUuid(uuid);
        }

        public async Task<int> CreateuuidAsync(CreateUuid b)
        {

            var uuident = new Uuid
            {
                naam = b.naam,
                nickname = b.nickname,
                telefoon = b.telefoon,
                email = b.email,
                created_at = b.created_at,
                updated_at = b.updated_at,
            };

            await deLeeghteContext.uuid.AddAsync(uuident);

            await deLeeghteContext.SaveChangesAsync();
            return uuident.id;
        }

        public async Task UpdateUuidAsync(int id, UuidListItem uuid)
        {
            if (id != uuid.id)
            {
                throw new ValidationException("Ids are not corresponding");
            }

            Uuid? uuident = await deLeeghteContext.uuid.SingleOrDefaultAsync(n => n.id == id);

            if (uuident == null)
            {
                throw new Exception("No uuid found");
            }
            MapUuid(uuident, uuid);

            await deLeeghteContext.SaveChangesAsync();
        }

        public async Task DeleteUuidAsync(int id)
        {
            var uuid = await deLeeghteContext.uuid.FindAsync(id);
            if (uuid == null)
                throw new Exception("No uuid found");
            deLeeghteContext.uuid.Remove(uuid);
            await deLeeghteContext.SaveChangesAsync();
        }

        private static void MapUuid(Uuid uuident, UuidListItem uuid)
        {
            uuident.naam = uuid.naam;
            uuident.nickname = uuid.nickname;
            uuident.telefoon = uuid.telefoon;
            uuident.email = uuid.email;
            uuident.created_at = uuid.created_at;
            uuident.updated_at = uuid.updated_at;
        }

        private static UuidListItem? MapUuid(Uuid? uuid)
        {
            if (uuid == null) return null;
            return new UuidListItem()
            {
                naam = uuid.naam,
                nickname = uuid.nickname,
                telefoon = uuid.telefoon,
                email = uuid.email,
                created_at = uuid.created_at,
                updated_at = uuid.updated_at,
            };
        }
    }
}
