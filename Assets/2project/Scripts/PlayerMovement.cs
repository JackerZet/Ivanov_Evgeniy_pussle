using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f; 
        [SerializeField] private float runSpeed = 9f;
        [SerializeField] private float jumpForce = 5f;

        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Running = "Running";
        
        private Vector3 direction;
        private bool isRunning;
        private Rigidbody rb;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        void Update()
        {
            //Ball can jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Ball can jump higher when shift is pressed
                rb.AddForce(transform.up * (isRunning ? (jumpForce*1.5f) : jumpForce), ForceMode.Impulse);
            }
            direction.x = Input.GetAxis(Horizontal);
            direction.z = Input.GetAxis(Vertical);
            isRunning = Input.GetButton(Running);
            transform.position += direction * ((isRunning ? runSpeed : speed) * Time.deltaTime);
            
        }
    }
}
