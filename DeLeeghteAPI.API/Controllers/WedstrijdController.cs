using DeLeeghteAPI.Applicatie.Interfaces;
using DeLeeghteAPI.Applicatie.Repositories;
using DeLeeghteAPI.Shared.DTOs.Wedstrijd;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DeLeeghteAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WedstrijdController : ControllerBase
    {
        private readonly IWedstrijdRepository wedstrijdRepository;

        public WedstrijdController(IWedstrijdRepository wedstrijdRepository)
        {
            this.wedstrijdRepository = wedstrijdRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getWedstrijds()
        {
            return Ok(await wedstrijdRepository.GetAllWedstrijden());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeefWedstrijd(int id)
        {
            WedstrijdListItem? retVal = await wedstrijdRepository.GetAllWedstrijdenById(id);
            return retVal != null ? Ok(retVal) : NotFound();
        }



        [HttpGet("by-date/{date}")]
        public async Task<IActionResult> GeefWedstrijdbydate(DateTime date)
        {

            return Ok(await wedstrijdRepository.GetAllWedstrijdenByDate(date));
        }

        [HttpPost]
        public async Task<IActionResult> MaakWedstrijd(CreateWedstrijd wedstrijd)
        {
            try
            {
                var id = await wedstrijdRepository.CreateWedstrijdAsync(wedstrijd);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWedstrijd(int id, WedstrijdListItem wedstrijd)
        {
            try
            {
                await wedstrijdRepository.UpdateWedstrijdAsync(id, wedstrijd);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWedstrijd(int id)
        {
            try
            {
                await wedstrijdRepository.DeleteWedstrijdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
