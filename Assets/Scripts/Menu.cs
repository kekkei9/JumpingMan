using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayTheGame()
    {
        LevelManager.LoadNewGame();
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
