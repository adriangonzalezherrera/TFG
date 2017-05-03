using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaconllave : MonoBehaviour
{

    Animator animator;
    bool doorOpen;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && Gamevariables.keyCount > 0)
        {
            Doors("Open");
            Gamevariables.keyCount -= 1;
        }
    }


    void Doors(string direction)
    {
        animator.SetTrigger(direction);
    }

    // Update is called once per frame

}
