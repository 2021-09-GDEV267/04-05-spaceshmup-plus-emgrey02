using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }

    public void OpenTitleScreen()
    {
        SceneManager.LoadScene("Welcome_Screen");
    }
}
