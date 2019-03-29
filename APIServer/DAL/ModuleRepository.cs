using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Models;

namespace APIServer.DAL
{
    public class ModuleRepository : IModuleRepository
    {
        private ModelContext context;

        public ModuleRepository(ModelContext context)
        {
            this.context = context;
        }
        ModuleRepository() { }

        public void Dispose()
        {
            context.Dispose();
        }

        public List<Module> GetAll()
        {
            return context.Modules.ToList();
        }

        public Module GetById(int Id)
        {
            return context.Modules.FirstOrDefault(m => m.ID == Id);
        }

        public Module Add(Module item)
        {
            Module addedModule = context.Modules.Add(item);
            context.SaveChanges();
            return addedModule;
        }

        public bool Remove(int id)
        {
            Module module = GetById(id);
            if (module == null)
            {
                return false;
            }

            context.Modules.Remove(module);
            context.SaveChanges();
            return true;
        }

        public bool Edit(Module item)
        {
            try
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}