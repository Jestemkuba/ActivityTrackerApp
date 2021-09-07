using ActivityTrackerApp.Commands;
using ActivityTrackerApp.ViewModels;
using Rg.Plugins.Popup.Contracts;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ActivityTrackerApp.Popups.ViewModels
{
    class DialogPopupViewModel : BaseViewModel
    {
        private readonly IPopupNavigation _popupNavigation;
        private string _content;
        private ICommand _closePopupCommand;

        public DialogPopupViewModel(
            string content,
            IPopupNavigation popupNavigation)
        {
            Content = content;
            _popupNavigation = popupNavigation;
        }

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        public ICommand ClosePopupCommand => _closePopupCommand ??= new AsyncCommand(ClosePopup);

        private async Task ClosePopup()
        {
            await _popupNavigation.PopAsync();
        }
    }
}
