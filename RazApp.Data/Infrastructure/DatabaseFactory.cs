
using RazApp.Data.DatabaseContext;

namespace RazApp.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private AppEntities dataContext;
        public AppEntities Get()
        {
            return dataContext ?? (dataContext = new AppEntities());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
