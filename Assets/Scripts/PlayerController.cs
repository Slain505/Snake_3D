using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

namespace Snake
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float steerSpeed = 180;
        [SerializeField] private float speed = 5;
        [SerializeField] public int gap = 15;
        [SerializeField] public float bodySpeed = 5;
        [SerializeField] private BodyController bodyController;

        private void Start()
        {
            Debug.Log("Game Start!");
            InitBody();
        }

        private void FixedUpdate()
        {
            MovePlayer();
            bodyController.SavePlayerHistory();
        }

        public void InitBody()
        {
            bodyController.AddPlayerParts();
            bodyController.AddPlayerParts();
            bodyController.AddPlayerParts();
            bodyController.AddPlayerParts();
        }

        private void MovePlayer()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            float steerDirection = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * steerSpeed * steerDirection * Time.deltaTime);
        }
    }
}