using System.Collections;
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
        [SerializeField] private GameObject explosionPoint;
        
        private float _timeNoExploseScale;        
        private Rigidbody _rb;
        private bool _boom = true;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
        private void Start()
        {
            _timeNoExploseScale = Time.time + timeNoExplose;
            StartCoroutine(LonelyExplose());
            _rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        }       
        private void OnTriggerStay(Collider other)
        {
            if (Time.time > _timeNoExploseScale && !other.isTrigger)
            {                               
                Explose(other.gameObject);
                _boom = false;
                Instantiate(explosionPoint, transform.position, Quaternion.identity);
                Destroy(gameObject);
            } 
        }
        private IEnumerator LonelyExplose()
        {
            while (Time.time > _timeNoExploseScale && _boom)
            {                
                Instantiate(explosionPoint, transform.position, Quaternion.identity);
                Destroy(gameObject);                    
                StopCoroutine(LonelyExplose());                
                yield return new WaitForEndOfFrame();
            }
            yield return null;
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
