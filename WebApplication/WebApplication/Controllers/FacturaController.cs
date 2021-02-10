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
                var model = new FaturaViewModel();
                model.Id = -1;
                model.Total = 0;
                model.Subtotal = 0;
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
        public ActionResult Edit(FaturaViewModel model)
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
