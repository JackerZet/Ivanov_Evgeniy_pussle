using UnityEngine;

namespace Puzzle.PickUp
{   
    public class Heart : MonoBehaviour
    {
        [SerializeField] private float healingDamage = 50f;
        private const string Player = "Player";
        
        private void OnCollisionEnter(Collision collision)
        {
            Heal(collision.gameObject);
        }
        private void OnTriggerEnter(Collider other)
        {
            Heal(other.gameObject);
        }       
        private void Heal(GameObject collisionGO)
        {
            if (collisionGO.CompareTag(Player) && collisionGO.TryGetComponent(out HealthManager health))
            {               
                health.Heal(healingDamage);
                Destroy(gameObject);            
            }
        }
    }
}
