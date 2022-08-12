using UnityEngine;

namespace Puzzle.PickUp
{
    public class Mine : MonoBehaviour
    {
        [SerializeField] private float damage = 25f;
        [SerializeField] private float timeNoExplose = 4f;
        [SerializeField] private float repulsion = 10f;

        private bool Boom = false;
        private float timeNoExploseScale;
        private void Start()
        {
            timeNoExploseScale = Time.time + timeNoExplose;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (Time.time > timeNoExploseScale)
            {               
                Boom = true;
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (Boom && !other.isTrigger)
            {
                Explose(other.gameObject);
                Destroy(gameObject);
            }
        }
        private void Explose(GameObject collisionGO)
        {           
            if (collisionGO.TryGetComponent(out Rigidbody rb))
            {
                rb.AddForce((rb.position - transform.position).normalized * repulsion, ForceMode.Impulse);
                if (collisionGO.TryGetComponent(out HealthManager health))
                {
                    health.Hit(damage);                    
                }              
            }
        }
    }
}
