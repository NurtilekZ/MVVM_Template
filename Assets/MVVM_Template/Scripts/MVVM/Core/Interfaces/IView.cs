using System;

namespace MVVM.Core.Interfaces
{
    public interface IView :  IDisposable
    {
        public event Action OnShow;
        public event Action OnHide;
        bool IsShown { get; }
        void ShowAndBind(IViewModel viewModel);
        void Show();
        void HideAndUnbind();
        void Hide();
    }
}