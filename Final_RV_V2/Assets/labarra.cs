using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class labarra : MonoBehaviour {

    LivingEntity targetEntity;

    // Use this for initialization
    void Start () {
        targetEntity = GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<LivingEntity>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3((targetEntity.health / targetEntity.startingHealth), 1, 1);
	}
}
