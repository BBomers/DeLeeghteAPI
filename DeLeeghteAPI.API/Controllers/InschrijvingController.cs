using DeLeeghteAPI.Applicatie.Interfaces;
using DeLeeghteAPI.Applicatie.Repositories;
using DeLeeghteAPI.Shared.DTOs.Inschrijving;
using DeLeeghteAPI.Shared.DTOs.Uuid;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DeLeeghteAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InschrijvingController : ControllerBase
    {
        private readonly IInschrijvingRepository inschrijvingRepository;

        public InschrijvingController(IInschrijvingRepository inschrijvingRepository)
        {
            this.inschrijvingRepository = inschrijvingRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getInschrijvingen()
        {
            return Ok(await inschrijvingRepository.GetAllInschrijvingen());
        }
        [HttpGet("{wedstrijdID}")]
        public async Task<IActionResult> getInschrijvingenbywedstrijdID(int wedstrijdID)
        {
            return Ok(await inschrijvingRepository.GetAllInschrijvingenbywedstrijdID(wedstrijdID));
        }

        [HttpGet("by-date/{date}")]
        public async Task<IActionResult> getInschrijvingenbydate(DateTime date)
        {

            return Ok(await inschrijvingRepository.GetAllInschrijvingenByDate(date));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateInschrijving(int id, InschrijvingListItem inschrijving)
        {
            try
            {
                await inschrijvingRepository.UpdateInschrijvingAsync(id, inschrijving);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> MaakUuid(CreateInschrijving uuid)
        {
            try
            {
                var id = await inschrijvingRepository.CreateInschrijvingenAsync(uuid);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInschrijving(int id)
        {
            try
            {
                await inschrijvingRepository.DeleteInschrijvingAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}
