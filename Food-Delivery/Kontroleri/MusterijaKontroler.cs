using Microsoft.AspNetCore.Mvc;
using DostavaHrane.Servisi.Interfejsi;
using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Servisi;
using DostavaHrane.Entiteti;

namespace DostavaHrane.Kontroleri
{
    [Route("api/musterija")]
    [ApiController]
    public class MusterijaKontroler : ControllerBase 
    {
 
        private readonly IMusterijaServis _musterijaServis;
        private readonly IMapper _mapper;
        public MusterijaKontroler(IMusterijaServis musterijaServis, IMapper mapper)
        {
            _musterijaServis = musterijaServis;
            _mapper = mapper;

        }


       

        //[HttpGet("{musterijaId}/adrese")]
        //public async Task<IActionResult> VratiSveAdreseZaMusteriju(int musterijaId)
        //{
        //    var adrese = await _musterijaServis.VratiSveAdresePoMusterijiAsync(musterijaId);
        //    var adreseDto = _mapper.Map<List<AdresaDto>>(adrese);

        //    return Ok(adreseDto);
        //}

        //[HttpPut("{musterijaId}")]
        //public async Task<IActionResult> IzmeniKorisnickiNalog (int musterijaId, MusterijaDto izmenjenaMusterija)
        //{
        //    Musterija musterija = await _musterijaServis.VratiMusterijuPoIdAsync(musterijaId);

        //    if(musterija== null)
        //    {
        //        return NotFound("Nije pronadjena musterija");
        //    }

        //    _mapper.Map(izmenjenaMusterija, musterija);
        //    await _musterijaServis.IzmeniMusterijuAsync(musterija);

        //    return Ok("Korisnicki nalog je uspesno izmenjen");
        //}
    }


}
