using PersonasAPI.BLL.ViewModels;
using PersonasAPI.DAL.Data;
using PersonasAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasAPI.BLL.Services
{
    public class GeneroService
    {
        private PersonasContext _context;
        public GeneroService(PersonasContext context)
        {
            _context = context;
        }

        public void AddGenero(GeneroVM genero)
        {
            var _genero = new Genero()
            {
                GeneroName = genero.GeneroName,
            };

            _context.Generos.Add(_genero);
            _context.SaveChanges();
        }

        public List<Genero> getGeneros()
        {
            return _context.Generos.ToList();
        }

        public Genero getGeneroById(byte Id)
        {
            return _context.Generos.FirstOrDefault(gen => gen.Id == Id);
        }

        public Genero updateGenero(byte Id, GeneroVM genero)
        {
            var _genero = _context.Generos.FirstOrDefault(gen => gen.Id == Id);
            if (_genero != null)
            {
                _genero.GeneroName = genero.GeneroName;
                _context.SaveChanges();
            }

            return _genero;
        }

        public void DeleteGenero(byte Id)
        {
            var _genero = _context.Generos.FirstOrDefault(gen => gen.Id == Id);
            if (_genero != null)
            {
                _context.Generos.Remove(_genero);
                _context.SaveChanges();
            }
        }
    }
}
