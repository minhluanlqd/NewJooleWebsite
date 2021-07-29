using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NewJooleWebsiteEntities;
using NewJooleWebsiteRepo;

namespace NewJooleWebsiteBLL
{
    public interface SearchTblCategoryInterface : Repo<tblCategory>
    {
        IEnumerable<tblCategory> GetListCategory();
    }

    public interface SearchTblSubCategoryInterface : Repo<tblSubcategory>
    {
        IEnumerable<tblSubcategory> getSubCategoBasedOnCatego(string categoryID);
    }
    public class SearchRepo : SearchTblCategoryInterface, SearchTblSubCategoryInterface
    {
        DbContext Context;

        public SearchRepo(DbContext context)
        {
            this.Context = context;
        }

        public IQueryable<tblCategory> Entities => throw new NotImplementedException();

        IQueryable<tblSubcategory> Repo<tblSubcategory>.Entities => throw new NotImplementedException();


        private List<tblCategory> CategoriesList => Context.Set<tblCategory>().ToList();
        private List<tblSubcategory> subCategoriesList => Context.Set<tblSubcategory>().ToList();

        IQueryable<tblCategory> Repo<tblCategory>.Entities => throw new NotImplementedException();

        public IEnumerable<tblCategory> GetListCategory()
        {

            return CategoriesList;
        }

        public IEnumerable<tblSubcategory> getSubCategoBasedOnCatego(string categoryID)
        {
            return subCategoriesList.Where(p => p.Category_ID == categoryID);
        }

        public IEnumerable<tblCategory> find(tblCategory v)
        {
            var filteredList = CategoriesList.Where(current => current.Subcategory_Name == v.Subcategory_Name); // This is category name 
            return filteredList;
        }

        public IEnumerable<tblSubcategory> find(tblSubcategory v)
        {
            var filteredList = subCategoriesList.Where(current => current.Subcategory_Name == v.Subcategory_Name);
            return filteredList;
        }

        void Repo<tblCategory>.remove(tblCategory entity)
        {
            throw new NotImplementedException();
        }

        tblCategory Repo<tblCategory>.Find(string v)
        {
            throw new NotImplementedException();
        }

        string Repo<tblCategory>.Search(string s)
        {
            throw new NotImplementedException();
        }

        IQueryable<tblCategory> Repo<tblCategory>.DataSet(string s)
        {
            throw new NotImplementedException();
        }

        void Repo<tblSubcategory>.remove(tblSubcategory entity)
        {
            throw new NotImplementedException();
        }

        tblSubcategory Repo<tblSubcategory>.Find(string v)
        {
            throw new NotImplementedException();
        }

        string Repo<tblSubcategory>.Search(string s)
        {
            throw new NotImplementedException();
        }

        IQueryable<tblSubcategory> Repo<tblSubcategory>.DataSet(string s)
        {
            throw new NotImplementedException();
        }
    }
}