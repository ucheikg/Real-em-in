using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class fish_behaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent fish;
    [SerializeField] private Transform hook;

    public Vector3 swimPoint;
    
    private bool swimPointSet = false;
    [SerializeField] private Transform swimPointBL, swimPointTR;

    [SerializeField] private float sightRange;
    [SerializeField] private bool playerInSightRange = false;

    // Start is called before the first frame update
    void Start()
    {
        hook = GameObject.Find("hook").transform;
        fish = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, hook.position) <= sightRange)  
        { playerInSightRange = true; } else
        { playerInSightRange = false; }


        if (playerInSightRange)
        {
            bite();
        }
        if (!playerInSightRange && transform.position != swimPoint)
        {
            swimming();
        }
        
    }

    private void swimming()
    {
        if (!swimPointSet) { SearchSwimPoint(); }
        else { fish.SetDestination(swimPoint); }
        
        Vector3 distanceToSwimPoint = transform.position - swimPoint;

        if (distanceToSwimPoint.magnitude < 1f)
        {
            swimPointSet = false;
        }
    }

    private void SearchSwimPoint()
    {
        float randomZ = UnityEngine.Random.Range(swimPointBL.position.z, swimPointTR.position.z);
        float randomX = UnityEngine.Random.Range(swimPointBL.position.x, swimPointTR.position.x);
        
        swimPoint = new Vector3(randomX, transform.position.y, randomZ);

        swimPointSet = true;

        fish.SetDestination(swimPoint);
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
