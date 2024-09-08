namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IEventsRepository Events { get; }
        IUsersRepository Users { get; }
        ILinkLineRepository LinkLines { get; } // Yeni eklenen satır

        void Save();
    }
}