using UnityEngine;
using Zenject;
using YG;

public class SubscriberService : MonoBehaviour
{
    private ISubscriber[] _subscribers;
    
    [Inject]
    public void Construct(ISubscriber[] subscribers)
    {
        _subscribers = subscribers;
        
        Initialize();
    }

    private void Initialize()
    {
        foreach (var subscriber in _subscribers) 
            subscriber.Subscribe();
        
        YG2.onHideWindowGame += OnHideWindowGame;
    }

    private void OnDestroy()
    {
        foreach (var subscriber in _subscribers) 
            subscriber.Unsubscribe();
        
        YG2.onHideWindowGame -= OnHideWindowGame;
        OnHideWindowGame();
    }

    private void OnHideWindowGame()
    {
        YG2.SaveProgress();
    }
}