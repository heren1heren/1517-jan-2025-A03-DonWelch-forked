
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        #region setup the context connection variable and class constructor
        private readonly WestWindContext _context;

        //constructor to be used in the creation of the instance of this class
        //the registered reference for the context connection (database connection)
        //  will be passed from the IServiceCollection registered services
        internal ProductServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        //Queries

        //retreive the products for a given category id
        //public List<Product> Product_GetByCategoryID(int categoryid)
        //{
        //    IEnumerable<Product> info = _context.Products
        //                                        .Where(x => x.CategoryID == categoryid)
        //                                        .OrderBy(x => x.ProductName);
        //    return info.ToList();
        //}

        public List<Product> Product_GetByCategoryID(int categoryid)
        {
            IEnumerable<Product> info = _context.Products
                                                .Include(x => x.Supplier)
                                                .Where(x => x.CategoryID == categoryid)
                                                .OrderBy(x => x.ProductName);
            return info.ToList();
        }

        public Product Product_GetByID(int productid)
        {
            Product info = _context.Products
                                    .Where(x => x.ProductID == productid)
                                    .FirstOrDefault();
            return info;

            //alternatives: .Find(pKeyvalue)
            //return _context.Products.Find(productid);
        }
    }
}
