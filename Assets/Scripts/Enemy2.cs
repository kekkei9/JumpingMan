using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    
    bool isUp = true;
    

    Vector2 origin;

    [SerializeField]
    float speed = 10;

    [SerializeField]
    float maxMoveDistance = 5;

    [SerializeField]
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        origin = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //direction asserting
        if (Mathf.Approximately(rb.transform.position.y, (origin.y + maxMoveDistance)))
        {
            isUp = false;
        }
        if(rb.transform.position.y == origin.y)
        {
            isUp = true;
        }

        Vector2 destination = new Vector2(rb.position.x, (!isUp) ? origin.y : origin.y + maxMoveDistance);
        rb.transform.position = Vector2.MoveTowards(rb.transform.position, destination, speed * Time.deltaTime);
    }
}
