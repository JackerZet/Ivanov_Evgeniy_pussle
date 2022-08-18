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

        private Transform _player;
        private float _timeFind;
        private float _timeDestr;
        private void Awake()
        {           
            _player = FindObjectOfType<Player.PlayerMovement>().transform;           
        }
        private void Start()
        {           
            _timeFind = Time.time + timeFinding;
            _timeDestr = Time.time + timeDestroy;
            if (!homing)
            {
                _timeFind = 0;
            }
        }
        void Update()
        {         
            Shot();
            if (Time.time < _timeFind && _player != null)
            {               
                LookAtPlayer();               
            }
            if (Time.time > _timeDestr)
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
            var direction = _player.transform.position - transform.position;
            var rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(rotation);
        }
    }
}
