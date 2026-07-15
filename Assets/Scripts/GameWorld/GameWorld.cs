public class GameWorld 
{
    private GameWorld(GameWorldData data)
    {
        Config = data.GetConfig();
    }
    
    public GameWorldConfig Config { get; }
}