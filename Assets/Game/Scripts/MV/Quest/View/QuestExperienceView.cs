using UnityEngine;

namespace Game.Scripts.MV.Quest.View
{
    public abstract class QuestExperienceView : MonoBehaviour
    {
        protected IQuest Quest { get; private set; }

        public void Initialize(IQuest quest)
        {
            Quest = quest;

            Quest.Changed += OnValueChanged;
        }

        private void OnDestroy()
        {
            Quest.Changed -= OnValueChanged;
        }

        protected abstract void OnValueChanged(int value);
    }
}