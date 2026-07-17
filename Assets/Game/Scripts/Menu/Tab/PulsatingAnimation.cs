using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.Menu.Tab
{
    public class PulsatingAnimation : MonoBehaviour
    {
        [SerializeField] private float _multiplier;

        private void Start()
        {
            transform.DOScale(transform.localScale * _multiplier, 0.4f).SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}