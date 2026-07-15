using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class PurchasedAds : MonoBehaviour
{
    [SerializeField] private AdsInap _inap;
    [SerializeField] private Button _button;

    [Inject]
    public void Construct()
    {
        _button.onClick.AddListener(() => YG2.BuyPayments(_inap.ID));
        YG2.ConsumePurchaseByID(_inap.ID, true);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(() => YG2.BuyPayments(_inap.ID));
    }
}