using UnityEngine;
using UnityEngine.UI;

public class GameClosingTab : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TabView _view;

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
        _view.gameObject.SetActive(false);
    }
}