using System;
using System.Threading.Tasks;
using MVVM.Core.Interfaces;

namespace MVVMExample.Infrastructure.Factories
{
    public interface IUIFactory : IDisposable
    {
        Task CreateRootCanvas();
        Task CreateSceneRootCanvas();
        Task<IView> GetOrCreateView<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel;
        void CleanUp();
    }
}