﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PruebaSodEntities : DbContext
    {
        public PruebaSodEntities()
            : base("name=PruebaSodEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<Impuestoes> Impuestoes { get; set; }
        public virtual DbSet<Productoes> Productoes { get; set; }
        public virtual DbSet<Productosporfactura> Productosporfactura { get; set; }
    
        public virtual int AddFactura_Sp(Nullable<int> idCliente, Nullable<double> total, Nullable<double> subtotal)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            var totalParameter = total.HasValue ?
                new ObjectParameter("Total", total) :
                new ObjectParameter("Total", typeof(double));
    
            var subtotalParameter = subtotal.HasValue ?
                new ObjectParameter("Subtotal", subtotal) :
                new ObjectParameter("Subtotal", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddFactura_Sp", idClienteParameter, totalParameter, subtotalParameter);
        }
    
        public virtual int AddProductosporfactura_Sp(Nullable<int> idFactura, Nullable<int> idProducto)
        {
            var idFacturaParameter = idFactura.HasValue ?
                new ObjectParameter("IdFactura", idFactura) :
                new ObjectParameter("IdFactura", typeof(int));
    
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddProductosporfactura_Sp", idFacturaParameter, idProductoParameter);
        }
    
        public virtual int DeleteFactura_Sp(Nullable<int> idFactura)
        {
            var idFacturaParameter = idFactura.HasValue ?
                new ObjectParameter("IdFactura", idFactura) :
                new ObjectParameter("IdFactura", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteFactura_Sp", idFacturaParameter);
        }
    
        public virtual int DeleteProductosporfactura_Sp(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteProductosporfactura_Sp", idParameter);
        }
    
        public virtual ObjectResult<GetFactura_Sp_Result> GetFactura_Sp(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFactura_Sp_Result>("GetFactura_Sp", idParameter);
        }
    
        public virtual ObjectResult<GetFacturaPorproducto_Sp_Result> GetFacturaPorproducto_Sp(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFacturaPorproducto_Sp_Result>("GetFacturaPorproducto_Sp", idParameter);
        }
    
        public virtual ObjectResult<GetFacturas_Sp_Result> GetFacturas_Sp()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFacturas_Sp_Result>("GetFacturas_Sp");
        }
    
        public virtual int UpdateFactura_Sp(Nullable<int> id, Nullable<int> idCliente, Nullable<double> total, Nullable<double> subtotal)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            var totalParameter = total.HasValue ?
                new ObjectParameter("Total", total) :
                new ObjectParameter("Total", typeof(double));
    
            var subtotalParameter = subtotal.HasValue ?
                new ObjectParameter("Subtotal", subtotal) :
                new ObjectParameter("Subtotal", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateFactura_Sp", idParameter, idClienteParameter, totalParameter, subtotalParameter);
        }
    
        public virtual int UpdateProductosporfactura_Sp(Nullable<int> id, Nullable<int> idFactura, Nullable<int> idProducto)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var idFacturaParameter = idFactura.HasValue ?
                new ObjectParameter("IdFactura", idFactura) :
                new ObjectParameter("IdFactura", typeof(int));
    
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateProductosporfactura_Sp", idParameter, idFacturaParameter, idProductoParameter);
        }
    }
}
