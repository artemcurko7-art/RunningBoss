using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuBackgroundMusic : MonoBehaviour
{
    [Inject]
    public void Construct(BackgroundMusicService service)
    {
        service.BackgroundMusics[BackgroundMusicType.Menu].Play();
    }
}
