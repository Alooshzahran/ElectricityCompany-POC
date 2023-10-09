using Entity.Repository;

namespace UI.Repositries
{
    public class RepositoryAction : IRepositoryAction
    {
        private MyDbContext _context { get; set; }
        public RepositoryAction(MyDbContext context) {
            _context = context;
        }

        public IEnumerable<Entity.Action> GetAllAction()
        {
            List<Entity.Action> actions = _context.Actions.ToList();
            return actions;
        }
    }
}
