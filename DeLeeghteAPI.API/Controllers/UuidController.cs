using DeLeeghteAPI.Applicatie.Interfaces;
using DeLeeghteAPI.Applicatie.Repositories;
using DeLeeghteAPI.Shared.DTOs.Uuid;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DeLeeghteAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UuidController : ControllerBase
    {
        private readonly IUuidRepository uuidRepository;

        public UuidController(IUuidRepository uuidRepository)
        {
            this.uuidRepository = uuidRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getUuids()
        {
            return Ok(await uuidRepository.GetAllUuids());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeefUuid(int id)
        {
            UuidListItem? retVal = await uuidRepository.GetAllUuidsById(id);
            return retVal != null ? Ok(retVal) : NotFound();
        }

        [HttpGet("by-date/{date}")]
        public async Task<IActionResult> getInschrijvingenbydate(DateTime date)
        {

            return Ok(await uuidRepository.GetAllUUIDSByDate(date));
        }

        [HttpPost]
        public async Task<IActionResult> MaakUuid(CreateUuid uuid)
        {
            try
            {
                var id = await uuidRepository.CreateuuidAsync(uuid);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUuid(int id, UuidListItem uuid)
        {
            try
            {
                await uuidRepository.UpdateUuidAsync(id, uuid);
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
        public async Task<IActionResult> DeleteUuid(int id)
        {
            try
            {
                await uuidRepository.DeleteUuidAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
