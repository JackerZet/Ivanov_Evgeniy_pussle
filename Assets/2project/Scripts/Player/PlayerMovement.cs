using UnityEngine;

namespace Puzzle.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 6f;
        [SerializeField] private float turnSpeed = 5f;
        [SerializeField] private float runSpeed = 11f;
        [SerializeField] private float jumpForce = 6f;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject playerCamera;
        [SerializeField] private GameObject isGroundPoint;

        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Running = "Running";
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";
        private const string Ground = "Ground";

        private Vector3 direction;
        private float rotationDirX;
        private float rotationDirY;
        private bool isRunning;
        private Rigidbody rb;
        private bool isGround;
        private void Awake() 
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
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                //Ball can jump higher when shift is pressed               
                rb.AddForce(player.transform.up * (isRunning ? (jumpForce * 1.5f) : jumpForce), ForceMode.Impulse);
            }
        }
        private void Move()
        {      
            direction.x = Input.GetAxis(Horizontal);
            direction.z = Input.GetAxis(Vertical);
            direction = player.transform.TransformDirection(direction); //I have been looking for this method for a very long time
            isRunning = Input.GetButton(Running);
            
            player.transform.position += direction * ((isRunning ? runSpeed : speed) * Time.deltaTime);
        }
        private void RotateCamera()
        {            
            rotationDirX += Input.GetAxis(MouseX) * turnSpeed;
            rotationDirY += Input.GetAxis(MouseY) * turnSpeed;
            rotationDirY = Mathf.Clamp(rotationDirY, -90, 90);

            playerCamera.transform.rotation = Quaternion.Euler(-rotationDirY, rotationDirX, 0f);
            player.transform.rotation = Quaternion.Euler(0f, rotationDirX, 0f);
        }        
        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag(Ground))
                isGround = true;        
        }
        private void OnCollisionExit(Collision other)
        {                        
            isGround = false;                  
        }
        private void OnDestroy()
        {
            Time.timeScale = 0f;          
        }
    }
}
