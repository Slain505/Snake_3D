using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CameraController : MonoBehaviour
{
    private float smoothSpeed = 0.05f;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform snakeHead;

    void Start()
    {
    }
    
    void LateUpdate()
    {
        Vector3 desiredPosition = snakeHead.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.rotation = new Quaternion(0.240609154f, 0, 0, snakeHead.rotation.w);
    }
}
