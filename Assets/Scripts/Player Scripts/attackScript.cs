using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    float lastAttack;
    public float destroyTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(waitBeforeDestroy());
    }

    IEnumerator waitBeforeDestroy()
    {
        yield return new WaitForSeconds(destroyTime);

        Destroy(gameObject);
    }
}
