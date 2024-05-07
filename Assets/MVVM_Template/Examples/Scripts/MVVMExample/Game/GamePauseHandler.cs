using System;
using MVVM.Core.Interfaces;
using MVVMExample.Game.Pawns;
using MVVMExample.Infrastructure.Bootstrap;
using MVVMExample.Infrastructure.Services.UI;
using MVVMExample.UI.Screens.GameHUD;
using MVVMExample.UI.Screens.Pause;
using UniRx;
using UnityEngine;

namespace MVVMExample.Game
{
    public class GamePauseHandler : MonoBehaviour, IDisposable
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private MovePlayerToMousePoint _playerToMousePoint;
        [SerializeField] private DamageZone _damageZone;
        [SerializeField] private DamageZone _healthZone;
        
        private readonly ReactiveProperty<bool> _isPaused = new(false);
        
        private IView _pauseView;
        private IUIService _uiService;

        private void Start()
        {
            _uiService = ServiceLocator.GetService<IUIService>();
            _uiService.Open(new GameHUDViewModel(_playerHealth.HealthModel));
            _isPaused.Subscribe(isPaused =>
            {
                _playerHealth.enabled = !isPaused;
                _playerToMousePoint.enabled = !isPaused;
                _damageZone.enabled = !isPaused;
                _healthZone.enabled = !isPaused;
            });
        }

        private async void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!_isPaused.Value)
                {
                    _pauseView = await _uiService.Open(new PauseScreenViewModel());
                }
                else
                {
                    _uiService.Close<PauseScreenViewModel>();
                }
            }
            _isPaused.Value = _pauseView?.IsShown ?? false;
        }

        public void Dispose()
        {
            _isPaused?.Dispose();
            _pauseView?.Dispose();
        }
    }
}