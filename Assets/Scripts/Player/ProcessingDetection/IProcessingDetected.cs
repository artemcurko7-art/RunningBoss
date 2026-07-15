using System;

public interface IProcessingDetected
{
    event Action<Unit> Detected;
}