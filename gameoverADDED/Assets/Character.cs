using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
public class Character : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    public int sceneToLoad;
    public GameObject blood, gameOverText, restartButton;
    // Start is called before the first frame update
    void Start()
    {
       gameOverText.SetActive(false);
        restartButton.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 5f;
        //
        sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        dirX = CrossPlatformInputManager.GetAxisRaw("Horizontal") * moveSpeed;

        if (CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 800f);
        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);
        
        if(rb.velocity.y==0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if(rb.velocity.y>0)
        {
            anim.SetBool("isJumping", true);
        }

        if(rb.velocity.y<0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void LateUpdate()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }
    
  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("door"))
        {
            
            Debug.Log("trigger");
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);

            
        }
        
        


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            Instantiate(blood, transform.position, Quaternion.identity);
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
        
    }


}
