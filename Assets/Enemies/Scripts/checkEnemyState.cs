using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkEnemyState : MonoBehaviour
{
    public EnemyShoot enemyShootScript;
    CakeAnimController enemyAnimationController;
    EnemyHealth CakeHealthController;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimationController = GetComponent<CakeAnimController>();

        CakeHealthController = GetComponent<EnemyHealth>();
    }

    private void FixedUpdate()
    {
        enemyState();
    }

    private void enemyState()
    {
        if(enemyShootScript.isShooting == false)
        {
            enemyAnimationController.ChangeState(0);
        }
        else if(enemyShootScript.isShooting == true)
        {
            enemyAnimationController.ChangeState(1);
        }
        if(CakeHealthController.isDying == true)
        {
            enemyShootScript.isShooting = true;
            enemyAnimationController.ChangeState(2);
        }
    }
}
