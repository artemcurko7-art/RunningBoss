using UnityEngine;
using UnityEngine.UI;
using Zenject;
using YG;

public class HandlerPurchaseSuccessAds : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    [Inject]
    private void Construct()
    {
        YG2.onPurchaseSuccess += OnPurchaseSuccess;

        if (YG2.saves.IsPaymentAds)
            DisableButtons();
    }

    private void OnDestroy()
    {
        YG2.onPurchaseSuccess -= OnPurchaseSuccess;
    }

    private void OnPurchaseSuccess(string id)
    {
        YG2.saves.IsPaymentAds = true;

        DisableButtons();
    }

    private void DisableButtons()
    {
        foreach (var button in _buttons)
            if (button != null)
                button.interactable = false;
    }
}