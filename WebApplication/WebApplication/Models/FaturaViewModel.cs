using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class FaturaViewModel
    {
        public string RazonSocial { get; set; }
        
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public long Telefono { get; set; }
        [Required]
        public int Nit { get; set; }
        public double Subtotal { get; set; }
        public int Id { get; set; }
        public double Total { get; set; }
    }
    public class FaturaEditViewModel : FaturaViewModel
    {
        public IEnumerable<SelectListItem> Clientes { get; set; }
        public IEnumerable<SelectListItem> Productos { get; set; }
        public int productint { get; set; }
    }
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Valorunidad { get; set; }
        public int porcentaje { get; set; }
    }
    public class ProductaddViewModel
    {
        public int IdProduct { get; set; }
        public int Cantidad { get; set; }

    }
    public class ClientViewModel
    {
        public int Nit { get; set; }
        public string RazonSocial { get; set; }
        public long Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
    }


    }