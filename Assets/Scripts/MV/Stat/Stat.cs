using System;

public abstract class Stat 
{
    private int _value;
    
    public event Action<int> Changed;
    public event Action<int> Upped;

    public Stat(AnimalType animalType, ImprovementConfig improvementConfig, int value)
    {
        AnimalType = animalType;
        ImprovementConfig = improvementConfig;
        Value = value;
    }

    public ImprovementConfig ImprovementConfig { get; }
    protected AnimalType AnimalType { get; }
    public int Level { get; private set; }
    
    public int Value
    {
        get => _value;

        private set
        {
            _value = Math.Clamp(value, 0, int.MaxValue);
            Changed?.Invoke(value);
        }
    }

    public void Update()
    {
        Changed?.Invoke(Value);
        
        if (ImprovementConfig != null && ImprovementConfig.Values.Length > Level)
            Upped?.Invoke(ImprovementConfig.Values[Level]);
    }
    
    public virtual void Up()
    {
        if (Level == ImprovementConfig.Values.Length)
            return;
        
        Value += ImprovementConfig.Values[Level];
        Level++;

        if (ImprovementConfig.Values.Length > Level)
            Upped?.Invoke(ImprovementConfig.Values[Level]);
    }

    public void SetValue(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));
        
        Value = value;
    }
    
    public void SetLevel(int level)
    {
        if (level < 0)
            throw new ArgumentOutOfRangeException(nameof(level));
        
        Level = level;
    }
    
    protected void Reduce(int amount)
    {
        Value -= amount;
    }
}