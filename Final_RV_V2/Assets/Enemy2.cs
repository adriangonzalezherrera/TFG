using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]


public class Enemy2 : LivingEntity
{

    public enum State { Idle, Chasing, Attacking };
    State currentState;
    LivingEntity targetEntity;
    GunController2 gunController;

    private Vector3 targetPosition;
    UnityEngine.AI.NavMeshAgent agent;

    float attackDistance = 16;
    float timeBetweenAttacks = 1;
    float damage = 1;

    float nextAttackTime;
    float f_RotSpeed = 3.0f;
    // Use this for initialization

    protected override void Start()
    {
        base.Start();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        targetEntity = GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<LivingEntity>();
        gunController = GetComponent<GunController2>();

        currentState = State.Chasing;

        StartCoroutine(UpdatePath());

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextAttackTime)
        {
            float sqrDstToTarget = (targetPosition - transform.position).sqrMagnitude;
            if (sqrDstToTarget < Mathf.Pow(attackDistance, 2))
            {
                nextAttackTime = Time.time + timeBetweenAttacks;
                gunController.Shoot();


            }
        }



    }

    /*IEnumerator Attack()
    {
        currentState = State.Attacking;
        agent.enabled = false;
    }*/



    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;

        while (targetPosition != null)
        {
            if (currentState == State.Chasing)
            {
                targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
                if (!dead)
                    agent.SetDestination(targetPosition);
            }
            yield return new WaitForSeconds(refreshRate);
        }
    }
}