using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class fish_behaviour : MonoBehaviour
{
    public NavMeshAgent fish;
    
    public Transform hook;
    
    public LayerMask whatIsHook, whatIsGround;

    public Vector3 swimPoint;
    bool swimPointSet = false;
    [SerializeField] float SwimPointRange;

    public float sightRange;
    public bool playerInSightRange;

    // Start is called before the first frame update
    void Start()
    {
        hook = GameObject.Find("hook").transform;
        fish = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsHook);

        if (!playerInSightRange)
        {
            swimming();
        }
        if (playerInSightRange)
        {
            bite();
            playerInSightRange = false;
        }
    }

    private void swimming()
    {
        if (!swimPointSet) SearchSwimPoint();

        if (swimPointSet)
        {
            fish.SetDestination(swimPoint);
        }
        Vector3 distanceToSwimPoint = transform.position - swimPoint;

        if (distanceToSwimPoint.magnitude < 1f)
        {
            swimPointSet = false;
        }
    }

    private void SearchSwimPoint()
    {
        float randomZ = UnityEngine.Random.Range(-SwimPointRange, SwimPointRange);
        float randomX = UnityEngine.Random.Range(-SwimPointRange, SwimPointRange);
        
        swimPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        if (Physics.Raycast(swimPoint, Vector3.down, 2f, whatIsGround))
        {
            swimPointSet = true;
        }
    }

    private void bite()
    {
      fish.SetDestination(hook.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hook"))
        {
            Console.WriteLine(fish);
        }
    }

}
