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
        public List<Productoes> GetProductos()
        {
            try
            {
                PruebaSodEntities db = new PruebaSodEntities();
                return db.Productoes.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public Productoes GetProducto(int id)
        {
            try
            {
                PruebaSodEntities db = new PruebaSodEntities();
                return db.Productoes.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public Impuestoes GetImpuesto(int id)
        {
            try
            {
                PruebaSodEntities db = new PruebaSodEntities();
                return db.Impuestoes.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Clientes> GetClientes()
        {
            try
            {
                PruebaSodEntities db = new PruebaSodEntities();
                return db.Clientes.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public Clientes GetCliente(int id)
        {
            try
            {
                PruebaSodEntities db = new PruebaSodEntities();
                return db.Clientes.Where(x=>x.Nit==id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
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
        public List<GetFacturaPorproducto_Sp_Result> GetFacturaporproducto(int id)
        {
            try
            {
                PruebaSodEntities db = new PruebaSodEntities();
                return db.Database.SqlQuery<GetFacturaPorproducto_Sp_Result>("GetFacturaPorproducto_Sp @id", new SqlParameter("@id", id)).ToList();
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
