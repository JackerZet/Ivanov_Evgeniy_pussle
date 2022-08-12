using UnityEngine;

namespace Puzzle.Enemy
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        [SerializeField] private Transform spawnEnemyPoint;
        [SerializeField] private int probabilityToSpawnInFrame = 150;
        void Update()
        {           
            RandomlySpawn();
        }
        private void ControlledSpawn()
        {            
            if (Input.GetKeyDown(KeyCode.E))  // Press "E" to spawn enemy
            {
                Instantiate(enemy, spawnEnemyPoint.position, Quaternion.identity);
            }
        }
        private void RandomlySpawn()
        {
            if (Random.Range(0, probabilityToSpawnInFrame) == 0)
            {
                Instantiate(enemy, spawnEnemyPoint.position, Quaternion.identity);
            }
        }
    }
}
