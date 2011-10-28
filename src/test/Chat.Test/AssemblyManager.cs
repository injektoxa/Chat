using Chat.DataAccess.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chat.Test
{
    [TestClass]
    public class AssemblyManager
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            DataAccessManager.Initialize();
        }
    }
}
