using UnityEngine;

namespace Puzzle.PickUp
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float damage = 25f;
        [SerializeField] private float timeNoExplose = 4f;
        [SerializeField] private float repulsion = 5f;
        [SerializeField] private float throwForce = 6f;
        
        private float timeNoExploseScale;
        private Rigidbody rb;
        private Vector3 bombForce;     
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
            if (Time.time > timeNoExploseScale)
            {
                Explose(other.gameObject);
                Destroy(gameObject);
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
            }
        }
    }
}
