using Chat.Core.Interfaces;

namespace Chat.Core.Impl
{
    public class ChatLoggerService //: IChatLoggerService
    {
        public static IChatLogger Instance
        {
            get
            {
                return ContainerService.Instance.Resolve<IChatLogger>();
            }
        }
    }
}