using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // References
    public PlayerCharacter playerCharacter;

    // Flip Character
    [HideInInspector] public bool mFacingRight = true;
    // Movement
    private float moveSpeed;
    private int moveStatus;
    private float lastClickTime;
    private float doubleClickTime = 0.5f;
    private float currentDoubleClickTime;
    //
    private Rigidbody2D rb2D;
    Vector2 movement;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Horizontal"))
        {
            currentDoubleClickTime = Time.time - lastClickTime;

            if (currentDoubleClickTime < doubleClickTime)
            {
                moveStatus = 2;
            }
            else
            {
                moveStatus = 1;
            }
            lastClickTime = Time.time;
        }

        Move();

    }

    void Move()
    {
        //If character animate something
        if(playerCharacter.isAttack) { return; }

        // Play Move Animation when moving
        if (movement.x != 0 || movement.y != 0)
        {
            if (moveStatus == 1)
            {
                playerCharacter.animator.SetInteger("Move", 1);
                moveSpeed = playerCharacter.walkSpeed;
            }
            else if (moveStatus == 2)
            {
                playerCharacter.animator.SetInteger("Move", 2);
                moveSpeed = playerCharacter.runSpeed;
            }
            playerCharacter.isMove = true;
        }
        else { 
            playerCharacter.animator.SetInteger("Move", 0);
            playerCharacter.isMove = false;
        }

        // Flip Character when change direciton
        if (mFacingRight && movement.x < 0 || !mFacingRight && movement.x > 0)
        {
            Flip();
        }

        rb2D.MovePosition(rb2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        mFacingRight = !mFacingRight;
        var theScale = transform.localScale;
        theScale.x *= -1;
        // ReSharper disable once Unity.InefficientPropertyAccess
        transform.localScale = theScale;
    }
}
