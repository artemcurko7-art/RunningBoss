using System.Collections.Generic;

public interface IMapService 
{
    IReadOnlyList<Map> Maps { get; }
}