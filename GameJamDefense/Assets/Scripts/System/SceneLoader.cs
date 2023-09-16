using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public static void SceneLoad(string SceneName)
    {
        SceneManager.LoadScene(SceneName);

    }

    public static void QuitGame()
    {
        Application.Quit();
    }


}
