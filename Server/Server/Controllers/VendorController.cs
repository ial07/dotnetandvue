using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Interface;
using Server.Models;
using Server.ViewModels;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : Controller
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;
        public VendorController(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Vendor>))]
        public IActionResult GetVendors()
        {
            var vendor = _mapper.Map<List<VendorViewModel>>(_vendorRepository.GetVendors());



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(vendor);
        }

        [HttpGet("{vendorId}")]
        [ProducesResponseType(200, Type = typeof(Vendor))]
        [ProducesResponseType(400)]
        public IActionResult GetVendor(int vendorId)
        {
            if (!_vendorRepository.vendorExists(vendorId))
                return NotFound();

            var vendor = _mapper.Map<VendorViewModel>(_vendorRepository.GetVendor(vendorId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(vendor);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePokemon([FromBody] VendorViewModel createVendor)
        {
            if (createVendor == null)
                return BadRequest(ModelState);

            var vendor = _vendorRepository.GetVendors()
                .Where(c => c.Name.Trim().ToUpper() == createVendor.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (vendor != null)
            {
                ModelState.AddModelError("", "Vendor already exist");
                return StatusCode(422, ModelState);
            }

            var vendorMap = _mapper.Map<Vendor>(createVendor);

            if (!_vendorRepository.CreateVendor(vendorMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }


            return Ok("Succesfully saving");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePokemon(int vendorId, [FromBody] VendorViewModel updateVendor)
        {
            if (updateVendor == null)
                return BadRequest(ModelState);

            if (vendorId != updateVendor.Id)
                return BadRequest(ModelState);

            if (!_vendorRepository.vendorExists(vendorId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var vendorMap = _mapper.Map<Vendor>(updateVendor);

            if (!_vendorRepository.UpdateVendor(vendorMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        [HttpDelete("{vendorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeletePokemon(int vendorId)
        {
            if (!_vendorRepository.vendorExists(vendorId))
                return NotFound();

            var vendorDelete = _vendorRepository.GetVendor(vendorId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_vendorRepository.DeleteVendor(vendorDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
            }

            return NoContent();
        }

    }
}
