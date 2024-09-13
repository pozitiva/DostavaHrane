using DostavaHrane.AplikacioniSloj.Interfejsi;
using Microsoft.Extensions.Configuration;

namespace DostavaHrane.Kontroleri
{
    public class MusterijaKontroler
    {
        private readonly IMusterijaServis _musterijaServis;
        public MusterijaKontroler(IMusterijaServis musterijaServis)
        {

            _musterijaServis = musterijaServis;

        }
    }
}
