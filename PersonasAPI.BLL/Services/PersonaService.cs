using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonasAPI.BLL.ViewModels;
using PersonasAPI.DAL.Data;
//using PersonasAPI.DAL.Data;
using PersonasAPI.DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasAPI.BLL.Services
{
    public class PersonaService
    {
        private PersonasContext _context;
        public PersonaService(PersonasContext context)
        {
            _context = context;
        }

        public void AddPersona(PersonaVM persona)
        {
            var _persona = new Persona()
            {
                IdDocumento = persona.IdDocumento,
                IdGenero = persona.IdGenero,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                NumeroDocumento = persona.NumeroDocumento,
                FechaNacimiento = persona.FechaNacimiento,
                FechaCreacion = DateTime.Now,
                FechaActualizacion = DateTime.Now,
            };

            _context.Personas.Add(_persona);
            _context.SaveChanges();
        }

        public string calcularRango(Object nacimiento)
        {
            TimeSpan edadDiff = DateTime.Now.Subtract((DateTime)nacimiento);
            var edad = (int)(edadDiff.TotalDays / 365);
            string range;
            if (edad <= 14)
            {
                range = "Niño";
                return range;
            }
            else if (edad >= 15 && edad <= 20)
            {
                range = "Adolescente";
                return range;
            }
            else if (edad >= 21 && edad <= 60)
            {
                range = "Mayor de edad";
                return range;
            }
            else if (edad >= 61)
            {
                range = "Tercera edad";
                return range;
            }
            else
            {
                range = "Fuera de rango";
                return range;
            }
        }
        public List<PersonaConEdadVM> getPersonas()
        {
            var personas = _context.Personas.ToList();
            List<PersonaConEdadVM> lista = new List<PersonaConEdadVM>();

            foreach (Persona persoEdad in personas)
            {
                var range = calcularRango(persoEdad.FechaNacimiento);

                lista.Add(new PersonaConEdadVM()
                {
                    Apellido = persoEdad.Apellido,
                    Nombre = persoEdad.Nombre,
                    FechaNacimiento = persoEdad.FechaNacimiento,
                    NumeroDocumento = persoEdad.NumeroDocumento,
                    IdDocumento = persoEdad.IdDocumento,
                    IdGenero = persoEdad.IdGenero,
                    rango = range
                });
            }
            return lista;
        }

        public PersonaConEdadVM getPersonaById(int Id)
        {

            var persona = _context.Personas.FirstOrDefault(pers => pers.Id == Id);

            var range = calcularRango(persona.FechaNacimiento);

            var personaEdad = new PersonaConEdadVM()
            {
                Apellido = persona.Apellido,
                Nombre = persona.Nombre,
                FechaNacimiento = persona.FechaNacimiento,
                NumeroDocumento = persona.NumeroDocumento,
                IdDocumento = persona.IdDocumento,
                IdGenero = persona.IdGenero,
                rango = range
            };

            return personaEdad;
        }

        public PersonaConEdadVM updatePersona(int Id, PersonaVM persona)
        {
            var _persona = _context.Personas.FirstOrDefault(pers => pers.Id == Id);
            if (_persona != null)
            {
                _persona.IdDocumento = persona.IdDocumento;
                _persona.IdGenero = persona.IdGenero;
                _persona.Nombre = persona.Nombre;
                _persona.Apellido = persona.Apellido;
                _persona.NumeroDocumento = persona.NumeroDocumento;
                _persona.FechaNacimiento = persona.FechaNacimiento;
                _persona.FechaActualizacion = DateTime.Now;
                _context.SaveChanges();
            }

            var range = calcularRango(_persona.FechaNacimiento);

            var personaEdad = new PersonaConEdadVM()
            {
                Apellido = _persona.Apellido,
                Nombre = _persona.Nombre,
                FechaNacimiento = _persona.FechaNacimiento,
                NumeroDocumento = _persona.NumeroDocumento,
                IdDocumento = _persona.IdDocumento,
                IdGenero = _persona.IdGenero,
                rango = range
            };


            return personaEdad;
        }

        public void DeletePersona(int Id)
        {
            var _persona = _context.Personas.FirstOrDefault(pers => pers.Id == Id);
            if (_persona != null)
            {
                _context.Personas.Remove(_persona);
                _context.SaveChanges();
            }
        }
    }
}

