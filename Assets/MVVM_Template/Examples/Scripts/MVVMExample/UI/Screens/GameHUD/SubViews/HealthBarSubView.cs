using DG.Tweening;
using MVVM.Core.Views;
using MVVMExample.Game.DamageSystem;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVVMExample.UI.Screens.GameHUD.SubViews
{
    public class HealthBarSubView : SubView<IHealthModel>
    {
        [SerializeField] private Image _valueSlider;
        [SerializeField] private TMP_Text _valueText;
        private IHealthModel _data;

        protected override void Bind(IHealthModel data)
        {
            _data = data;
            data.CurrentHealth.Subscribe(SetValue).AddTo(_disposables);
            SetValue(data.CurrentHealth.Value);
        }

        private void SetValue(float value)
        {
            if (_valueText) 
                _valueText.text = value.ToString();
            if (_valueSlider) 
                _valueSlider.DOFillAmount(value / _data.MaxHealth, 0.25f);
        }


        protected override void Unbind()
        {
            
        }
    }
}