using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Move2d : MonoBehaviour
{
	public float movespeed;
	public bool isgrounded = false;
	public float dirX;
	private Rigidbody2D rr;
	private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
		rr = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		movespeed = 5f;

    }

    // Update is called once per frame
    void Update()
    {
		Jump();
		 dirX = CrossPlatformInputManager.GetAxis("Horizontal")*movespeed;
		
    }
	void Jump()
	{
		if (CrossPlatformInputManager.GetButtonDown("Jump") && isgrounded==true)
		{
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
		}
	}

	private void FixedUpdate()
	{
		rr.velocity = new Vector2(dirX, rr.velocity.y);
	}
}
