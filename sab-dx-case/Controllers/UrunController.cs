using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sab_dx_case.Data;
using sab_dx_case.Data.ApiModels;

namespace sab_dx_case.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UrunController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UrunController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<UrunController>
        [HttpGet]
        public IActionResult GetAllUrunler()
        {
            var urunler = _context.Urunler.Where(u => u.IsDeleted == false).ToList();
            if(urunler == null)
            {
                return NoContent();
            }
            return Ok(urunler);
        }

        // GET api/<UrunController>/5
        [HttpGet("{id}")]
        public IActionResult GetUrunById(int id)
        {
            var urun = _context.Urunler.Where(u => u.Id == id && u.IsDeleted == false).FirstOrDefault();
            return Ok(urun);
        }

        // POST api/<UrunController>
        [HttpPost]
        public IActionResult CreateUrun([FromBody] Urun urun)
        {
            if (ModelState.IsValid)
            {
                _context.Urunler.Add(urun);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetUrunById), new { id = urun.Id }, urun);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<UrunController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateUrun(int id, [FromBody] Urun updatedUrun)
        {
            var urun = _context.Urunler.Find(id);
            if (urun == null)
            {
                return NotFound();
            }

            urun.Adi = updatedUrun.Adi;
            urun.Kodu = updatedUrun.Kodu;
            urun.Fiyat = updatedUrun.Fiyat;
            urun.Aciklama = updatedUrun.Aciklama;
            urun.StokDurumu = updatedUrun.StokDurumu;
            urun.Marka = updatedUrun.Marka;
            urun.ParaBirimi = updatedUrun.ParaBirimi;

            _context.SaveChanges();

            return Ok();

        }

        // DELETE api/<UrunController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUrun(int id)
        {
            var urun = _context.Urunler.Find(id);

            if (urun == null)
            {
                return NotFound();
            }

            urun.IsDeleted = true;
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult SearchUrunler(
            [FromQuery] string? adi,
            [FromQuery] string? kodu,
            [FromQuery] string? marka,
            [FromQuery] decimal? minFiyat,
            [FromQuery] decimal? maxFiyat)
        {
            var urunler = _context.Urunler.Where(u => (string.IsNullOrEmpty(adi) || u.Adi.Contains(adi)) &&
                                                       (string.IsNullOrEmpty(kodu) || u.Kodu.Contains(kodu)) &&
                                                       (string.IsNullOrEmpty(marka) || u.Marka.Contains(marka)) &&
                                                       (!minFiyat.HasValue || u.Fiyat >= minFiyat) &&
                                                       (!maxFiyat.HasValue || u.Fiyat <= maxFiyat) &&
                                                       (u.IsDeleted == false)).ToList();

            return Ok(urunler);
        }
    }
}
