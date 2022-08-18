using System.Collections;
using UnityEngine;

namespace Puzzle.Player
{   
    public class PlayerShooting : ControlledObject
    {
        [SerializeField] private GameObject playerBullet;
        [SerializeField] private Transform spawnBulletPoint;
        [SerializeField] private float shotFrequency = 0.3f;
        private bool _shooting = true;

        private void OnEnable()
        {
            StartCoroutine(Shooting());
        }
        public override void ShootingDisable()
        {
            _shooting = false;
        }

        public override void ShootingEnable()
        {
            _shooting = true;
        }     
        private IEnumerator Shooting()
        {
            while (enabled)
            {
                if (Input.GetMouseButton(0) && _shooting)
                {
                    Instantiate(playerBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);
                }
                yield return new WaitForSeconds(shotFrequency);
            }
            yield return null;
        }
        private void OnDisable()
        {
            StopCoroutine(Shooting());
        }
    }
}
