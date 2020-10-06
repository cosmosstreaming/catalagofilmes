using Catalogo.Models;
using Catalogo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Catalogo.Controllers
{
    [Route("api/Genero")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly GeneroService _generoService;

        public GeneroController(GeneroService generoService) =>
            this._generoService = generoService;

        [HttpGet]
        public List<Genero> Get() =>
            this._generoService.Get();

        [HttpPost]
        public Genero Insert([FromBody] Genero Genero) =>
            this._generoService.Insert(Genero);

        [HttpDelete("{id}")]
        public void Delete(string id) =>
            _generoService.Remove(id);
    }
}