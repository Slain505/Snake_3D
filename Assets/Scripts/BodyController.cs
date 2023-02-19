using System.Collections;
using System.Collections.Generic;
using Snake;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    
    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> moveHistory = new List<Vector3>();
    [SerializeField] private GameObject bodyPref;
    [SerializeField] private GameObject bodyParent;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private PlayerController playerController;
    

    
    public void SavePlayerHistory()
    {
        moveHistory.Insert(0, playerObject.transform.position);
            
        int index = 0;
        foreach (var body in bodyParts)
        {
            Vector3 point = moveHistory[Mathf.Min(index * playerController.gap, moveHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * playerController.bodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }
    }
    
    public void AddPlayerParts()
    {
        GameObject body = Instantiate(bodyPref, bodyParent.transform);
        bodyParts.Add(body);
    }
    
}
