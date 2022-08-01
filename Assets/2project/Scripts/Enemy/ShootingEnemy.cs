using UnityEngine;

namespace Puzzle.Enemy
{
    public class ShootingEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float shotFrequency = 3f;

        private float nextShotTime;
        void Update()
        {
            Shoot();
        }
        private void Shoot()
        {
            if (Time.time > nextShotTime)
            {
                Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                nextShotTime = Time.time + shotFrequency;
            }
        }
    }
}
