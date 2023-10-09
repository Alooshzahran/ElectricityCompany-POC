using Connecter.Client;
using Entity;
using Entity.Repository;
using Repository;

namespace UI.Repositries
{
    public class RepositoryServices : IRepositoryServices
    {
        private MyDbContext _context { get; set; }
       
        public RepositoryServices(MyDbContext context)
        {
            _context = context;
          
        }
        public IEnumerable<Entity.Service> GetAllServices()
        {
            List<Service> services = _context.Services.ToList();
            return services;
        }
    }
}
