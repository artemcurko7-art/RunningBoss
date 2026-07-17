using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Scripts.MV.SkillPoint
{
    public class SkillPointText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _skillPointText;

        private ISkillPoint _model;

        [Inject]
        public void Construct(ISkillPoint model)
        {
            _model = model;

            _model.Changed += OnValueChanged;
            _model.Update();
        }

        private void OnDestroy()
        {
            _model.Changed -= OnValueChanged;
        }

        private void OnValueChanged(int value)
        {
            _skillPointText.text = value.ToString();
        }
    }
}