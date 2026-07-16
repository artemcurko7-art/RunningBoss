using UnityEngine;

public class DistanceMapPointFactory 
{
    private const int DividedIntoTwo = 2;
    private readonly IMapService _mapService;
    private readonly GameObject _finishedPoint;
    private readonly float _offsetFinished;

    public DistanceMapPointFactory(IMapService mapService, GameObject finishedPoint, float offsetFinished)
    {
        _mapService = mapService;
        _finishedPoint = finishedPoint;
        _offsetFinished = offsetFinished;
    }

    public GameObject Create()
    {
        float scale = _mapService.Maps[0].transform.localScale.z;
        float endDistance = _mapService.Maps[^1].transform.position.z;

        var position = new Vector3(0, 0, (scale / DividedIntoTwo) - (_offsetFinished / DividedIntoTwo) + endDistance);
        
        return GameObject.Instantiate(_finishedPoint, position, Quaternion.identity);
    }
}