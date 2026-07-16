using TMPro;
using UnityEngine;
using Zenject;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinText;

    private IWallet _model;
    
    [Inject]
    public void Construct(IWallet model)
    {
        _model = model;

        _model.CoinsChanged += OnValueChanged;
        _model.Update();
    }

    private void OnDestroy()
    {
        _model.CoinsChanged -= OnValueChanged;
    }

    private void OnValueChanged(int amount)
    {
        _coinText.text = amount.ToString();
    }
}