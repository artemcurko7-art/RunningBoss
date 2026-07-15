using UnityEngine;
using YG;

public class GameWorldData 
{
    public GameWorldData()
    {
        Configs = Resources.LoadAll<GameWorldConfig>("Config/GameWorld");
    }
    
    public GameWorldConfig[] Configs { get; }
    
    public GameWorldConfig GetConfig()
    {
        return Configs[YG2.saves.IndexGameWorldConfig];
    }
}