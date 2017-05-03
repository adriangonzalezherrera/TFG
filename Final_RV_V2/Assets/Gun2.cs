using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2 : MonoBehaviour
{

    public Transform muzzle;
    public Projectile projectile;
    public float ms = 100;
    public float muzzlevelocity = 35;

    float nextShotTime;

    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + ms / 1000;


            Projectile newProjectile = Instantiate(projectile, muzzle.position, Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Player").transform.position
            - transform.position)) as Projectile;
            newProjectile.SetSpeed(muzzlevelocity);
        }
    }
}
