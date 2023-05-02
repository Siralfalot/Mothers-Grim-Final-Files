using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public Transform Enemy;

    public Transform Aim;

    private Rigidbody2D rb2D;

    Vector2 dir;

    public float cooldown = 1;

    public int WaitTimer;

    public float Speed;

    public int health;

    MintAnimController MintAnimationController;
    EnemyHealth MintHealthController;
    SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        MintAnimationController = GetComponent<MintAnimController>();
        MintHealthController = GetComponent<EnemyHealth>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        
        rb2D = this.gameObject.transform.GetComponent<Rigidbody2D>();

        Enemy.transform.Rotate(0f, 0f, 0f, Space.World);

        StartCoroutine(WaitTime());

        

    }

    // Update is called once per frame
    void Update()
    {

        Enemy.transform.Rotate(0f, 0f, 0f, Space.World);

        Vector2 pos = Enemy.transform.position;

        dir = Aim.position - Enemy.transform.position;
        checkEnemyDirection();

        if (cooldown == 0)
        {
            cooldown = 1;

            rb2D.AddForce(dir * Speed);

            MintAnimationController.ChangeState(1);

            StartCoroutine(WaitTime());
        }

    }

    public void checkEnemyDirection() 
    {
        if(dir.x > 0)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
    }

    IEnumerator WaitTime()
    {
        
        yield return new WaitForSeconds(WaitTimer);
        MintAnimationController.ChangeState(0);
        cooldown = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            int audioRange = Random.Range(1, 2);
            if (audioRange == 1)
            {
                FindObjectOfType<audioManager>().Play("CakeMonsterAttack1");
            }
            else if (audioRange == 2)
            {
                FindObjectOfType<audioManager>().Play("CakeMonsterAttack2");
            }
        }
    }

}
