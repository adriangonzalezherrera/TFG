using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

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


        Projectile newProjectile = Instantiate(projectile, GameObject.FindGameObjectWithTag("MainCamera").transform.position, GameObject.FindGameObjectWithTag("cubito").transform.rotation) as Projectile;
            newProjectile.SetSpeed(muzzlevelocity);
        }
    }
}
