using UnityEngine;

namespace Puzzle.Player
{
    public class SpawnMine : MonoBehaviour
    {
        [SerializeField] private GameObject mine;
        [SerializeField] private ControlledObject contObj;
        [SerializeField] private float spawnMineDisMax = 12f;
        
        private bool clickC = false;

        private Vector3 camPoswithMine; 
        private Vector3 posMax;
        private Vector3 hitPos;
        private RaycastHit hit;
        private Ray rayCursor;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {               
                Cursor.lockState = CursorLockMode.None;
                clickC = true;
                contObj.ShootingDisable();
            }
            if (Input.GetMouseButtonDown(0) && clickC)
            {               
                Click();
                Cursor.lockState = CursorLockMode.Locked;
                clickC = false;
                contObj.ShootingEnable();
            }
        }
        private void Click()
        {
            rayCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
            posMax = rayCursor.origin + rayCursor.direction * spawnMineDisMax;
            Physics.Raycast(rayCursor, out hit, spawnMineDisMax, 1 << 0, QueryTriggerInteraction.Ignore);
            hitPos = hit.point;
            hitPos.y += 0.1f;           
            Instantiate(mine, hit.distance <= spawnMineDisMax && hit.distance != 0 ? hitPos : posMax, Quaternion.identity);                                 
        }       
    }
}
