using UnityEngine;

namespace Puzzle.Player
{   
    public class PlayerShooting : ControlledObject
    {
        [SerializeField] private GameObject playerBullet;
        [SerializeField] private Transform spawnBulletPoint;
        private bool shooting = true;

        public override void ShootingDisable()
        {
            shooting = false;
        }

        public override void ShootingEnable()
        {
            shooting = true;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (shooting)
                {
                    Instantiate(playerBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);
                }
            }
        }
    }
}
