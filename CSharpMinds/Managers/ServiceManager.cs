using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Managers
{
    public class ServiceManager : IServiceManager
    {
        List<IService> services;
        public List<IService> Services
        {
            get { return services; }
        }

        public ServiceManager()
        {
            services = new List<IService>();
        }

        public void AddService(IService service)
        {
            services.Add(service);
        }

        public void Remove(IService service)
        {
            services.Remove(service);
        }

        List<IService> IServiceManager.services {
            get { throw new NotImplementedException(); }
        }

        public IService FindWtihName(string name) {
            throw new NotImplementedException();
        }
    }
}
