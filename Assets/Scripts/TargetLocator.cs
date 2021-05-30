using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;

    private void Start() 
    {
        //faster
        target = FindObjectOfType<EnemyMover>().transform;

        //my solution
        /*EnemyMover _pos = (EnemyMover) FindObjectOfType(typeof(EnemyMover));
        target = _pos.transform;*/
    }

    void FixedUpdate()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
