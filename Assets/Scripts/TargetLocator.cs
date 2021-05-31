using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    public GameObject shooterParticle;
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
        if (target != null)
        {
            ShootParticle(true);
            weapon.LookAt(target);
        }
        else
        {
            ShootParticle(false);
            target = FindObjectOfType<EnemyMover>().transform;
        }
    }

    private void ShootParticle(bool shootBool)
    {
        var _shoot = shooterParticle.GetComponent<ParticleSystem>().emission;
        _shoot.enabled = shootBool;
    
    }
}
