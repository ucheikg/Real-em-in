using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Outline : MonoBehaviour
{

    [Header("Outline")]
    [SerializeField, Range(1f, 1.3f)] private float width = 0.03f;
    [SerializeField] private Color color = Color.black;
    public bool outlineEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (outlineEnabled)
        {
            transform.GetComponent<MeshRenderer>().enabled = true;
            if (transform.parent != null)
            {
                transform.GetComponent<MeshFilter>().mesh = transform.parent.GetComponent<MeshFilter>().sharedMesh;
                transform.localScale = Vector3.one * width;
                transform.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_Color", color);
                transform.position = transform.parent.position;
            }
            else
            {
                return;
            }
        }
        else
        {
            transform.GetComponent<MeshRenderer>().enabled = false;
            return;
        }
        
        
    }

    // Public functions to change the outline variable outside this script
    public void changeColor(Color c)
    {
        color = c;
    }
    public void changeSize(float s)
    {
        width = s;
    }

}
