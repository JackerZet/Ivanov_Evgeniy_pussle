using UnityEngine;

namespace Puzzle.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 6f;
        [SerializeField] private float turnSpeed = 190f;
        [SerializeField] private float runSpeed = 11f;
        [SerializeField] private float jumpForce = 6f;
        
        public GameObject player;

        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Running = "Running";
        private const string MouseX = "Mouse X";

        private Vector3 direction;
        private float rotationDirX;       
        private bool isRunning;
        private Rigidbody rb;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            rb = GetComponent<Rigidbody>();
        }
        void Update()
        {
            RotateCamera();
            Move();
            Jump();
        }
        private void Jump()
        {
            //Ball can jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Ball can jump higher when shift is pressed
                rb.AddForce(transform.up * (isRunning ? (jumpForce * 1.5f) : jumpForce), ForceMode.Impulse);
            }
        }
        private void Move()
        {      
            direction.x = Input.GetAxis(Horizontal);
            direction.z = Input.GetAxis(Vertical);
            direction = transform.TransformDirection(direction); //I have been looking for this method for a very long time
            isRunning = Input.GetButton(Running);
            
            player.transform.position += direction * ((isRunning ? runSpeed : speed) * Time.deltaTime);
        }
        private void RotateCamera()
        {            
            rotationDirX += Input.GetAxis(MouseX) * turnSpeed * Time.deltaTime;            

            player.transform.rotation = Quaternion.Euler(0f, rotationDirX, 0f);
        }
    }
}
