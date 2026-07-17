using Game.Scripts.MV.Progress.Type;
using System.Collections.Generic;

namespace Game.Scripts.MV.Progress.Data
{
    public interface IProgressData
    {
        IReadOnlyDictionary<ProgressType, Progress> Progresses { get; }
    }
}