using System.Collections;
using System.Collections.Generic;
using Snake;
using UnityEngine;
using static UnityEngine.Quaternion;

class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationDamping = 2f;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform snakeHead;
    [SerializeField] private PlayerController playerController;

    void Start()
    {
        IsSnakeAssigned();
    }
    
    void LateUpdate()
    {
        CameraDesiredPosition();
    }

    private void CameraDesiredPosition()
    {
        if (snakeHead == null) return;

        if (!playerController.isMoving)
        {
            StartCoroutine(MoveCamera());
        }
        
        Quaternion targetRotation = Quaternion.LookRotation(snakeHead.position + offset - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationDamping * Time.deltaTime);
    }
    
    private IEnumerator MoveCamera()
    {
        playerController.isMoving = true;

        Vector3 targetPosition = snakeHead.position + offset;
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        playerController.isMoving = false;
    }
    
    private void IsSnakeAssigned()
    {
        if (snakeHead == null)
        {
            Debug.LogError("Player is not assigned to the Camera");
        }
    }
}
