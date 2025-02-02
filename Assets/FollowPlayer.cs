using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    NavMeshAgent nav;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.position);
    }
}
