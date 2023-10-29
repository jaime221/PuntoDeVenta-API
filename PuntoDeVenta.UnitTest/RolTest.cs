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

namespace PuntoDeVenta.UnitTest
{
    public class RolTest
    {
        private readonly RolRepository _rolRepository;
        public RolTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>().UseSqlServer("Data Source=.;Initial Catalog=PuntoVenta;Integrated Security=True ; Trust Server Certificate = True").Options;

            var dbContext = new ApplicationDBContext(options);

            var configurations = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = configurations.CreateMapper();

            _rolRepository = new RolRepository(dbContext, mapper);
        }
        [Fact]
        public async void TestCrear()
        {
            var obj = new RolDTO();
            obj.Nombre = "Algo";

            int resultado = await _rolRepository.Crear(obj);

            Assert.True(resultado == 1);
        }
        [Fact]
        public async void TestModificar()
        {

            var obj = new RolDTO();
            obj.Nombre = "rol Original";

            int insercionExitosa = await _rolRepository.Crear(obj);


            Assert.True(insercionExitosa == 1);


            int idRol = 14;


            obj.Nombre = "rol Modificado";


            int modificacionExitosa = await _rolRepository.Modificar(idRol, obj);


            Assert.True(modificacionExitosa == 1);
        }
        [Fact]
        public async void TestEliminar()
        {

            int idRol = 14;

            int eliminacionExitosa = await _rolRepository.Eliminar(idRol);


            Assert.True(eliminacionExitosa == 1);
        }

        [Fact]
        public async void TestObtenerTodos()
        {

            var roles = await _rolRepository.Roles();

            Assert.NotNull(roles);
            Assert.NotEmpty(roles);
        }
        [Fact]
        public async void TestObtenerPorId()
        {

            int idRol = 15;


            var rol = await _rolRepository.Roles(idRol);


            Assert.NotNull(rol);


            Assert.Equal(idRol, rol.Id);


        }


    }
}

