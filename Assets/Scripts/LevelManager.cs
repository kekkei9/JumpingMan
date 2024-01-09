using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int currentLevel = 1;
    public static bool isHardMode = false;
 

    public static readonly Dictionary<int, string> levelList = new Dictionary<int, string>() {
        {1, "GameScene"},
        {2, "GameScene2"},
    };

    #region Properties
    public static bool isLastGame
    {
        get
        {
            return currentLevel >= levelList.Count;
        }
    }
    #endregion

    #region Static Methods
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public static void LoadNewGame()
    {
        currentLevel = 1;
        SceneManager.LoadScene("GameScene");
    }

    public static void RetryLevel()
    {
        string scene = levelList.GetValueOrDefault(currentLevel);
        SceneManager.LoadScene(scene);
    }

    public static void LoadNextLevel()
    {
        if(isLastGame)
        {
            return;
        }
        string scene =  levelList.GetValueOrDefault(++currentLevel);
        SceneManager.LoadScene(scene);
    }

    public static void LoadWinScene()
    {
        string scene = isLastGame ? "Congratulation" : "LevelCompleteScene";
        SceneManager.LoadScene(scene);
    }

    public static void LoadLoseScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    #endregion
}
