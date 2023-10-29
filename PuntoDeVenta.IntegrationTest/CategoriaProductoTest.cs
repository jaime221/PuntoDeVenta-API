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
    public class CategoriaProductoTest
    {

        [TestMethod]
        public async Task ObtenerTokenUsuario()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();

            var resuesta = await cliente.PostAsJsonAsync("api/login", new UsuarioDTO { Correo = "Jaime@gmail.com", Clave = "123" });

            var token = await resuesta.Content.ReadAsStringAsync();

            Assert.IsNotNull(token);


        }
        [TestMethod]
        public async Task GuardarCategoriaProducto()
        {
            using var application = new WebApplicationFactory<Program>();
            using var categoria = application.CreateClient();

            var objeto = new CategoriaProductDTO { Nombre = "cate" };
            var respuesta = await categoria.PostAsJsonAsync("api/categoria", objeto);

            Assert.AreEqual(HttpStatusCode.Created, respuesta.StatusCode);
        }

        [TestMethod]
        public async Task ModificarCategoriaProducto()
        {
            using var application = new WebApplicationFactory<Program>();
            using var categoria = application.CreateClient();

            var objeto = new CategoriaProductDTO { Id = 1, Nombre = "xd" };
         
            var respuesta = await categoria.PutAsJsonAsync("api/categoria/1", objeto);
            Assert.AreEqual(HttpStatusCode.OK, respuesta.StatusCode);
        }

        [TestMethod]
        public async Task EliminarCategoriaProducto()
        {
            using var application = new WebApplicationFactory<Program>();
            using var categoria = application.CreateClient();

            var objeto = new CategoriaProductDTO { Id = 2 };
            //cliente.DefaultRequestHeaders.Add("Authorization", "Bearer");
            var respuesta = await categoria.DeleteAsync("api/categoria/2");
            Assert.AreEqual(HttpStatusCode.NoContent, respuesta.StatusCode);
        }
        [TestMethod]
        public async Task ObtenerCategorias()
        {
            using var application = new WebApplicationFactory<Program>();
            using var categoria = application.CreateClient();

            categoria.DefaultRequestHeaders.Add("Authorization", "Bearer  ");
            var respuesta = await categoria.GetFromJsonAsync<List<CategoriaProductDTO>>("api/categorias");

            Assert.IsTrue(respuesta != null);
        }

        public class UsuarioDTO
        {
            public string Correo { get; set; }
            public string Clave { get; set; }

        }
    }
}
