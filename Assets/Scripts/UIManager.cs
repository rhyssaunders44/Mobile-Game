using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void ChangeScene(int selection)
    {
        SceneManager.LoadSceneAsync(selection);
    }

    public void SelectPlatform(int selection)
    {
        PlayerPrefs.SetInt("platform", selection);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
