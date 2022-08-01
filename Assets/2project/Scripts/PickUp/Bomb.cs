using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle.PickUp
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float damage = 25f;
        [SerializeField] private float timeNoExplose = 4f;      
        
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
            if (Boom)
            {
                Explose(other.gameObject);              
            }
        }
        private void Explose(GameObject collisionGO)
        {
            if (collisionGO.TryGetComponent(out HealthManager health))
            {
                health.Hit(damage);               
                Destroy(gameObject);                             
            }
        }      
    }
}
