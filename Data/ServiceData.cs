using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ServiceData
    {
        public List<GetFacturas_Sp_Result> GetFacturas()
        {
            try
            {
                PruebaSodEntities db = new PruebaSodEntities();
                return db.Database.SqlQuery<GetFacturas_Sp_Result>("GetFacturas_Sp").ToList();
            }catch(Exception ex)
            {
                return null;
            }
           
        }
        public GetFactura_Sp_Result GetFactura(int id)
        {
            try
            {
                PruebaSodEntities db = new PruebaSodEntities();
                return db.Database.SqlQuery<GetFactura_Sp_Result>("GetFactura_Sp @id", new SqlParameter("@id", id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<GetProductosfactura_Sp_Result> GetFacturaporproducto(int id)
        {
            try
            {
                PruebaSodEntities db = new PruebaSodEntities();
                return db.Database.SqlQuery<GetProductosfactura_Sp_Result>("GetProductosfactura_Sp @id", new SqlParameter("@id", id)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public string DeleteFactura(int id)
        {
            try
            {
                PruebaSodEntities db = new PruebaSodEntities();
                db.Database.ExecuteSqlCommand("DeleteFactura_Sp @idFactura", new SqlParameter("@idFactura", id));
                return "ok";
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public string Deleteproductosporfactura(int id)
        {
            try
            {
                PruebaSodEntities db = new PruebaSodEntities();
                db.Database.ExecuteSqlCommand("DeleteProductosporfactura_Sp @id", new SqlParameter("@id", id));
                return "ok";
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
