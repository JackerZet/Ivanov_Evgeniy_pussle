using UnityEngine;

namespace Puzzle
{
    public class HealthManager : MonoBehaviour
    {
        public float maxHealth = 100f;
        public float curHealth = 100f;        
        private void Awake()
        {
            curHealth = maxHealth;
        }
        public void Hit(float damage)
        {
            curHealth -= damage;           
            if (curHealth <= 0 && gameObject != null)
            {                                                                              
                Destroy(gameObject);                
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
