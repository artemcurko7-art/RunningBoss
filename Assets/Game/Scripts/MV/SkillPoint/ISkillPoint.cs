using System;

namespace Game.Scripts.MV.SkillPoint
{
    public interface ISkillPoint
    {
        event Action<int> Changed;
        void Update();
    }
}