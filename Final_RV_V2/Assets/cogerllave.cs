using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cogerllave : MonoBehaviour {
    LivingEntity targetEntity;

    void Start()
    {
        targetEntity = GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<LivingEntity>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (targetEntity.health < 5)
            {
                targetEntity.health += 1;
                Destroy(gameObject);
            }
        }
    }
    
    void Update ()
    {
        transform.Rotate(new Vector3(Time.deltaTime * 60, 0, 0));
    }

	

}
