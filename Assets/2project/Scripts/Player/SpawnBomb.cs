using UnityEngine;

namespace Puzzle.Player
{
    public class SpawnBomb : MonoBehaviour
    {
        [SerializeField] private GameObject bomb;
        [SerializeField] private Transform spawnBombPoint;
        
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {                              
                Instantiate(bomb, spawnBombPoint.position, spawnBombPoint.rotation);
            }           
        }
    }
}
