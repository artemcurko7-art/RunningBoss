using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using YG;

public class TimerLeaderboard : ISubscriber
{
    private const string TotalTime = "GameTime";
    private CancellationTokenSource _cancellationTokenSource;
    
    public float Timer { get; private set; }
    
    public void Subscribe()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        RunAsync(_cancellationTokenSource.Token).Forget();

        foreach (var data in YG2.saves.Leaderboards)
            if (data.Key == TotalTime)
                YG2.SetLBTimeConvert(TotalTime, (int)YG2.saves.TimerLeaderboard + 1);
    }

    public void Unsubscribe()
    {
        _cancellationTokenSource.Cancel();
        YG2.saves.TimerLeaderboard += Timer;
        
        foreach (var data in YG2.saves.Leaderboards)
            if (data.Key == TotalTime)
                YG2.SetLBTimeConvert(data.Key, YG2.saves.TimerLeaderboard);
    }
    
    public void ResetTimer()
    {
        Timer = 0;
    }
    
    private async UniTaskVoid RunAsync(CancellationToken token)
    {
        while (token.IsCancellationRequested == false)
        {
            await UniTask.WaitForSeconds(3, cancellationToken: token);
            
            if (token.IsCancellationRequested)
                return;

            Timer += 3;
            Timer = Mathf.Round(Timer * 10f) / 10f; 

            await UniTask.Yield();
        } 
    }
}