using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cogerlubri : MonoBehaviour
{
    GunController targetEntity;
    public Gun gan;

    void Start()
    {
        targetEntity = GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<GunController>();
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            targetEntity.EquipGun(gan);
            Destroy(gameObject);      
        }
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * 60, 0));
    }



}