using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    public int jumpCount = 0;
    private Coroutine unDoubleJump;
    private Coroutine unInvicibile;
    private int toggleNumber = 10;



    public bool isDead = false;
    public bool isWin = false;
    public bool isDouleJump = false;
    public bool isInvicible = false;

    public bool isHardMode = false;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform groudCheck;
    [SerializeField]
    private LayerMask groudLayer;
    [SerializeField]
    private GameObject haloAngel;

    // Start is called before the first frame update
    void Start()
    {
        haloAngel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(isWin)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            return;
        }

        if (IsCollidedDeadZone()) 
            isDead = true;
        

        if (!isWin && isDead)
        {
            SceneManager.LoadScene("GameOverScene");
            return ;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded()) jumpCount = 0;

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded()) rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            if (jumpCount < 2) jumpCount++;
        }


        if(Input.GetButtonDown("Jump"))
        {
            if (isDouleJump)
            {
                if (jumpCount == 1)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                }
            }
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (IsCollidedDeadZone()) isDead = true;
        if (isWin || isDead)
        {
            //ignore
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    IEnumerator ExecuteFunctionAfterDelay(float delay, Action functionToExecute)
    {
        yield return new WaitForSeconds(delay);
        functionToExecute?.Invoke();
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (isInvicible)
            {
                Destroy(col.gameObject);
            }
            else
            {
                isDead = true;
            }

        }
        if (col.gameObject.tag == "Goal")
        {
            isWin = true;
        }
        if (col.gameObject.tag == "DJFruit")
        {
            isDouleJump = true;
            Destroy(col.gameObject);
            void disableDoubleJump() => isDouleJump = false;
            if (unDoubleJump != null)
            {
                StopCoroutine(unDoubleJump);
            }
            unDoubleJump = StartCoroutine(ExecuteFunctionAfterDelay(5.0f, disableDoubleJump));
        }
        if (col.gameObject.tag == "InvicibleFruit")
        {
            isInvicible = true;
            Destroy(col.gameObject);
            haloAngel.SetActive(true);
            async void disableInvicible()
            {
                for (int i = 0; i < toggleNumber; i++)
                {
                    await Task.Delay(2000 / toggleNumber);
                    haloAngel.SetActive(!haloAngel.activeSelf);
                }

                isInvicible = false;
                haloAngel.SetActive(false);
            }
            if (unInvicibile != null)
            {
                StopCoroutine(unInvicibile);
            }
            unInvicibile = StartCoroutine(ExecuteFunctionAfterDelay(3.0f, disableInvicible));
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groudCheck.position, 0.2f, groudLayer);

    }

    private bool IsCollidedDeadZone()
    {
        var cameraPos = Camera.main.transform.position;
        var screenSizeY = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;
        return (transform.position.y + (transform.localScale.y / 2)) <= cameraPos.y - screenSizeY;
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
