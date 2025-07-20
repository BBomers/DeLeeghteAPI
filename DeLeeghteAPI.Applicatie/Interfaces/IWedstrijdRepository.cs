using DeLeeghteAPI.Shared.DTOs.Wedstrijd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLeeghteAPI.Applicatie.Interfaces
{
    public interface IWedstrijdRepository
    {
        Task<IEnumerable<WedstrijdListItem>> GetAllWedstrijden();
        Task<WedstrijdListItem?> GetAllWedstrijdenById(int id);
        Task<IEnumerable<WedstrijdListItem>> GetAllWedstrijdenByDate(DateTime date);
        Task<int> CreateWedstrijdAsync(CreateWedstrijd b);
        Task UpdateWedstrijdAsync(int id, WedstrijdListItem wedstrijd);
        Task DeleteWedstrijdAsync(int id);
    }
}
