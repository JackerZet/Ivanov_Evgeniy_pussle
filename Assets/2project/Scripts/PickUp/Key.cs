using UnityEngine;

namespace Puzzle.PickUp
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private Rigidbody rbDoor;
        
        private void OnCollisionEnter(Collision collision)
        {
            Open(collision.gameObject);
        }
        private void OnTriggerEnter(Collider other)
        {
            Open(other.gameObject);
        }
        void Open(GameObject collisionGO)
        {
            if (collisionGO.GetComponent<Puzzle.Player.PlayerMovement>())
            {
                rbDoor.isKinematic = false;
                Destroy(gameObject);
            }            
        }
    }
}
