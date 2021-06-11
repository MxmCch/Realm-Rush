using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    public GameObject shooterParticle;
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15;
    [SerializeField] ParticleSystem projectileParticles;
    Transform target;


    void Update()
    {
        FindClosestTarger();
        AimWeapon();
    }

    void FindClosestTarger()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

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
