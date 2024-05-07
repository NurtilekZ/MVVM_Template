using System;
using System.Collections.Generic;
using DG.Tweening;
using MVVM.Core.Interfaces;
using UnityEngine;

namespace MVVM.Core.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class BaseView<TViewModel> : MonoBehaviour, IView where TViewModel : IViewModel
    {
        [SerializeField] protected float _fadeTime = 0.5f;
        [SerializeField] protected CanvasGroup _canvasGroup;

        protected readonly List<IDisposable> _disposables = new();
        protected TViewModel _viewModel;
        
        public event Action OnShow;
        public event Action OnHide;
        
        protected abstract void Bind();
        protected abstract void Unbind();

        public bool IsShown { get; private set; }

        public virtual void ShowAndBind(IViewModel viewModel)
        {
            if (viewModel is not TViewModel targetViewModel) return;
            _viewModel = targetViewModel;
            Bind();
            Show();
        }

        public void Show()
        {
            _canvasGroup.alpha = 0;
            SetActive();
            _canvasGroup.DOKill();
            _canvasGroup.DOFade(1, _fadeTime);
            IsShown = true;
            OnShow?.Invoke();
        }

        public virtual void HideAndUnbind()
        {
            Hide();
            Unbind();
            Dispose();
            _viewModel.Dispose();
            OnHide?.Invoke();
        }

        public void Hide()
        {
            IsShown = false;
            _canvasGroup.DOKill();
            _canvasGroup.DOFade(0, _fadeTime).OnComplete(SetInactive);
        }

        private void SetActive() => 
            gameObject.SetActive(true);

        private void SetInactive() => 
            gameObject.SetActive(false);


        public virtual void Dispose()
        {
            foreach (var disposable in _disposables)
                disposable?.Dispose();
        }
    }
}