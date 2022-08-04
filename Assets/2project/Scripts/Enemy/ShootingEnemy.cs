using System.Collections;
using UnityEngine;

namespace Puzzle.Enemy
{
    public class ShootingEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float shotFrequency = 3f;
        
        private void OnEnable()
        {
            StartCoroutine(Shoot());
        }      
        private IEnumerator Shoot()
        {
            while (enabled)
            {
                Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);                
                yield return new WaitForSeconds(shotFrequency);
            }
            yield return null;
        }
        private void OnDisable()
        {
            StopCoroutine(Shoot());
        }
    }
}
