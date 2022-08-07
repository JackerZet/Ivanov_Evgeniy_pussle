using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Puzzle.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class SmartEnemy : ShootingEnemy
    {
        [SerializeField] private Transform[] waypoints;
        [SerializeField] private float damage = 0.2f;

        private const string targetTag = "Player";
        
        private NavMeshAgent agent;
        private GameObject player;
        private bool visibilityArea = false;                
        private int index;        
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            player = FindObjectOfType<Puzzle.Player.PlayerMovement>().gameObject;
            agent.SetDestination(waypoints[0].position);
        }
        private void OnEnable()
        {
            StartCoroutine(Follow());
        }
        private void Update()
        {
            Patrol();
        }
        private void OnCollisionStay(Collision collision)
        {
            Hit(collision.gameObject);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == player)
                visibilityArea = true;
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == player) 
                visibilityArea = false;
        }
        private IEnumerator Follow()
        {
            while (enabled)
            {
                if (visibilityArea)
                {
                    agent.SetDestination(player.transform.position);                    
                }
                yield return new WaitForFixedUpdate();
            }
            yield return null;
        }
        private void Patrol()
        {           
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                index = (index + 1) % waypoints.Length;
                agent.SetDestination(waypoints[index].position);
            }                        
        }
        private void OnDisable()
        {
            StopCoroutine(Follow());
        }
        private void Hit(GameObject collisionGO)
        {
            if (collisionGO.CompareTag(targetTag) && collisionGO.TryGetComponent(out Puzzle.HealthManager health))
            {                
                health.Hit(damage);
            }
        }
    }
}
