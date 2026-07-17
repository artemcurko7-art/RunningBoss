using UnityEngine;
using YG;

namespace Game.Scripts.Inap
{
    public class AdsInap : MonoBehaviour
    {
        [SerializeField] private PurchaseYG _purchasesYG;

        public string ID { get; private set; }

        private void Start()
        {
            ID = _purchasesYG.name;
        }
    }
}