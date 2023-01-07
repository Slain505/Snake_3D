using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 180;
    [SerializeField] private float speed = 5;
    [SerializeField] private GameObject bodyPref;
    [SerializeField] public int Gap = 10;
    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> MoveHistory = new List<Vector3>();

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
        transform.position += transform.forward * (speed * Time.deltaTime);
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * (steerSpeed * steerDirection * Time.deltaTime));
        
        MoveHistory.Insert(0,transform.position);
        
        int index = 0;
        foreach (var body in bodyParts)
        {
            Vector3 point = MoveHistory[Mathf.Min(index * Gap, MoveHistory.Count - 1)];
            body.transform.position = point;
            index++;
        }
    }

    private void SnakeAddParts()
    {
        GameObject body = Instantiate(bodyPref);
        bodyParts.Add(body);
    }
}
