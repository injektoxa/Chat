using System.Web;
using Chat.BusinessLogic.Data;
using Chat.Presentation.Controls.Model.Impl;
using Chat.Presentation.Controls.Presenter.Interfaces;
using Chat.Presentation.Controls.View.Interfaces;

namespace Chat.Presentation.Controls.Presenter.Impl
{
    public class MessagesControlPresenter 
    {
        private readonly IMessagesControlView _view;
      
        public MessagesControlPresenter(IMessagesControlView view)
        {
            _view = view;
        }

        #region Implementation of IMessageControlPresenter
        #endregion
    }
}