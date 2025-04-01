using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneto(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}

