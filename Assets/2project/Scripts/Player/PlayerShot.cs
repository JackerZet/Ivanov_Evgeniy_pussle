using UnityEngine;

namespace Puzzle.Player
{
    public class PlayerShot : MonoBehaviour
    {
        [SerializeField] private float speed = 12f;
        [SerializeField] private float damage = 5f;
        void Update()
        {
            Shot();
        }
        private void Shot()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        private void OnCollisionEnter(Collision collision)
        {
            Hit(collision.gameObject);
        }
        private void OnTriggerEnter(Collider other)
        {
            Hit(other.gameObject);
        }
        private void Hit(GameObject collisionGO)
        {
            if (collisionGO.TryGetComponent(out Puzzle.HealthManager health))
            {
                if (collisionGO.GetComponent<Puzzle.Player.PlayerMovement>() == false)
                {
                    health.Hit(damage);
                }
            }
            Destroy(gameObject);
        }
    }
}
