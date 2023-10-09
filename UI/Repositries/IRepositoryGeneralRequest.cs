namespace UI.Repositries
{
    public interface IRepositoryGeneralRequest
    {
        public Int64 NewProcessID();
        public Task<Entity.GeneralRequest> InsertGeneralRequest(int TableID, int ServiceTypeID, int StepID);
        public Entity.GeneralRequest Get(int ProcessId);
        public Entity.GeneralRequest GetByID(int id);
        public Entity.GeneralRequest Update(Entity.GeneralRequest GeneralRequest);
        IEnumerable<Entity.GeneralRequest> GetAll();
    }
}
