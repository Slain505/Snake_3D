using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Snake
{
    public class Fruit : MonoBehaviour
    {
        public PlayerController playerController;
        public ScoreManager scoreManager;
        // public TextMeshPro score; 
        private void OnTriggerEnter(Collider other)
        {
            if (GameObject.FindWithTag("apple"))
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-13, 11), 1.2f, Random.Range(-24, -1));
                transform.position = randomSpawnPosition;
                playerController.SnakeAddParts();
                scoreManager.AddPoint();
                Debug.Log("UwU +1");
            }
        }
    }
}