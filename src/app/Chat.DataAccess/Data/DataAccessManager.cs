using System.Data.Linq;
using Chat.Core.Impl;
using Chat.Core.Interfaces;
using Chat.DataAccess.Interfaces;

namespace Chat.DataAccess.Data
{
    public static class DataAccessManager
    {
        public static DataClassesDataContext Context { set; get; }

        public static void CreateContext()
        {
            Context = new DataClassesDataContext();
        }

        public static void CloseContext()
        {
            Context.Dispose();
        }

        public static void Initialize()
        {
            IContainer container = ContainerService.Instance;
            
            //registar generated types with base LINQ context
            var ctx = new DataClassesDataContext();
            container.RegisterInstance<DataContext>(ctx);
            
            //register SQLRepository with IRepository
            container.Register(typeof(IRepository<User>), typeof(SqlRepository<User>));
            container.Register(typeof(IRepository<Room>), typeof(SqlRepository<Room>));
            container.Register(typeof(IRepository<Message>), typeof(SqlRepository<Message>));
            container.Register(typeof(IRepository<User_Role>), typeof(SqlRepository<User_Role>));
        }
    }
}
    
