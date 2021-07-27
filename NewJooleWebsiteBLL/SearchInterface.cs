using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewJooleWebsiteEntities;
using NewJooleWebsiteRepo;

namespace NewJooleWebsiteBLL
{
    public interface SearchTblCategoryInterface : Repo<tblCategory>
    {
        IEnumerable<tblCategory> GetList();
    }
    public interface SearchTblSubCategoryInterface : Repo<tblSubcategory>
    {
        IEnumerable<tblSubcategory> GetList();
    }
}