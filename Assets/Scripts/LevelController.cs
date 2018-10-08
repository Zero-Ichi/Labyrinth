﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    /// <summary>
    /// Load level with id
    /// </summary>
    /// <param name="id">Level ID</param>
    public void StartGame(int id)
    {
        SceneManager.LoadScene(id);
    }
    /// <summary>
    /// Load level with name
    /// </summary>
    /// <param name="lvlName">level name</param>
    public void StartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
    /// <summary>
    /// Close game
    /// </summary>
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    /// <summary>
    /// Reload level
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// Load next lvl
    /// </summary>
    public void StartNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
