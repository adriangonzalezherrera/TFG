using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class labarra3 : MonoBehaviour
{

    Player targetEntity;
    public Text overa;

    // Use this for initialization
    void Start()
    {
        targetEntity = GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEntity.overo == true)
        {
            overa.color = Color.red;
        }
        else
        {
            overa.color = Color.black;
        }

    }
}