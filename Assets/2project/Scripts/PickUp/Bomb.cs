using UnityEngine;

namespace Puzzle.PickUp
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float damage = 25f;
        [SerializeField] private float timeNoExplose = 4f;
        [SerializeField] private float repulsion = 10f;
        [SerializeField] private float throwForce = 6f;
        
        private float timeNoExploseScale;
        private Rigidbody rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();                      
        }
        private void Start()
        {
            timeNoExploseScale = Time.time + timeNoExplose;
            rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        }
        private void OnTriggerStay(Collider other)
        {
            if (Time.time > timeNoExploseScale && !other.isTrigger)
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
