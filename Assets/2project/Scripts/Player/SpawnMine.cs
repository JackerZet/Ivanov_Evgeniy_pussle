using UnityEngine;

namespace Puzzle.Player
{
    public class SpawnMine : MonoBehaviour
    {
        [SerializeField] private GameObject mine;
        [SerializeField] private Transform spawnBombPoint;        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {                              
                Instantiate(mine, spawnBombPoint.position, Quaternion.identity);                           
            }           
        }
    }
}
