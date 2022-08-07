using UnityEngine;

namespace Puzzle.Enemy 
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private bool homing = true;
        [SerializeField] private float timeFinding = 3f;
        [SerializeField] private float timeDestroy = 7f;
        [SerializeField] private float speed = 8f;
        [SerializeField] private float angularSpeed = 0.8f;
        [SerializeField] private float damage = 5f;

        private const string targetTag = "Player";

        private Transform player;
        private float timeFind;
        private float timeDestr;
        private void Awake()
        {
            player = FindObjectOfType<Puzzle.Player.PlayerMovement>().transform;
        }
        private void Start()
        {           
            timeFind = Time.time + timeFinding;
            timeDestr = Time.time + timeDestroy;
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
            if (Time.time > timeDestr)
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
        private void Hit(GameObject collisionGO)
        {
            if (collisionGO.CompareTag(targetTag) && collisionGO.TryGetComponent(out Puzzle.HealthManager health))
            {                               
                health.Hit(damage);                               
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
