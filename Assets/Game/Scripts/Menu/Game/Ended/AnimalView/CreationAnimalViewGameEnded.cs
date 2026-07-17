using Cysharp.Threading.Tasks;
using Game.Scripts.Animal.Data;
using Game.Scripts.Animation;
using Game.Scripts.Factories;
using Game.Scripts.Menu.Game.Ended.Subscriber;
using Game.Scripts.Provider;
using System.Threading;
using UnityEngine;

namespace Game.Scripts.Menu.Game.Ended.AnimalView
{
    public class CreationAnimalViewGameEnded : GameEndedSubscriber
    {
        private const string UI = "UI";
        private const float Cooldown = 1.1f;
        private const float MultiplierSize = 250;
        private readonly IGame _game;
        private readonly AnimalData _data;
        private readonly AnimalViewFactory _factory;
        private readonly IAnimalProvider _provider;
        private readonly Animal.AnimalView _animalView;
        private readonly ItemViewFactory _itemViewFactory;
        private readonly HandlerChangingLayer _handlerChangingLayer;
        private readonly Animator _animator;
        private readonly RectTransform _container;
        private CancellationTokenSource _cancellationTokenSource;

        public CreationAnimalViewGameEnded(
            IGame game,
            AnimalData data,
            IAnimalProvider provider,
            AnimalViewFactory factory,
            Animal.AnimalView animalView,
            ItemViewFactory itemViewFactory,
            HandlerChangingLayer handlerChangingLayer,
            Animator animator,
            RectTransform container)
            : base(game)
        {
            _game = game;
            _data = data;
            _factory = factory;
            _provider = provider;
            _animalView = animalView;
            _itemViewFactory = itemViewFactory;
            _handlerChangingLayer = handlerChangingLayer;
            _animator = animator;
            _container = container;
        }

        public override void Subscribe()
        {
            _game.Ended += OnGameEnded;

            _cancellationTokenSource = new CancellationTokenSource();
        }

        public override void Unsubscribe()
        {
            _game.Ended -= OnGameEnded;

            _cancellationTokenSource.Cancel();
        }

        protected override void OnGameEnded()
        {
            RunAsync(_cancellationTokenSource.Token).Forget();
        }

        private async UniTaskVoid RunAsync(CancellationToken token)
        {
            await UniTask.WaitForSeconds(Cooldown, cancellationToken: token);

            if (token.IsCancellationRequested)
                return;

            var view = _factory.Create(_provider.AnimalView, _container);
            view.transform.localScale *= MultiplierSize;
            view.Shadow.gameObject.SetActive(true);
            _animator.SetBool(PlayerAnimatorData.Params.IsRun, false);

            if (_animalView.Animal.ItemView != null)
                _itemViewFactory.Create(_animalView.Animal.ItemView, view.ItemContainer);

            var currentAnimation = _animalView.Animator.GetCurrentAnimatorClipInfo(0);

            view.Animator.Play(currentAnimation[0].clip.name);
            view.Shadow.Animator.Play(currentAnimation[0].clip.name);

            _handlerChangingLayer.Handle(view, UI);
        }
    }
}