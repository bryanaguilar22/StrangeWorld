using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour {

    private PlayerAnimation playerAnim;
    private Rigidbody2D myBody;

    private float speed = 2f;
    private float jumpForce = 5f;

    private bool moveLeft; // determine if we move left or right
    private bool dontMove; // determine if we are moving or not
    private bool canJump; // we will test if we can jump

	void Start () {
        playerAnim = GetComponent<PlayerAnimation>();
        myBody = GetComponent<Rigidbody2D>();

        dontMove = true;
	}
	
	void Update () {
        //DetectInput();
        HandleMoving();
	}

    void HandleMoving() {

        if (dontMove) {

            StopMoving();

        } else {

            if (moveLeft) {
                
                MoveLeft();

            } else if (!moveLeft) {
                
                MoveRight();

            }

        }

    } // handle moving

    public void AllowMovement(bool movement) {
        dontMove = false;
        moveLeft = movement;
    }

    public void DontAllowMovement() {
        dontMove = true;
    }

    public void Jump() {
        if(canJump) {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
        }
    }

    // PREVIOUS FUNCTIONS

    public void MoveLeft() {
        myBody.velocity = new Vector2(-speed, myBody.velocity.y);
        playerAnim.ZombieWalk(true, true);
    }

    public void MoveRight() {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
        playerAnim.ZombieWalk(true, false);
    }

    public void StopMoving() {
        playerAnim.ZombieStop();
        myBody.velocity = new Vector2(0f, myBody.velocity.y);
    }

    void DetectInput() {
        float x = Input.GetAxisRaw("Horizontal");

        if (x > 0)
        {
            MoveRight();
        }
        else if (x < 0)
        {
            MoveLeft();
        }
        else
        {
            StopMoving();
        }
    }

	void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground") {
            canJump = true;   
        }
	}

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            canJump = false;
        }
    }

} // class






























