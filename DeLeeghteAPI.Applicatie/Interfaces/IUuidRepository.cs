using DeLeeghteAPI.Shared.DTOs.Inschrijving;
using DeLeeghteAPI.Shared.DTOs.Uuid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLeeghteAPI.Applicatie.Interfaces
{
    public interface IUuidRepository
    {
        Task<IEnumerable<UuidListItem>> GetAllUuids();
        Task<UuidListItem?> GetAllUuidsById(int id);
        Task<IEnumerable<UuidListItem>> GetAllUUIDSByDate(DateTime date);
        Task<int> CreateuuidAsync(CreateUuid b);
        Task UpdateUuidAsync(int id, UuidListItem uuid);
        Task DeleteUuidAsync(int id);

    }
}
