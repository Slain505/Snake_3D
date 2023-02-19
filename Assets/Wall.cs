using System.Collections;
using System.Collections.Generic;
using Snake;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;

public class Wall : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject body;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private ScoreManager scoreManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out _))
        {
            Destroy(player);
            Destroy(body);
            scoreManager.ErasePoints();
            Debug.Log("You're dead man");
        }
        
    }
}
