using System.Threading.Tasks;
using MVVM.Core.Interfaces;

namespace MVVMExample.Infrastructure.Services.UI
{
    public interface IUIService : IService
    {
        Task<IView> Open<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel;
        void Close<TViewModel>();
        void CleanUpSceneViews();
    }
}