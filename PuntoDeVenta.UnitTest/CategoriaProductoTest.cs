using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Context;
using PuntoDeVenta.DTOs;
using PuntoDeVenta.Mappings;
using PuntoDeVenta.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PuntoDeVenta.UnitTest
{
    public class CategoriaProductoTest
    {
        private readonly CategoriaProductoRepository _categoriaProductoRepository;
        public CategoriaProductoTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>().UseSqlServer("Data Source=.;Initial Catalog=PuntoVenta;Integrated Security=True ; Trust Server Certificate = True").Options;

            var dbContext = new ApplicationDBContext(options);

            var configurations = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = configurations.CreateMapper();

            _categoriaProductoRepository = new CategoriaProductoRepository(dbContext, mapper);
        }
        [Fact]
        public async void TestCrear()
        {
            var obj = new CategoriaProductDTO();
            obj.Nombre = "Algo";

            int resultado = await _categoriaProductoRepository.Crear(obj);

            Assert.True(resultado == 1);
        }
        [Fact]
        public async void TestModificar() 
        {
           
            var obj = new CategoriaProductDTO();
            obj.Nombre = "Categoría Original";

            int insercionExitosa = await _categoriaProductoRepository.Crear(obj);

            
            Assert.True(insercionExitosa == 1);

        
            int idCategoriaProducto = 2;

           
            obj.Nombre = "Categoría Modificada";

           
            int modificacionExitosa = await _categoriaProductoRepository.Modificar(idCategoriaProducto, obj);

            
            Assert.True(modificacionExitosa == 1);
        }
        [Fact]
        public async void TestEliminar()
        {
            
            int idCategoriaProducto = 3; 
         
            int eliminacionExitosa = await _categoriaProductoRepository.Eliminar(idCategoriaProducto);

            
            Assert.True(eliminacionExitosa == 1);
        }

        [Fact]
        public async void TestObtenerTodos()
        {
            // Act: Retrieve all categories
            var categorias = await _categoriaProductoRepository.CategoriasProductos();

            // Assert: Check if the retrieved categories are not null and contain at least one category
            Assert.NotNull(categorias);
            Assert.NotEmpty(categorias);
        }

    }
}
