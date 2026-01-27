using UnityEngine;
using TMPro;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinText;

    public void OnCoinsChangedText(int coin)
    {
        _coinText.text = coin.ToString();
    }
}
