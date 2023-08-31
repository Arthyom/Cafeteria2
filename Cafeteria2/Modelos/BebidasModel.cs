using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace Cafeteria2.Modelos
{
    [ExcludeFromCodeCoverage]
    public class BebidasModel
    {
        CafeteriaConexionDataContext _db;

        public BebidasModel()
        {

        }


        public BebidasModel(CafeteriaConexionDataContext db)
        {
            _db = db;
        }

        public virtual List<Bebidas> GetAll()
        {
            return _db.Bebidas.ToList();
        }


        public virtual Bebidas GetById(int id)
        {
            return _db.Bebidas.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}