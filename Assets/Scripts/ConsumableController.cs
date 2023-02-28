using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snake;
using Random = UnityEngine.Random;

namespace Snake.Consumable
{
    public class ConsumableController : MonoBehaviour
    {
        [SerializeField] private GameObject[] fruitPrefabs;
        [SerializeField] private float spawnTimer = 0f;
        [SerializeField] private float spawnInterval = 0f;

        private List<GameObject> fruits = new List<GameObject>();

        private void Start()
        {
            FruitSpawn();
        }

        private void Update()
        {
            FruitSpawnTimer();
        }

        private void FruitSpawnTimer()
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                FruitSpawn();
                spawnTimer = 0f;
            }
        }

        private void FruitSpawn()
        {
            int fruitIndex = Random.Range(0, fruitPrefabs.Length);
            GameObject fruitPrefab = fruitPrefabs[fruitIndex];

            Vector3 position = GetRandomSpawnPosition();
            GameObject fruit = Instantiate(fruitPrefab, position, Quaternion.identity);

            fruits.Add(fruit);
            fruit.AddComponent<Fruit>();
        }

        private Vector3 GetRandomSpawnPosition()
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-13, 11), 1.2f, Random.Range(-24, -1));
            return randomSpawnPosition;
        }

        public void FruitDestroy(GameObject fruit)
        {
            fruits.Remove(fruit);
            Destroy(fruit);
        }
    }
}