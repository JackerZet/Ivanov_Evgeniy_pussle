using UnityEngine;

namespace Puzzle.Enemy 
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private bool homing = true;
        [SerializeField] private float timeFinding = 3f;
        [SerializeField] private float speed = 8f;
        [SerializeField] private float angularSpeed = 0.8f;
        [SerializeField] private float damage = 5f;

        private Transform player;
        private float timeFind;
        private float timeDestroy;       
        private void Start()
        {
            player = FindObjectOfType<Puzzle.Player.PlayerMovement>().transform;
            timeFind = Time.time + timeFinding;
            timeDestroy = Time.time + 7f;
            if (!homing)
            {
                timeFind = 0;
            }
        }
        void Update()
        {         
            Shot();
            if (Time.time < timeFind)
            {               
                LookAtPlayer();               
            }
            if (Time.time > timeDestroy)
            {
                Destroy(gameObject);
            }
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
                if (collisionGO.GetComponent<Puzzle.Player.PlayerMovement>())
                {
                    health.Hit(damage);
                }                
            }
            Destroy(gameObject);
        }
        private void LookAtPlayer()
        {
            var direction = player.transform.position - transform.position;
            var rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(rotation);
        }
    }
}
