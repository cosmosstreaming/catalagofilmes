using Catalogo.Models;
using Catalogo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Catalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService _filmeService;

        public FilmeController(FilmeService filmeService) =>
            this._filmeService = filmeService;

        [HttpGet]
        public List<Filme> Get() =>
            this._filmeService.Get();

        [HttpGet("Genero/{IdGenero}")]
        public List<Filme> Get([FromRoute] string IdGenero) =>
            this._filmeService.GetByGenero(IdGenero);

        [HttpPost]
        public Filme Insert([FromBody] Filme Genero) =>
            this._filmeService.Insert(Genero);
    }
}