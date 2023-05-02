using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimingController : MonoBehaviour
{

    public Transform aim1;
    public Transform aim2;
    public Transform aim3;
    public Rigidbody2D rb;
    public Camera cam;
    Vector3 mousePos;
    public float moveSpeed = 10;
    private Rigidbody2D target;

    

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<Camera>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position,moveSpeed * Time.deltaTime);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir1 = mousePos - aim1.position;

        float angle = Mathf.Atan2(lookDir1.y, lookDir1.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }
}
