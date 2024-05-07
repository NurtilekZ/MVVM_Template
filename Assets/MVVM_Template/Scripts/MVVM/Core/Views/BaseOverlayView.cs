using MVVM.Core.Interfaces;
using UnityEngine;

namespace MVVM.Core.Views
{
    public abstract class BaseOverlayView<TViewModel> : BaseView<TViewModel> where TViewModel : IOverlayViewModel
    {
        private Camera _camere;

        private void Start() => 
            _camere = Camera.main;

        protected virtual void Update() => 
            transform.position = _camere.WorldToScreenPoint(_viewModel.AnchorTransform.position);
    }
}