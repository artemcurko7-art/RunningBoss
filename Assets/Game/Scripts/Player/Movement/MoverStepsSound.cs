using UnityEngine;
using Zenject;

public class MoverStepsSound : MonoBehaviour
{
    private SoundService _created;
    
    [Inject]
    public void Construct(SoundService created)
    {
        _created = created;
    }
    
    public void PlayFootstep()
    {
        _created.Sounds[SoundType.Steps].Play();
    }
}