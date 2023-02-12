using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsDetection : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject wall;
    private void OnTriggerEnter(Collider other)
    {
        if (wall)
        {
          Destroy(player);  
        }
    }
}
