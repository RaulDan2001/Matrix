using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask groundIndicator, playerIndicator;

    public PlayerStats healthbar;

    //Date de patrolare
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;

    //Date de atac
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile; 

    //Date de sunet
    public AudioSource audioSource;
    public AudioClip ShootClip;
    

    //Stari
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public int Damage;

    private void Awake()
    {
        player = GameObject.Find("PlayerWithGunAmmoScoreHealthalth").transform;
        agent = GetComponent<NavMeshAgent>();
        audioSource.clip = ShootClip;
    }


    private void Update()
    {
        //Vedem daca playerul se afla in zona de vedere sau atac
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerIndicator);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerIndicator);

        if (!playerInSightRange && !playerInAttackRange) Pattroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Pattroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        //Folosim NavMeshAgent sa ne deplasam la punctul ales
        if (walkPointSet)
            agent.SetDestination(walkpoint);

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        //Am ajuns la punctul dorit
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculam zona de patrulare
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //Vedem daca nu il punem sa umble afara din harta
        if (Physics.Raycast(walkpoint, -transform.up, 2f, groundIndicator))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        //Punem inamicul sa merga la jucator
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Ne asiguram ca inamicul nu se mai misca
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        
        if (!alreadyAttacked)
        {
            audioSource.Play();
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            TakeDamage(Damage);

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
        healthbar.CurrentHealth -= damage;

        healthbar.SetHealth(healthbar.CurrentHealth);
    }
}
