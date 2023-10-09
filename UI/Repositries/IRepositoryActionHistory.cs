namespace UI.Repositries
{
    public interface IRepositoryActionHistory
    {
        public Task<Entity.ActionHistory> InsertGeneralActionHistory(int GeneralRequestID);
        public Entity.ActionHistory GetLastActionHistory(Int64 RequestID);
    }
}
