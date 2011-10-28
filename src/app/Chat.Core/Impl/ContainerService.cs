using Chat.Core.Interfaces;

namespace Chat.Core.Impl
{
    public class ContainerService //: IContainerService
    {
        private static IContainer _instance;

        public static IContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UnityContainerWrapper();
                }

                return _instance;
            }
        }
    }
}
