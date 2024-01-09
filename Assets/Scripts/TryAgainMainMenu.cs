using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TryAgainMainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetryLevel()
    {
        LevelManager.RetryLevel();
    }

    public void MainMenu()
    {
        LevelManager.LoadMainMenu();
    }

    public void NextLevel()
    {
        LevelManager.LoadNextLevel();
    }

    public void StartHardModeGame()
    {
  
    }
}
