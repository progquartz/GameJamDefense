using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEtc : MonoBehaviour
{
    public AudioSource buttonClick;

    public void ButtonClickSound()
    {
        buttonClick.Play();
    }
    public void LoadGameScene()
    {
        SceneLoader.SceneLoad("MapScene");
    }
}
