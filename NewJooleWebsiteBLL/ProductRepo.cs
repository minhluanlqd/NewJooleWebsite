using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewJooleWebsiteRepo;
using NewJooleWebsiteEntities;
using System.Data.Entity;

namespace NewJooleWebsiteBLL
{
    public interface ProductInterface : Repo<tblProduct>
    {
        IEnumerable<tblProduct> GetListProduct();
    }
    public class ProductRepo : ProductInterface
    {
        private DbContext context;

        public ProductRepo(DbContext context)
        {
            this.context = context;
        }

        private IDbSet<tblProduct> dbSet => context.Set<tblProduct>();
        private List<tblProduct> ProductList => context.Set<tblProduct>().ToList();
        public IQueryable<tblProduct> Entities => dbSet;

        public tblProduct Find(string v)
        {
            var a = dbSet.Find(v);
            return a;
        }

        public IEnumerable<tblProduct> GetListProduct()
        {

            return ProductList;
        }

        public string Search(string searchString)
        {
            string s = "";
            var list = from p in dbSet select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                list = list.Where(product => product.Product_Name.Contains(searchString));
                foreach (var product in list)
                {
                    s += product.Product_Name + " ";
                }
            }
            //var result = from product in list
            //             where product.Product_Name == searchString
            //             select product;
            return s;
        }

        public IQueryable<tblProduct> DataSet(string filter)
        {
            if (!String.IsNullOrEmpty(filter))
            {
                var filterSet = from p in dbSet select p;
                filterSet = dbSet.Where(product => product.Product_Name.Contains(filter));
                return filterSet;
            }
            return dbSet;
        }

        public void Remove(tblProduct entity)
        {
            dbSet.Find(entity);
        }

        public IEnumerable<tblProduct> find(tblProduct v)
        {
            throw new NotImplementedException();
        }

        public void remove(tblProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}