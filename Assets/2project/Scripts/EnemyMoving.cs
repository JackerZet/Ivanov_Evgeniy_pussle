using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class EnemyMoving : MonoBehaviour
    {
        //Enemy can randomly jump
        [SerializeField] private int probabilityToJumpInFrame = 700;
        [SerializeField] private float jumpForce = 8f;

        private Rigidbody rb;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        void Update()
        {           
            if (Random.Range(0, probabilityToJumpInFrame) == 0)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
