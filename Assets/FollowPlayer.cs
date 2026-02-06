using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        nav.SetDestination(target.position);
    }
}
