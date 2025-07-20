using DeLeeghteAPI.Shared.DTOs.Weging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLeeghteAPI.Applicatie.Interfaces
{
    public interface IWegingRepository
    {
        Task<IEnumerable<WegingListItem>> GetAllWegingen();
        Task<WegingListItem?> GetAllWegingenById(int id);
        Task<int> CreateWegingAsync(CreateWeging b);
        Task UpdateWegingAsync(int id, WegingListItem weging);
        Task DeleteWegingAsync(int id);
        Task<IEnumerable<WegingListItem>> GetWegingByData(int WedstrijdId, int InschrijvingId, int UuidId);
    }
}
