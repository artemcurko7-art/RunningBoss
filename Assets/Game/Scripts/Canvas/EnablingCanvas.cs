using UnityEngine;
using YG;

namespace Game.Scripts.Canvas
{
    public class EnablingCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _mobile;
        [SerializeField] private GameObject _desktop;

        private void Start()
        {
            if (YG2.envir.isMobile)
                _mobile.gameObject.SetActive(true);
            else
                _desktop.gameObject.SetActive(true);
        }
    }
}