using Docker.Domain.Entities;
using Docker.Domain.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Docker.Api.Controllers
{
    [ApiController, AllowAnonymous, Route("v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IValidator<Usuario> _usuarioValidator;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(
            IValidator<Usuario> usuarioValidator,
            IUsuarioService usuarioService)
        {
            _usuarioValidator = usuarioValidator;
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            try
            {
                return Ok(_usuarioService.List());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Store([FromBody] Usuario usuario)
        {
            try
            {
                var validacao = _usuarioValidator.Validate(usuario);

                if (!validacao.IsValid)
                    return BadRequest(validacao.Errors);

                _usuarioService.Store(usuario);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
