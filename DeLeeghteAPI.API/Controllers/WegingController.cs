using DeLeeghteAPI.Applicatie.Interfaces;
using DeLeeghteAPI.Shared.DTOs.Weging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DeLeeghteAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WegingController : ControllerBase
    {
        private readonly IWegingRepository WegingRepository;

        public WegingController(IWegingRepository WegingRepository)
        {
            this.WegingRepository = WegingRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getWegings()
        {
            return Ok(await WegingRepository.GetAllWegingen());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeefWeging(int id)
        {
            WegingListItem? retVal = await WegingRepository.GetAllWegingenById(id);
            return retVal != null ? Ok(retVal) : NotFound();
        }

        [HttpGet("{WedstrijdId}/{InschrijvingId}/{UuidId}")]
        public async Task<IActionResult> GeefwegingengByData(int WedstrijdId, int InschrijvingId, int UuidId)
        {
            return Ok(await WegingRepository.GetWegingByData(WedstrijdId, InschrijvingId, UuidId));
        }

        [HttpPost]
        public async Task<IActionResult> MaakWeging(CreateWeging Weging)
        {
            try
            {
                var id = await WegingRepository.CreateWegingAsync(Weging);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeging(int id, WegingListItem Weging)
        {
            try
            {
                await WegingRepository.UpdateWegingAsync(id, Weging);
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
        public async Task<IActionResult> DeleteWeging(int id)
        {
            try
            {
                await WegingRepository.DeleteWegingAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
