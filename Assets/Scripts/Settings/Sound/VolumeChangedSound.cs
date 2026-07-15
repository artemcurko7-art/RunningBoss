using Zenject;
using YG;

public class VolumeChangedSound : VolumeChanged
{
    private SoundData _data;
    private SoundService _service;
    
    [Inject]
    public void Construct(SoundData data, SoundService service)
    {
        _data = data;
        _service = service;
        
        foreach (var sound in data.Sounds.Values)
            sound.volume = YG2.saves.VolumeSoundEffects;
        
        Slider.value = YG2.saves.VolumeSoundEffects;
        OnValueChanged(YG2.saves.VolumeSoundEffects);
    }
    
    protected override void OnValueChanged(float value)
    {
        foreach(var sound in _data.Sounds.Values)
            sound.volume = value;

        foreach (var sound in _service.Sounds.Values)
            sound.volume = value;
        
        YG2.saves.VolumeSoundEffects = value;
    }
}