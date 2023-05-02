using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    float xMovement = 0;
    float yMovement = 0;
    public float movementSpeed = 0;

    Vector2 targetVelocity = new Vector2(0, 0);
    Vector2 velocity = Vector2.zero;
    [Range(0, .3f)] [SerializeField] private float smoothTime = .1f;
    public bool isMoving = false;
    public bool canSound = false;
    public Transform firePoint;

    public Rigidbody2D playerRigidBody;
    public BoxCollider2D bulletRigidBody;
    public shootingController myShootingController;
    public meleeController myAttackController;
    public healthController myHealthController;
    public Cutscene myCutsceneScript;

    //Animation
    playerAnimController myAnimController;
    SpriteRenderer mySpriteRenderer; //Renderer for player, used to flip the sprite.

    public float StepCoolDown;
    public float DashCoolDown;
    float lastStep;
    float lastDash;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        myAnimController = GetComponent<playerAnimController>();
    }

    void checkInputs()
    {
        xMovement = Input.GetAxis("Horizontal");
        yMovement = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Time.time - lastDash < DashCoolDown)
            {
                return;
            }
            lastDash = Time.time;
            StartCoroutine(dashMovement());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Code to react to enemy collision
            myHealthController.takeDamage(10);
        }
        if (collision.gameObject.CompareTag("Heal"))
        {
            //Code to react to a heal potion in game
            myHealthController.getHealth(20);
        }
    }

    IEnumerator dashMovement()
    {
        movementSpeed = 15f;
        yield return new WaitForSeconds(0.2f);
        movementSpeed = 7.5f;
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() 
    {
        checkInputs();
        checkPlayerState();
        if(myAttackController.canMove == false || myShootingController.canMove == false || myCutsceneScript.inCutscene == true)
        {
            cantMove();
        }

        else if(myAttackController.canMove == true && myShootingController.canMove == true)
        {
            canMove();
        }
    }

    void cantMove()
    {
        targetVelocity.Set(0 * movementSpeed, 0 * movementSpeed);
        playerRigidBody.velocity = Vector2.SmoothDamp(playerRigidBody.velocity, targetVelocity, ref velocity, smoothTime);
    }
    
    void canMove()
    {
        targetVelocity.Set(xMovement * movementSpeed, yMovement * movementSpeed);
        playerRigidBody.velocity = Vector2.SmoothDamp(playerRigidBody.velocity, targetVelocity, ref velocity, smoothTime);
        if(xMovement != 0 || yMovement != 0)
        {
            if (Time.time - lastStep < StepCoolDown)
            {
                return;
            }
            lastStep = Time.time;
            int audioRange = Random.Range(1, 4);
            if(audioRange == 1)
            {
                FindObjectOfType<audioManager>().Play("Footstep1");
            }
            else if(audioRange == 2)
            {
                FindObjectOfType<audioManager>().Play("Footstep2");
            }
            else if(audioRange == 3)
            {
                FindObjectOfType<audioManager>().Play("Footstep3");
            }
            else if(audioRange == 4)
            {
                FindObjectOfType<audioManager>().Play("Footstep4");
            }
            StartCoroutine(MovingSound());
        }
    }

    IEnumerator MovingSound()
    {
        yield return new WaitForSeconds(0.3f);
    }

    //Function to flip the character sprite depending on the direction they're facing
    void checkPlayerDirection() 
    {
        if(xMovement > 0 && myShootingController.canMove == true)
        {
            mySpriteRenderer.flipX = true;
        }
        else if(xMovement < 0 && myShootingController.canMove == true)
        {
            mySpriteRenderer.flipX = false;
        }
    }

    void checkPlayerState()
    {
        if(myShootingController.canMove == false)
        {
            //Change to shooting animation
            myAnimController.ChangeState(1);
        }
        else if(yMovement < 0 && myShootingController.canMove == true)
        {
            //Change to running forward animation
            myAnimController.ChangeState(2);
        }
        else if(yMovement > 0 && myShootingController.canMove == true)
        {
            //Change to running backwards animation
            myAnimController.ChangeState(3);
        }
        else if(xMovement != 0 && myShootingController.canMove == true)
        {
            //Change to running forward animation
            myAnimController.ChangeState(2);
            
        }
        else
        {
            //Change to idle animation
            myAnimController.ChangeState(0);
        }
        checkPlayerDirection();
    }
}
