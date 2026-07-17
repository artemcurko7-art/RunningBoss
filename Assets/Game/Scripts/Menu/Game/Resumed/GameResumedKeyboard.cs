using Game.Scripts.Animation;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Menu.Game.Resumed
{
    public class GameResumedKeyboard : MonoBehaviour
    {
        [SerializeField] private GameObject _preStarted;
        [SerializeField] private GameObject[] _objects;

        private Game _game;
        private Animator _animator;

        [Inject]
        public void Construct(Game game, Animator animator)
        {
            _game = game;
            _animator = animator;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
                Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                _game.OnResumed();
                Destroy(_preStarted);
                Destroy(this);

                foreach (var obj in _objects)
                    obj.SetActive(true);

                _animator.SetBool(PlayerAnimatorData.Params.IsRun, true);
            }
        }
    }
}