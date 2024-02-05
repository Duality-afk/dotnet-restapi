using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VillaAPI.Data;
using VillaAPI.Models;
using VillaAPI.Models.Dto;

namespace VillaAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VillaAPIController : ControllerBase
	{
		[HttpGet]
		public IEnumerable<VillaDTO> GetVillas()
		{
			return VillaStore.VillaList;
		}

		[HttpGet("{id:int}")]
		public ActionResult <VillaDTO> GetVilla(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}
			var villa = VillaStore.VillaList.FirstOrDefault(x => x.Id == id);
			if (villa == null)
			{
				return NotFound();
			}
			return Ok(villa);

		}

		public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villa) 
		{
			if (villa == null)
			{
				return BadRequest(villa);

			}
			if (villa.Id > 0)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			villa.Id = VillaStore.VillaList.OrderByDescending(x => x.Id).FirstOrDefault().Id;
			VillaStore.VillaList.Add(villa);	
			return Ok(villa);
		}
	}
}
