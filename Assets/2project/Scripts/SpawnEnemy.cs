using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        void Update()
        {
            // Press "E" to spawn enemy
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(enemy, transform);
            }
        }
    }
}
