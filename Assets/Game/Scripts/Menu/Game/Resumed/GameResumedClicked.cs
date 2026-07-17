using Game.Scripts.Animation;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.Menu.Game.Resumed
{
    public class GameResumedClicked : MonoBehaviour
    {
        [SerializeField] private Image[] _preStarteds;
        [SerializeField] private GameObject[] _objects;
        [SerializeField] private Image _image;

        private Game _game;
        private Animator _animator;

        [Inject]
        public void Construct(Game game, Animator animator)
        {
            _game = game;
            _animator = animator;
        }

        public void OnGameResumed()
        {
            _game.OnResumed();

            foreach (var obj in _preStarteds)
            {
                obj.color = new Color(obj.color.r, obj.color.g, obj.color.b, 0);

                for (int i = 0; i < obj.transform.childCount; i++)
                    obj.transform.GetChild(i).gameObject.SetActive(false);
            }

            _image.enabled = false;

            foreach (var obj in _objects)
                obj.SetActive(true);

            _animator.SetBool(PlayerAnimatorData.Params.IsRun, true);
        }
    }
}