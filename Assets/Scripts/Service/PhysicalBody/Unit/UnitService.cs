using UnityEngine;

public class UnitService : PhysicalBodyService<Unit>
{
    private readonly ILocationLevel _locationLevel;
    private float _delay;
    
    public UnitService(UnitPool pool, Unit[] units, ILocationLevel locationLevel, ISpeed speed, IDistanceMap distanceMap, Transform player, float delay) 
        : base(pool, locationLevel, speed, distanceMap, player, delay)
    {
        _locationLevel = locationLevel;
        _delay = delay;
        
        pool.SetPrefabs(units);
        SetPositionY(0.376f);
        SetDelay(GetCalculationDelay());
    }
    
    private float GetCalculationDelay()
    {
        for (int i = 0; i < _locationLevel.Value; i++)
            _delay -= 0.2f;
        
        if (_delay <= 0.5f)
            _delay = 0.5f;
        
        return _delay;
    }
}