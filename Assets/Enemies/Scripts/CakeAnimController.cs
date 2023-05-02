using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeAnimController : MonoBehaviour
{
    Animator CakeAnimatorController;
    public enum CakeState {Idle,Attack,Death };

    // Start is called before the first frame update
    void Start()
    {
        CakeAnimatorController = GetComponent<Animator>();
    }

    public void ChangeState(int whichState)
    {
        CakeAnimatorController.SetInteger("cakeState", whichState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
