using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    public GameObject shooterParticle;
    [SerializeField] Transform weapon;
    [SerializeField] float range = 2;
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
        Debug.Log(targetDistance);
        if (range >= targetDistance)
        {
            Debug.Log("fdsa");
            weapon.LookAt(target);
            ShootParticle(true);
        }
        else
        {
            Debug.Log("fffffff");
            ShootParticle(false);
        }

    }

    private void ShootParticle(bool shootBool)
    {
        var _shoot = shooterParticle.GetComponent<ParticleSystem>().emission;
        _shoot.enabled = shootBool;
    }
}
