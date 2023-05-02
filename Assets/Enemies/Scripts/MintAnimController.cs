using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MintAnimController : MonoBehaviour
{
    Animator MintAnimatorController;
    public enum MintState { Idle,Attack,Death };

    // Start is called before the first frame update
    void Start()
    {
        MintAnimatorController = GetComponent<Animator>();
    }

    public void ChangeState(int whichState)
    {
        MintAnimatorController.SetInteger("enemyState", whichState);
    }
}
