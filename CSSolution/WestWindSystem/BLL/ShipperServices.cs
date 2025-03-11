using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additonal Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion


namespace WestWindSystem.BLL
{
    public class ShipperServices
    {
        #region setup of the context connection variable and class constructor

        private readonly WestWindContext _context;

        internal ShipperServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        #region Services
        //retrieve all shippers
        public List<Shipper> Shipper_GetAll()
        {
            IEnumerable<Shipper> info = _context.Shippers;
            return info.ToList();

            //return _context.Shippers.ToList();
        }
        #endregion
    }
}
