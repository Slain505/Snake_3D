using System.Collections;
using System.Collections.Generic;
using Snake;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;

public class Wall : MonoBehaviour
{
    [SerializeField] public GameObject player, body;
    public ScoreManager scoreManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            Destroy(player);
            Destroy(body);
            scoreManager.ErasePoints();
            Debug.Log("You're dead man");
        }
        
    }
}
