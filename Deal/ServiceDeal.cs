using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deal
{
    public class ServiceDeal
    {
        public static List<GetFacturas_Sp_Result> GetFacturas()
        {
            ServiceData db = new ServiceData();
            return db.GetFacturas();
        }
        public static GetFactura_Sp_Result GetFactura(int id)
        {
            ServiceData db = new ServiceData();
            return db.GetFactura(id);

        }
        public static List<GetProductosfactura_Sp_Result> GetFacturaporproducto(int id)
        {
            ServiceData db = new ServiceData();
            return db.GetFacturaporproducto(id);
        }
        public static string DeleteFactura(int id)
        {
            ServiceData db = new ServiceData();
            return db.DeleteFactura(id);
        }
        public static string Deleteproductosporfactura(int id)
        {
            ServiceData db = new ServiceData();
            return db.Deleteproductosporfactura(id);
        }
    }
}
