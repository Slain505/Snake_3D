using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 180;
    [SerializeField] private float speed = 5;
    [SerializeField] private int gap = 15;
    [SerializeField] private float bodySpeed = 5;
    [SerializeField] private GameObject bodyPref;
    [SerializeField] private GameObject fruit;

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
        transform.position += transform.forward * speed * Time.deltaTime;
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerSpeed * steerDirection * Time.deltaTime);
        
        MoveHistory.Insert(0,transform.position);
        
        int index = 0;
        foreach (var body in bodyParts)
        {
            Vector3 point = MoveHistory[Mathf.Min(index * gap, MoveHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * bodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }
    }

    public void SnakeAddParts()
    {
        GameObject body = Instantiate(bodyPref);
        bodyParts.Add(body);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindWithTag("apple"))
        {
            GameObject.FindWithTag("apple").SetActive(false);
            Debug.Log("UwU +1");
        }
    }
}
