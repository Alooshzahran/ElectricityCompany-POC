namespace UI.Repositries
{
    public interface IRepositoryAction
    {
        public IEnumerable<Entity.Action> GetAllAction();
    }
}
