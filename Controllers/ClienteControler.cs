using Microsoft.AspNetCore.Mvc;
using NetCoreYoutobe.Models;
using System.Collections.Generic;

namespace NetCoreYoutobe.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ControllerBase
    {
        /* dos apis uno para guardar y editar y el otro para listar */

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
            // Suponiendo que aquí recuperas el cliente de la base de datos
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
            cliente.id = "3"; // Asignando un ID temporal
            return new
            {
                success = true,
                message = "Cliente registrado",
                result = cliente
            };
        }
    }
}
