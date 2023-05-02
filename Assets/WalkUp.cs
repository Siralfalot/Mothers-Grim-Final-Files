using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkUp : MonoBehaviour
{
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.gameObject.transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(move());
    }

    IEnumerator move()
    {
        rb2D.AddForce(new Vector2(0,0.5f) * 1);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
