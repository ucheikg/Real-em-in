using GamesAcademy.SerialPackage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paning : MonoBehaviour
{
    [SerializeField] private Transform fishingRod;
    [SerializeField] private float rotationSpeed = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SerialComManager.instance.GetDataFromArduino("d") == "1")
        {
            fishingRod.Rotate(0, rotationSpeed *  Time.deltaTime, 0);
        }
        if (SerialComManager.instance.GetDataFromArduino("e") == "1")
        {
            fishingRod.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
    }
}
