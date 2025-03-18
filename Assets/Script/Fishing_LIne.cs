using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing_LIne : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public GameObject pole;
    public GameObject bait;

    // Start is called before the first frame update
    void Start()
    {

        lineRenderer.positionCount = 2;



    }

    // Update is called once per frame
    void Update()
    {
        
        lineRenderer.SetPosition(1, pole.transform.position);
        lineRenderer.SetPosition(0, bait.transform.position);

    }
}
