using System.Collections.Generic;

public interface IProgressData
{
    IReadOnlyDictionary<ProgressType, Progress> Progresses { get; }
}