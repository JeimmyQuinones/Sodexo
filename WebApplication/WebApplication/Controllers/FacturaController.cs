using AutoMapper;
using Deal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class FacturaController : Controller
    {
        public ActionResult Index()
        {
            List<GetFacturas_Sp_Result> modellist = ServiceDeal.GetFacturas();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GetFacturas_Sp_Result, FaturaViewModel>());
            var mapper = config.CreateMapper();
            var lstVm = modellist.Select(itm => mapper.Map<FaturaViewModel>(itm)).ToList();
            return View(lstVm);
            
        }

        public ActionResult Edit(int id)
        {
            if (id == -1)
            {
                var model = new FaturaEditViewModel();
                model.Id = -1;
                model.Total = 0;
                model.Subtotal = 0;
                model.RazonSocial = string.Empty;
                model.Correo = string.Empty;
                model.Direccion = string.Empty;
                model.Nit = 0;
                var ClienteList = new List<SelectListItem>();
                var clienmodel= ServiceDeal.GetClientes();
                ClienteList.Add(new SelectListItem { Value = "-1", Text = "--Seleccione un Cliente--", Selected = true });
                foreach (var il in clienmodel)
                {
                    ClienteList.Add(new SelectListItem { Value = il.Nit.ToString(), Text = il.RazonSocial+ " - " +il.Nit });
                }
                model.Clientes = ClienteList;
                var ProductList = new List<SelectListItem>();
                var Productmodel = ServiceDeal.GetProductos();
                ProductList.Add(new SelectListItem { Value = "-1", Text = "--Seleccione un Producto--", Selected = true });
                foreach (var il in Productmodel)
                {
                    ProductList.Add(new SelectListItem { Value = il.Id.ToString(), Text = il.Descripcion});
                }
                model.Productos = ProductList;
                return View(model);

            }
            else
            {
                var lis= ServiceDeal.GetFactura(id);
                var produc= ServiceDeal.GetFacturaporproducto(id);
                var model = new FaturaViewModel();
                model.Id = lis.Id;
                model.Total =lis.Subtotal ;
                model.Subtotal = lis.Subtotal;
                return View(model);
            }
            
        }
        [HttpPost]
        public ActionResult Edit(FaturaEditViewModel model)
        {
            try
            {
      

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        public string Dataclient(int id)
        {
            int idclien= Convert.ToInt16(id);
            if (idclien != -1)
            {
                var MOL = new ClientViewModel();
                var lst = ServiceDeal.GetCliente(idclien);
                MOL.RazonSocial = lst.RazonSocial;
                MOL.Telefono = lst.Telefono;
                MOL.Nit = lst.Nit;
                MOL.Direccion = lst.Direccion;
                MOL.Correo = lst.Correo;
                return Newtonsoft.Json.JsonConvert.SerializeObject(MOL);
            }
            else
            {
                return null;
            }

        }
        public string Productslist()
        {
            List<Productoes> modellist = ServiceDeal.GetProductos();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Productoes, ProductoViewModel>());
            var mapper = config.CreateMapper();
            var lstVm = modellist.Select(itm => mapper.Map<ProductoViewModel>(itm)).ToList();
            return Newtonsoft.Json.JsonConvert.SerializeObject(lstVm);
        }
        public string SaveData(string Nit, List<ProductaddViewModel> Producto)
        {
            //Guardar datos
            return "OK";

        }
        public string DataProduct(int id)
        {
            int idclien = Convert.ToInt16(id);
            if (idclien != -1)
            {
                var mol = new ProductoViewModel();
                var lst = ServiceDeal.GetProducto(idclien);
                var impu= ServiceDeal.GetImpuesto(lst.IdImpuesto);
                mol.Id = lst.Id;
                mol.Descripcion = lst.Descripcion;
                mol.Valorunidad = lst.Valorunidad;
                mol.porcentaje = impu.porcentaje;

                return Newtonsoft.Json.JsonConvert.SerializeObject(mol);
            }
            else
            {
                return null;
            }

        }
        public ActionResult Delete(int id)
        {
            try
            {
                var litproduct = ServiceDeal.GetFacturaporproducto(id);
                var model = ServiceDeal.GetFactura(id);
                if (model != null)
                {
                    foreach(var item in litproduct)
                    {
                        ServiceDeal.Deleteproductosporfactura(item.Id);
                    }
                    ServiceDeal.DeleteFactura(model.Id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
