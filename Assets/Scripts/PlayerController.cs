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
        [SerializeField] private int gap = 15;
        [SerializeField] private float bodySpeed = 5;
        [SerializeField] private GameObject bodyPref, bodyParent, walls, player;
        [SerializeField] private GameObject fruit;
        public static PlayerController pc;

        private List<GameObject> bodyParts = new List<GameObject>();
        private List<Vector3> moveHistory = new List<Vector3>();

        private void Awake()
        {
            pc = this;
        }

        private void Start()
        {
            Debug.Log("Game Start!");
            SnakeAddParts();
            SnakeAddParts();
            SnakeAddParts();
            SnakeAddParts();
        }

        private void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            float steerDirection = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * steerSpeed * steerDirection * Time.deltaTime);

            moveHistory.Insert(0, transform.position);

            int index = 0;
            foreach (var body in bodyParts)
            {
                Vector3 point = moveHistory[Mathf.Min(index * gap, moveHistory.Count - 1)];
                Vector3 moveDirection = point - body.transform.position;
                body.transform.position += moveDirection * bodySpeed * Time.deltaTime;
                body.transform.LookAt(point);
                index++;
            }
        }

        public void SnakeAddParts()
        {
            GameObject body = Instantiate(bodyPref, bodyParent.transform);
            bodyParts.Add(body);
        }
    }
}