using System;
using System.Collections;
using System.Collections.Generic;
using Snake;
using UnityEngine;

public class Poison : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private BodyController bodyController;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameObject bodyPart;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out _))
        {
            // Destroy(GetComponentInParent());
            scoreManager.LosePoint();
            Debug.Log("Ouch!");
        }
    }
}
