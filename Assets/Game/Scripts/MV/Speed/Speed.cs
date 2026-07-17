using Cysharp.Threading.Tasks;
using Game.Scripts.Menu.Game;
using Game.Scripts.Menu.Game.Paused;
using Game.Scripts.Menu.Game.Paused.Type;
using Game.Scripts.Player;
using Game.Scripts.Service;
using System;
using System.Threading;

namespace Game.Scripts.MV.Speed
{
    public class Speed : ISpeed, ISubscriber
    {
        private readonly IGame _game;
        private readonly SpeedStats _stats;
        private CancellationTokenSource _cancellationTokenSource;
        private float _value;

        public Speed(IGame game, SpeedStats stats)
        {
            _game = game;
            _stats = stats;
        }

        public event Action<float> Changed;

        public float Value
        {
            get => _value;

            private set
            {
                _value = Math.Clamp(value, 0, int.MaxValue);
                Changed?.Invoke(_value);
            }
        }

        public void Subscribe()
        {
            _game.Ended += Stop;

            _cancellationTokenSource = new CancellationTokenSource();
            RunAsync(_cancellationTokenSource.Token).Forget();
        }

        public void Unsubscribe()
        {
            _game.Ended -= Stop;

            _cancellationTokenSource.Cancel();
        }

        public void Slow()
        {
            Value -= 0.5f;
        }

        private async UniTaskVoid RunAsync(CancellationToken token)
        {
            Value = _stats.DefaultValue;

            while (token.IsCancellationRequested == false)
            {
                await UniTask.WaitForSeconds(_stats.Delay, cancellationToken: token);

                if (GamePaused.Type == GamePausedType.Pause)
                    continue;

                if (token.IsCancellationRequested)
                    return;

                Value += _stats.RaiseValue;
            }
        }

        private void Stop()
        {
            Value = 0;
        }
    }
}