using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Snake
{
    public class Fruit : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (GameObject.FindWithTag("apple"))
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-13, 11), 1.2f, Random.Range(-24, -1));
                transform.position = randomSpawnPosition;
                PlayerController.pc.SnakeAddParts();
                Debug.Log("UwU +1");
            }
        }
    }
}