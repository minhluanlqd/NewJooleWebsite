using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NewJooleWebsiteBLL
{
    interface UnitofWorkInterace
    {
        ProductInterface products { get;}
        UserInterface users { get; }

    }
    public class UnitofWork : DbContext, UnitofWorkInterace
    {
        private readonly DbContext context;

        public UnitofWork(DbContext context)
        {
            this.context = context;
        }
        public UserInterface users => new UserRepo(context);
        public SearchTblCategoryInterface categorySearch => new SearchRepo(context);
        public SearchTblSubCategoryInterface subCategorySearch => new SearchRepo(context);
        public ProductInterface products => new ProductRepo(context);
    }
}