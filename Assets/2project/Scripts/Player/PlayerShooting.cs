using UnityEngine;

namespace Puzzle.Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private GameObject playerBullet;
        [SerializeField] private Transform spawnBulletPoint;
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(playerBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);
            }
        }
    }
}
