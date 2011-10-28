
namespace Chat.DataAccess.Data
{
    public class AppManager
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
    }
}
    
