using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
    }

    private bool IsOutOfScreen()
    {
        var cameraPos = Camera.main.transform.position;
        var screenSizeY = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;
        return (transform.position.y + (transform.localScale.y / 2)) <= cameraPos.y - screenSizeY;
        
    }
}
