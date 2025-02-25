using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Marker : MonoBehaviour
{
    [SerializeField] private Transform Top;
    [SerializeField] private Transform Bottom;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float randPos = 0;

    public bool canMove = false;

    private void Start()
    {
        
    }

    void Update()
    {
        
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, randPos, speed * Time.deltaTime), transform.position.z);
    }

    public void startMarker()
    {
        StartCoroutine(moveMarker(Random.Range(1, 5)));
    }


    IEnumerator moveMarker(float t)
    {
        if(canMove) 
        {
            randPos = Random.Range(Bottom.position.y + 10, Top.position.y - 10);
            Debug.Log(t);
            yield return new WaitForSeconds(1);
            StartCoroutine(moveMarker(Random.Range(1, 5)));
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
