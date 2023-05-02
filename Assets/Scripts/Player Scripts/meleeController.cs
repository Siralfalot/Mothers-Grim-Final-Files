using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeController : MonoBehaviour
{

    public Transform meleePoint;
    public GameObject meleePrefab;
    public float coolDown;
    float lastAttack;

    public bool canMove = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Attack();

            if(Time.time - lastAttack<coolDown)
            {
                return;
            }


        }
    }

    void Attack()
    {
        if(Time.time - lastAttack<coolDown)
        {
            return;
        }
        
        StartCoroutine(attackPause());
        
        lastAttack = Time.time;

        GameObject attack = Instantiate(meleePrefab, meleePoint.position, meleePoint.rotation);

        Rigidbody2D attackRb = attack.GetComponent<Rigidbody2D>();
    }

    IEnumerator attackPause()
    {
        canMove = false;
        yield return new WaitForSeconds(coolDown);
        canMove = true;
    }
}
