using UnityEngine;

namespace Puzzle.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float turnSpeed = 20f;

        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";

        private float rotationDirX;
        private float rotationDirY;
        private float currentYRotation;
        private float _maxDistance;
        private Vector3 _localPosition;       

        private Vector3 _position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        void Start()
        {
            _maxDistance = Vector3.Distance(_position, player.position);
            _localPosition = player.InverseTransformPoint(_position);
        }
        void LateUpdate()
        {
            if (FindObjectOfType<Puzzle.Player.PlayerMovement>())
            {
                _position = player.TransformPoint(_localPosition);
                RotateCamera();
                ConfigurateCamera();
                _localPosition = player.InverseTransformPoint(_position);
            }           
        }
        private void RotateCamera()
        {
            rotationDirX = Input.GetAxis(MouseX) * turnSpeed;
            rotationDirY = Input.GetAxis(MouseY) * turnSpeed;
            if (rotationDirY != 0)
            {
                var tmp = Mathf.Clamp(currentYRotation + rotationDirY * turnSpeed * Time.deltaTime, -89, 89);
                if (tmp != currentYRotation)
                {
                    var rotation = tmp - currentYRotation;
                    transform.RotateAround(player.position, -transform.right, rotation);                   
                    currentYRotation = tmp;
                }               
            }
            if (rotationDirX != 0)
            {                                                        
                transform.RotateAround(player.position, Vector3.up, rotationDirX * turnSpeed * Time.deltaTime);
                player.RotateAround(player.position, Vector3.up, rotationDirX * turnSpeed * Time.deltaTime);
            }                
            transform.LookAt(player);
        }
        private void ConfigurateCamera()
        {
            var distance = Vector3.Distance(_position, player.position);
            RaycastHit hit;
            if (Physics.Raycast(player.position, transform.position - player.position, out hit, _maxDistance, 1 << 0, QueryTriggerInteraction.Ignore))
            {
                _position = hit.point;
            }
            else if (distance < _maxDistance && !Physics.Raycast(_position, -transform.forward, .1f, 1 << 0, QueryTriggerInteraction.Ignore))
            {
                _position -= transform.forward * .05f;
            }           
        }
    }
}
