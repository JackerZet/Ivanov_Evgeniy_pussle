using UnityEngine;

namespace Puzzle.Player
{
    public class SpawnBomb : MonoBehaviour
    {
        [SerializeField] private GameObject bomb;
        [SerializeField] private Transform spawnBombPoint;        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {                              
                Instantiate(bomb, spawnBombPoint.position, Quaternion.identity);                               
            }           
        }
    }
}
