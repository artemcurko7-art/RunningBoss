using YG;
using Zenject;

public class VolumeChangedMusic : VolumeChanged
{
    private BackgroundMusicData _data;
    private BackgroundMusicService _service;
    
    [Inject]
    public void Construct(BackgroundMusicData data, BackgroundMusicService service)
    {
        _data = data;
        _service = service;
        
        foreach (var music in data.BackgroundMusics.Values)
            music.volume = YG2.saves.VolumeMusic;
        
        Slider.value = YG2.saves.VolumeMusic;
        OnValueChanged(YG2.saves.VolumeMusic);
    }
    
    protected override void OnValueChanged(float value)
    {
        foreach (var music in _data.BackgroundMusics.Values)
            music.volume = value;

        foreach (var music in _service.BackgroundMusics.Values)
            music.volume = value;
        
        YG2.saves.VolumeMusic = value;
    }
}