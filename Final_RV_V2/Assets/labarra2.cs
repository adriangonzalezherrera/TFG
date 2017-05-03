using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class labarra2 : MonoBehaviour
{

    Player targetEntity;

    // Use this for initialization
    void Start()
    {
        targetEntity = GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3((targetEntity.stamina / targetEntity.maxstamina), 1, 1);
    }
}
