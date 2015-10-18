using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data;

namespace Negocio
{
    public class UsuarioLogic : BusinessLogic
    {
        private Data.Database.UsuarioAdapter UsuarioData;

        public UsuarioLogic()
        {
            UsuarioData = new Data.Database.UsuarioAdapter();
        }

        public Usuario GetOne(int ID)
        {
            try
            {
                return UsuarioData.GetOne(ID);
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        public List<Usuario> GetAll()
        {
            try
            {
                return UsuarioData.GetAll();
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        public void Save(Usuario usr)
        {
            try
            {
                UsuarioData.Save(usr);
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                UsuarioData.Delete(ID);
            }
            catch (Exception Ex)
            {
                throw;
            }
        }
    }
}
