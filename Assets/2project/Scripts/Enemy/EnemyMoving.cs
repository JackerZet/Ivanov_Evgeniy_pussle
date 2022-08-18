using UnityEngine;

namespace Puzzle.Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyMoving : MonoBehaviour
    {
        //Enemy can randomly jump
        [SerializeField] private int probabilityToJumpInFrame = 700;
        [SerializeField] private float jumpForce = 8f;

        private Rigidbody rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        void Update()
        {           
            if (Random.Range(0, probabilityToJumpInFrame) == 0)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
            if (Random.Range(0, probabilityToJumpInFrame) == 0)
            {
                rb.AddForce(transform.right * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
