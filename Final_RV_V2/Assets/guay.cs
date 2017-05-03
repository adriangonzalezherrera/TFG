using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guay : MonoBehaviour {

    Animator animator;
    bool doorOpen;

	// Use this for initialization
	void Start () {
        doorOpen = false;
        animator = GetComponent<Animator>();
	}

    void OnTriggerEnter(Collider col)
    {
        if(!doorOpen && col.gameObject.name == "Enemy(Clone)")
        {
            doorOpen = true;
            Doors("Open");
        }
    }


    void OnTriggerExit(Collider col)
    {
        if (doorOpen && col.gameObject.name == "Enemy(Clone)")
        {
            doorOpen = false;
            Doors("Close");
        }
        
    }

    void Doors(string direction)
    {
        animator.SetTrigger(direction);
    }

    // Update is called once per frame
    
}
