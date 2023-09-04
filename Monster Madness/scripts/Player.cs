using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] //makes private variables visible in inspector field
    private float moveForce = 10f; //default values
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    [SerializeField]
    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION = "Walk";

    private bool isGrounded;

    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    private void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }
    void FixedUpdate(){//called a fixed number of times, not every frame. Usually used when calculating things that use phyiscs
        //PlayerJump();
    }

    void PlayerMoveKeyboard(){
        movementX = Input.GetAxisRaw("Horizontal"); //get input when pressing keys, returns 0 or -1 or 1. GetAxis returns decimals vs GetAxisRaw returns whole numbers
        transform.position += new Vector3(movementX,0f,0f) * Time.deltaTime * moveForce; //only movement x to move in x direction. Time.deltaTime slows it down (time btwn each frame so small number) so smooths out movement. multiply by moveForce to make it move faster 
    }
    //animating player
    void AnimatePlayer(){
        //using AxisRaw to see where and having an animation based on what it returns
        anim.SetBool(WALK_ANIMATION,true); //setting walk to true so animation starts
        
        //if moving to the right
        if(movementX > 0){
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = false;
        } 
        //if moving to the left
        else if(movementX < 0 ){
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = true; //sprite renderer has a flip x and y property. Can set x to true to turn character
            }
        //if still
        else {anim.SetBool(WALK_ANIMATION,false);}
    }
    void PlayerJump(){
        //GetButtonDown uses default button for jump.Happens when pressed. GetButtonUp happens when release button. GetButton is held. Any key follows this 
        if (Input.GetButtonDown("Jump") && isGrounded){
            isGrounded = false;
            myBody.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);

    
        }
    }
    //test collider character has landed on
    private void OnCollisionEnter2D(Collision2D collision){ 
        if(collision.gameObject.CompareTag(GROUND_TAG)){//so if we landed on an object with a ground tag then 
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag(ENEMY_TAG)){
            Destroy(gameObject); // destroy player if collides with enemy
        }
    }
}
