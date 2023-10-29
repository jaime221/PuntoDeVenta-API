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
    public class ClienteTest
    {
        private readonly ClienteRepository _clienteRepository;
        public ClienteTest() 
        { 
            var options = new DbContextOptionsBuilder<ApplicationDBContext>().UseSqlServer("Data Source=DESKTOP-D4OC9KR;Initial Catalog=PuntoVenta;Integrated Security=True ; Trust Server Certificate = True").Options;
        }

    }
}
