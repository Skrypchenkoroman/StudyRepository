using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace MyWebSite.Models
{
    public class CustomRepository<T> : IRepository<T> where T : class
    {
        private bool disposed = false;
     
        private CustomDbContext db;
        private DbSet<T> dbSet;

        /*private IEnumerable<ShoppingCart> resultShoppingCarts;
        private IEnumerable<Product> resultProducts;
        
        private IEnumerable<Supplier> resultSuppliers;*/
        private IEnumerable<Client> resultClients;

        public CustomRepository()
        {
            this.db = new CustomDbContext();
            db.Configuration.AutoDetectChangesEnabled = true;
            dbSet = db.Set<T>();

            resultClients = (IEnumerable<Client>)db.Clients;
            /*resultSuppliers = (IEnumerable<Supplier>)db.Suppliers;
            resultProducts = (IEnumerable<Product>)db.Products;
            resultShoppingCarts = (IEnumerable<ShoppingCart>)db.ShoppingCarts;
            
            foreach (var r in resultShoppingCarts.ToArray())
            {
                r.Client = resultClients.ToList().Find(m => m.ClientID == r.ClientID);
                r.Product = resultProducts.ToList().Find(m => m.ProductID == r.ProductID);
                r.Product.Supplier = resultSuppliers.ToList().Find(m => m.SupplierID == r.Product.SupplierID);
            }

            foreach (var r in resultProducts.ToArray())
            {
                r.Supplier = resultSuppliers.ToList().Find(m => m.SupplierID == r.SupplierID);
            }*/
        }

        public IEnumerable<T> GetList()
        {
            return dbSet;
        }

        public T Get(int id) 
        { 
            return dbSet.Find(id);
        }

        public void Create(T item) 
        {
            dbSet.Add(item);
            Save();
        }

        public void Update(T newItem, T oldItem)
        {
            db.Entry(oldItem).CurrentValues.SetValues(newItem);
            Save();
        }

        public void Delete(T item) 
        {
            dbSet.Remove(item);
            Save();
        }

        public void Save() 
        {
            db.SaveChanges(); 
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}