/*
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace DataAccess
{
    public static class TareasRepository
    {
        public static List<Tarea> GetList()
        {
            try
            {
                using (var context = Utiles.ContextoLocal())
                {
                    return (from p in context.Tarea
                            select p).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ErrorHelper.dbError(ex));
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un problema, no se pudo obtener la información.");
            }
        }

        public static Tarea Get(int id)
        {
            try
            {
                using (var context = Utiles.ContextoLocal())
                {
                    return (from p in context.Tarea
                            where p.id == id
                            select p).FirstOrDefault();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ErrorHelper.dbError(ex));
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un problema, no se pudo obtener la información.");
            }
        }

        public static void Update(Tarea varia)
        {
            try
            {
                using (var context = Utiles.ContextoLocal())
                {
                    var viejo =
                        context.Tarea.Attach(context.Tarea.Single(i => i.id == varia.id));

                    context.Entry(viejo).CurrentValues.SetValues(varia);

                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ErrorHelper.dbError(ex));
            }
        }

        public static void Insert(Tarea varia)
        {
            try
            {
                using (var context = Utiles.ContextoLocal())
                {
                    context.Tarea.Add(varia);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ErrorHelper.dbError(ex));
            }
           
        }
    }

}
*/