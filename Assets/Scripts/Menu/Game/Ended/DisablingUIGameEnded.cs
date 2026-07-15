using UnityEngine;

public class DisablingUIGameEnded : GameEndedSubscriber
{
    private readonly GameObject[] _objects;
    
    public DisablingUIGameEnded(IGame game, GameObject[] objects) : base(game)
    {
        _objects = objects;
    }

    protected override void OnGameEnded()
    {
        foreach (var obj in _objects)
            obj.SetActive(false);
    }
}