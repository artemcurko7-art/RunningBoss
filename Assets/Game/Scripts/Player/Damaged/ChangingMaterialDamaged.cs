using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;

public class ChangingMaterialDamaged : DamagedSubscriber
{
    private readonly AnimalView _animalView;
    private readonly Material _material;
    private readonly Material _currentMaterial;
    private CancellationTokenSource _cancellationTokenSource;

    public ChangingMaterialDamaged(IDamaged damaged, AnimalView animalView, Material material)
        : base(damaged)
    {
        _animalView = animalView;
        _material = material;
        _currentMaterial = _animalView.SkinnedMeshRenderer.material;
    }
    
    public override void Subscribe()
    {
        base.Subscribe();
        _cancellationTokenSource = new CancellationTokenSource();
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        _cancellationTokenSource.Cancel();
    }

    protected override void OnDamaged()
    {
        RunAsync(_cancellationTokenSource.Token).Forget();
    }
    
    private async UniTaskVoid RunAsync(CancellationToken token)
    {
        _animalView.SkinnedMeshRenderer.material.DOColor(Color.red, 0.2f);
        
        await UniTask.WaitForSeconds(0.3f, cancellationToken: token);

        if (token.IsCancellationRequested)
            return;

        _animalView.SkinnedMeshRenderer.material.DOColor(Color.white, 0.2f);
    }
}