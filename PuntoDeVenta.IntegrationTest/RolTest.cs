using Microsoft.AspNetCore.Mvc.Testing;
using PuntoDeVenta.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.IntegrationTest
{
    [TestClass]
    public class RolTest
    {
        [TestMethod]
        public async Task GuardarRol()
        {
            using var application = new WebApplicationFactory<Program>();
            using var rol = application.CreateClient();

            var objeto = new RolDTO { Nombre = "jhs" };
            var respuesta = await rol.PostAsJsonAsync("api/roles", objeto);

            Assert.AreEqual(HttpStatusCode.Created, respuesta.StatusCode);
        }

        [TestMethod]
        public async Task ModificarRol()
        {
            using var application = new WebApplicationFactory<Program>();
            using var rol = application.CreateClient();

            var objeto = new RolDTO { Id = 1, Nombre = "xd" };
            //cliente.DefaultRequestHeaders.Add("Authorization", "Bearer");
            var respuesta = await rol.PutAsJsonAsync("api/roles/1", objeto);
            Assert.AreEqual(HttpStatusCode.OK, respuesta.StatusCode);
        }

        [TestMethod]
        public async Task EliminarRol()
        {
            using var application = new WebApplicationFactory<Program>();
            using var rol = application.CreateClient();

            var objeto = new RolDTO { Id = 4 };
            //cliente.DefaultRequestHeaders.Add("Authorization", "Bearer");
            var respuesta = await rol.DeleteAsync("api/roles/4");
            Assert.AreEqual(HttpStatusCode.NoContent, respuesta.StatusCode);
        }

        [TestMethod]
        public async Task ObtenerRoles()
        {
            using var application = new WebApplicationFactory<Program>();
            using var rol = application.CreateClient();


            var respuesta = await rol.GetFromJsonAsync<List<RolDTO>>("api/roles");

            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]
        public async Task ObtenerRolPorId()
        {
            using var application = new WebApplicationFactory<Program>();
            using var rol = application.CreateClient();

            var respuesta = await rol.GetFromJsonAsync<RolDTO>("api/roles/2");

            Assert.IsTrue(respuesta != null);
        }
    }
}
