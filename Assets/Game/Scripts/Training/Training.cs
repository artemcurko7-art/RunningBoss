using UnityEngine;
using UnityEngine.UI;
using YG;

public class Training : MonoBehaviour
{
    [SerializeField] private GameObject[] _mobileDisablings;
    [SerializeField] private GameObject[] _desktopDisablings;
    [SerializeField] private Image _mobileHand;
    [SerializeField] private Image _desktopHand;
    
    private void OnEnable()
    {
        YG2.onDefaultSaves += OnDefaultSaves;

        if (YG2.saves.IsSavesTraining == false)
            OnDefaultSaves();
    }

    private void OnDisable()
    {
        YG2.onDefaultSaves -= OnDefaultSaves;
    }

    private void OnDefaultSaves()
    {
        Learn(_mobileHand, _mobileDisablings);
        Learn(_desktopHand, _desktopDisablings);
    }

    private void Learn(Image hand, GameObject[] disablings)
    {
        hand.enabled = true;

        foreach (var obj in disablings)
            obj.gameObject.SetActive(false);
    }
}