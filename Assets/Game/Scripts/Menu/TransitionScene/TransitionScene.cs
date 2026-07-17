using Game.Scripts.Provider;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.Menu.TransitionScene
{
    public class TransitionScene : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private string LoadingScene;

        private InterstitialAdsProvider _adsProvider;
    
        [Inject]
        public void Construct(InterstitialAdsProvider adsProvider)
        {
            _adsProvider = adsProvider;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            SceneManager.LoadScene(LoadingScene);
            _adsProvider.RaiseValue();
        } 
    }
}