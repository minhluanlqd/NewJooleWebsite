using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NewJooleWebsiteEntities;
using NewJooleWebsiteBLL;
using System.Configuration;

namespace NewJooleWebsiteService
{
    public class Service
    {
        static string connectionString3 = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=\"data source = (localdb)\\ProjectsV13;initial catalog = JooleWebsite.DAL; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework\"";
        static DbContext context = new DbContext(connectionString3);
        UnitofWork unitofWork = new UnitofWork(context);

        private string checker(string loginName)
        {
            if (loginName.Contains("@"))
            {
                return "email";
            }
            else
            {
                return "username";
            }
        }
        private List<tblUser> filteredList(string username, string password)
        {
            tblUser temp = new tblUser();
            if (checker(username) == "email")
            {
                temp.User_Email = username;
            }
            else
            {
                temp.User_Name = username;
            }
            temp.Password = password;
            return unitofWork.users.find(temp).ToList();
        }

        

        public bool Authentication(string username, string password)
        {
            Console.WriteLine(context.Database.Exists().ToString());
            List<tblUser> list = filteredList(username, password);
            if (list.Count > 0)
            {
                if (checker(username) == "email")
                {
                    if (list.First().User_Email == username && list.First().Password == password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (list.First().User_Name == username && list.First().Password == password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        

        public string getSessionID(string username, string password)
        {
            List<tblUser> list = filteredList(username, password);
            return list.First().User_id;
        }
        public string Value()
        {
            var a = unitofWork.users.Find("UserX01");
            if (a.User_id != "")
            {
                return a.User_Name;
            }
            else
            {
                return null;
            }
        }
        public string ProductValue()
        {
            string s = "";
            var a = unitofWork.products.Find("1");
            var b = unitofWork.products.Find("2");
            var c = unitofWork.products.Find("3");
            var d = unitofWork.products.Find("4");
            var e = unitofWork.products.Find("5");
            if (a.Product_ID != "")
                s += a.Product_Name + " ";
            if (b.Product_ID != "")
                s += b.Product_Name + " ";
            if (c.Product_ID != "")
                s += c.Product_Name + " ";
            if (d.Product_ID != "")
                s += d.Product_Name + " ";
            if (e.Product_ID != "")
                s += e.Product_Name + " ";
            return s;
        }

        public string ProductSearch(string s)
        {
            string result = unitofWork.products.Search(s);
            return result;
        }
        public IQueryable<tblProduct> GetDataSet(string filter)
        {
            return unitofWork.products.DataSet(filter);
        }
        public tblProduct value(string c)
        {
            var a = unitofWork.products.Find(c);
            return a;
        }

        public List<tblCategory> GetCategories()
        {
            return unitofWork.categorySearch.GetListCategory().ToList();
        }

        public List<tblSubcategory> GetSubcategories(string categoryID)
        {
            return unitofWork.subcategorySearch.GetSubcategoBasedOnCatego(categoryID).ToList();
        }

        public List<tblProduct> GetProducts()
        {
            return unitofWork.products.GetListProduct().ToList();
        }
    }
}