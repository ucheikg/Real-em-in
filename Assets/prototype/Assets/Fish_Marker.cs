using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Marker : MonoBehaviour
{
    [SerializeField] private float Top = 392;
    [SerializeField] private float Bottom = 122;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float randPos = 0;

    private void Start()
    {
        StartCoroutine(moveMarker(Random.Range(1, 5)));
    }

    void Update()
    {
        
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, randPos, speed * Time.deltaTime), transform.position.z);
    }

    IEnumerator moveMarker(float t)
    {
        randPos = Random.Range(Bottom, Top);
        yield return new WaitForSeconds(t);
        StartCoroutine(moveMarker(Random.Range(1, 5)));
    }
}
