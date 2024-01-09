using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public float speed = 0.05f;
    public float increaseAmount = 0.0000001f;
    // Start is called before the first frame update

    public bool IsMoving { get; set; } = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        speed += increaseAmount;
        if (IsMoving)
        {
            MoveUp();
        }
    }

    private void MoveUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
    }
}
