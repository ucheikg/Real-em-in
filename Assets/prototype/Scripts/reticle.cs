using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reticle : MonoBehaviour
{
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
