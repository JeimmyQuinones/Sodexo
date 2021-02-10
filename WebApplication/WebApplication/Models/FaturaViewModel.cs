using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class FaturaViewModel
    {
        public string RazonSocial { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public long Telefono { get; set; }
        public int Nit { get; set; }
        public double Subtotal { get; set; }
        public int Id { get; set; }
        public double Total { get; set; }
    }
}