﻿using DostavaHrane.Data;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using Microsoft.EntityFrameworkCore;

namespace DostavaHrane.Repozitorijum
{
    public class RestoranRepozitorijum : IRestoranRepozitorijum
    {
        private readonly DataContext _context;
        public RestoranRepozitorijum(DataContext context)
        {
            _context = context;
        }
        public async Task DodajAsync(Restoran restoran)
        {
            _context.Add(restoran);
            await _context.SaveChangesAsync();
        }

        public Task IzmeniAsync(Restoran restoran)
        {
            throw new NotImplementedException();
        }

        public Task ObrisiAsync(Restoran restoran)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Restoran>> PretraziRestorane(string naziv, string tip)
        {
            //return await _context.Restorani
            //    .Include(r => r.Jela)
            //    .Where(r =>
            //        (naziv == null || r.Ime.Contains(naziv, StringComparison.OrdinalIgnoreCase)) &&
            //        (tip == null || r.Jela.Any(j => j.TipJela.Contains(tip, StringComparison.OrdinalIgnoreCase)))
            //    )
            //    .ToListAsync();


            var query = _context.Restorani.AsQueryable();

            // Apply filters if parameters are provided
            if (!string.IsNullOrWhiteSpace(naziv))
            {
                query = query.Where(r => r.Ime.Contains(naziv));
            }

            if (!string.IsNullOrWhiteSpace(tip))
            {
                query = query.Where(r => r.Jela.Any(j => j.TipJela.Contains(tip)));
            }

            return await query.Include(r => r.Jela).ToListAsync();

        }

        public async Task<Restoran> VratiPoIdAsync(int id)
        {

            return await _context.Restorani
                         .Include(r => r.Jela)
                         .Where(r => r.Id == id)
                         .FirstOrDefaultAsync();
        }

        public async Task<Restoran> VratiRestoranSaEmailom(KorisnikLoginDto restoran)
        {
            return await _context.Restorani
                          .Where(u => u.Email == restoran.Email)
                          .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranuAsync(int restoranId)
        {
            return await _context.Jela.Where(e => e.Restoran.Id == restoranId).ToListAsync();
        }

        public async Task<IEnumerable<Restoran>> VratiSveAsync()
        {
            return await _context.Restorani.Include(r => r.Jela).ToListAsync();
        }
    }
}
