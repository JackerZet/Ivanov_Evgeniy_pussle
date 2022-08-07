using UnityEngine;

namespace Puzzle.PickUp
{
    public class Mine : MonoBehaviour
    {
        [SerializeField] private float damage = 25f;
        [SerializeField] private float timeNoExplose = 4f;
        [SerializeField] private float repulsion = 5f;

        private bool Boom = false;
        private float timeNoExploseScale;
        private Vector3 bombForce = new Vector3();
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
            if (Boom)
            {
                Explose(other.gameObject);              
            }
        }
        private void Explose(GameObject collisionGO)
        {           
            if (collisionGO.TryGetComponent(out Rigidbody rb))
            {
                bombForce = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z) - transform.position;               
                rb.AddForce(bombForce.normalized * repulsion, ForceMode.Impulse);
                if (collisionGO.TryGetComponent(out HealthManager health))
                {
                    health.Hit(damage);                    
                }
                Destroy(gameObject);
            }
        }
    }
}
