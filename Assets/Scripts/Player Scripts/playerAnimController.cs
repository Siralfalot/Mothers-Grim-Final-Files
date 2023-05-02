using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimController : MonoBehaviour
{
    Animator myAnimatorController;

    public enum playerState {Idle,Shoot,RunForward,RunBackward };

    // Start is called before the first frame update
    void Start()
    {
        myAnimatorController = GetComponent<Animator>();
    }

    public void ChangeState(int whichState)
    {
        myAnimatorController.SetInteger("PlayerState", whichState);
    }
}
