using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public Vector2 lastMovedVector;
    //Sound
    [SerializeField] AudioSource stepSource;
    public AudioClip steps;
    bool isMoving = false;

    //references
    Rigidbody2D rb;
    PlayerStats player;

    void Start()
    {
        player = GetComponent<PlayerStats>();   
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1,0f); //default 
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
        if (isMoving)
        {
            if (!stepSource.isPlaying)
                stepSource.Play();
        }
        else
        {
            stepSource.Stop();
        }
    }

    void FixedUpdate()
    {
        Move();
    }
    void InputManagement()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if(moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f); //last moved x
        }

        if(moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f,lastVerticalVector); //last moved y
        }

        if (moveDir.x != 0 &&  moveDir.y != 0)
        {
            isMoving = true;
            lastMovedVector = new Vector2(lastHorizontalVector,lastVerticalVector); //while moving
        }

        if (moveDir.x != 0 || moveDir.y != 0)
        {

            isMoving = true;
        }
        else
            isMoving = false;
    }

    void Move()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        rb.velocity = new Vector2(moveDir.x * player.CurrentMoveSpeed, moveDir.y * player.CurrentMoveSpeed);
    }
}
