using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletPresenter : MonoBehaviour
{
    [SerializeField] private WalletView _view;

    private Wallet _model;

    private void Awake()
    {
        _model = new Wallet();      
    }

    private void Enable()
    {
        _model.CoinsChanged += _view.OnCoinsChangedText;
    }

    private void Disable() 
    {
        _model.CoinsChanged -= _view.OnCoinsChangedText;
    }   
}
