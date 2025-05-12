using GamesAcademy.SerialPackage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paning : MonoBehaviour
{
    [SerializeField] private RectTransform arrow;
    [SerializeField] private float rotationSpeed = 10f;

    void Start()
    {
        StopCoroutine(Right());
        StopCoroutine(Left());
    }

    // Update is called once per frame
    void Update()
    {
        if (SerialComManager.instance.GetDataFromArduino("d") == "1")
        {
            StartCoroutine(Right());
        }
        if (SerialComManager.instance.GetDataFromArduino("e") == "1")
        {
            StartCoroutine(Left());
        }

    }

    IEnumerator Left()
    {
        
        arrow.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        
        if (SerialComManager.instance.GetDataFromArduino("e") == "0")
        {
            yield break;
        }
    }

    IEnumerator Right()
    {

        arrow.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        if (SerialComManager.instance.GetDataFromArduino("d") == "0")
        {
            yield break;
        }
    }
}
