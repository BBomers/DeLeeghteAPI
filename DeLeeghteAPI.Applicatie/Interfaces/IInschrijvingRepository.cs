using DeLeeghteAPI.Domain.Entities;
using DeLeeghteAPI.Shared.DTOs.Inschrijving;
using DeLeeghteAPI.Shared.DTOs.Uuid;
using DeLeeghteAPI.Shared.DTOs.Wedstrijd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLeeghteAPI.Applicatie.Interfaces
{
    public interface IInschrijvingRepository
    {
        Task<IEnumerable<InschrijvingListItem>> GetAllInschrijvingen();
        Task<IEnumerable<InschrijvingListItem>> GetAllInschrijvingenbywedstrijdID(int wedstrijdID);
        Task<IEnumerable<InschrijvingListItem>> GetAllInschrijvingenByDate(DateTime date);
        Task UpdateInschrijvingAsync(int id, InschrijvingListItem inschrijving);
        Task<int> CreateInschrijvingenAsync(CreateInschrijving b);
        Task DeleteInschrijvingAsync(int id);
    }
}

