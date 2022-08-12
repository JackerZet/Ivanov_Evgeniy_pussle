using UnityEngine;

namespace Puzzle
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float curHealth = 100f;
        private GameObject player;
        private void Awake()
        {
            curHealth = maxHealth;
        }
        public void Hit(float damage)
        {
            curHealth -= damage;           
            if (curHealth <= 0)
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
