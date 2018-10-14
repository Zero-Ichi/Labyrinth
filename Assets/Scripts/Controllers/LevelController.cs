using Assets.Scripts.Config;
using System.Collections;
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
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            //load main menu
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
    /// <summary>
    /// start whith pref player
    /// </summary>
    public void LoadLevelContinuePlayerPrefs()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsKeys.continueLvl.ToString()))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt(PlayerPrefsKeys.continueLvl.ToString()));
        }
    }
    /// <summary>
    /// end pause
    /// </summary>
    public void QuitPause()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().StopPause();
    }

}
