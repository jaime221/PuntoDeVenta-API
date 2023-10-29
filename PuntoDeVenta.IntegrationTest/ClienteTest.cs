using Microsoft.AspNetCore.Mvc.Testing;
using PuntoDeVenta.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.IntegrationTest
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public async Task GuardarCliente()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();

            var objeto = new ClienteDTO { Nombre = "jhs", Apellido = "shj", Correo = "w@gmail.com", DUI = "121212", Telefono = "22222222" };
            var respuesta = await cliente.PostAsJsonAsync("api/clientes", objeto);

            Assert.AreEqual(HttpStatusCode.Created, respuesta.StatusCode);
        }

        [TestMethod]
        public async Task ModificarCliente()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();

            var objeto = new ClienteDTO { Id= 1, Nombre = "xd", Apellido = "ajbdjcbkwjvb", Correo = "wil@gmail.com", DUI = "121212", Telefono = "22222222" };
            //cliente.DefaultRequestHeaders.Add("Authorization", "Bearer");
                var respuesta = await cliente.PutAsJsonAsync("api/clientes/1", objeto);
            Assert.AreEqual(HttpStatusCode.OK,respuesta.StatusCode);
        }

        [TestMethod]
        public async Task EliminarCliente()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();

            var objeto = new ClienteDTO { Id = 4 };
            //cliente.DefaultRequestHeaders.Add("Authorization", "Bearer");
            var respuesta = await cliente.DeleteAsync("api/clientes/4");
            Assert.AreEqual(HttpStatusCode.NoContent, respuesta.StatusCode);
        }

        [TestMethod]
        public async Task ObtenerClientes()
        {
            using var application = new WebApplicationFactory<Program>();
            using var clientes = application.CreateClient();


            var respuesta = await clientes.GetFromJsonAsync<List<ClienteDTO>>("api/clientes");

            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]
        public async Task ObtenerClientePorId()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();

            var respuesta = await cliente.GetFromJsonAsync<ClienteDTO>("api/clientes/2");

            Assert.IsTrue(respuesta != null);
        }

    }
}
