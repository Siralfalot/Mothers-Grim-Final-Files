using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{

    public Transform aim1;
    public Rigidbody2D rb;
    public Camera cam;
    Vector3 mousePos;
    Vector3 PlayerPos;
    public float moveSpeed = 5;
    private Rigidbody2D target;

    // Start is called before the first frame update
    void Start()
    {
        //change to parent enemy
        target = this.gameObject.transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 lookDir1 = PlayerPos - aim1.position;

        float angle = Mathf.Atan2(lookDir1.y, lookDir1.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }
}
