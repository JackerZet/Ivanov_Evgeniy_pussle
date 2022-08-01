using UnityEngine;

namespace Puzzle
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float curHealth = 100f;

        private void Awake()
        {
            curHealth = maxHealth;
        }
        public void Hit(float damage)
        {
            curHealth -= damage;
            if (curHealth <= 0)
            {
                if (gameObject.GetComponent<Puzzle.Player.PlayerMovement>())
                { 
                    Time.timeScale = 0f; 
                }
                else
                {                  
                    Destroy(gameObject);                   
                }
            } 
        }
        public void Heal(float cure)
        {
            curHealth += cure;
            if (curHealth > maxHealth)
            {
                curHealth = maxHealth;
            }
        }
    }
}
