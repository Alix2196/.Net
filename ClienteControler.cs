using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using NetCoreYoutobe.Models;
using System.Collections.Generic;

namespace NetCoreYoutobe.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ControllerBase
    {

        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    id = "1",
                    correo = "correo@correo",
                    edad = "29",
                    nombre = "Duvan Torres"
                },
                new Cliente
                {
                    id = "2",
                    correo = "correo@correo",
                    edad = "3",
                    nombre = "Jackito Torres Meneses"
                }
            };
            return clientes;
        }

        [HttpGet]
        [Route("listarxid")]
        public dynamic listarClientexid(int _id)
        {

            Cliente cliente = new Cliente
            {
                id = _id.ToString(),
                correo = "correo@correo",
                edad = "29",
                nombre = "Duvan Torres"
            };
            return cliente;
        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            cliente.id = "3"; 
            return new
            {
                success = true,
                message = "Cliente registrado",
                result = cliente
            };
        }

        [HttpDelete]
        [Route("Eliminar")]
        public dynamic eliminarCliente(Cliente cliente)
        {
            var authorizationHeader = Request.Headers.FirstOrDefault(header => header.Key == "Authorization");

            if (authorizationHeader.Equals(default(KeyValuePair<string, StringValues>)))
            {
                return new
                {
                    success = false,
                    message = "Error de autenticación: Token inválido",
                    result = cliente
                };
            }

            string token = authorizationHeader.Value;

            // Verificar si el token es nulo o vacío antes de continuar
            if (string.IsNullOrEmpty(token) || token != "alix123")
            {
                return new
                {
                    success = false,
                    message = "Error de autenticación: Token inválido",
                    result = ""
                };
            }

            return new
            {
                success = true,
                message = "Cliente eliminado exitosamente",
                result = cliente
            };
        }
    }
}
