/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DataAccess;
using Entities;

namespace BusinessLogic
{
    public static class TareasAdmin
    {
        public static Tarea GetList()
        {
            try
            {
                return TareasRepository.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Tarea Get(int id)
        {
            try
            {
                return TareasRepository.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertOrUpdate(Tarea model)
        {
            try
            {
                if (model.AsiAutAsg_Id > 0)
                {
                    TareasRepository.Update(model);
                }
                else
                {
                    TareasRepository.Insert(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete(int id)
        {
            try
            {
                TareasRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un problema, no se pudo eliminar.");
            }
        }
    }
}
 */ 