using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class CatAIEnnemy : MonoBehaviour
{
    public NavMeshAgent cat;

    public Transform barbie;

    public LayerMask whatIsGround, whatIsBarbie;

    public float health;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool barbieInSightRange, barbieInAttackRange;

    private void Awake()
    {
        barbie = GameObject.Find("Player").transform;
        cat = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        barbieInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsBarbie);
        barbieInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsBarbie);

        if (!barbieInSightRange && !barbieInAttackRange) Patroling();
        if (barbieInSightRange && !barbieInAttackRange) ChaseBarbie();
        if (barbieInAttackRange && barbieInSightRange) AttackBarbie();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) 
            cat.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChaseBarbie()
    {
        cat.SetDestination(barbie.position);
    }

    private void AttackBarbie()
    {
        cat.SetDestination(transform.position);

        transform.LookAt(barbie);

        if (!alreadyAttacked)
        {

            //attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            //

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
