using RazApp.Data.DatabaseContext;

namespace RazApp.Data.Infrastructure
{
    public interface IDatabaseFactory
    {
        AppEntities Get();
    }
}
