using UnityEngine;

namespace gamePlayer{
    public class HealPlayer : MonoBehaviour {
        [SerialzieField] private int _heal;
        
        void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                FindObjectOfType<PlayerHealth>().IncreaseHealth(_heal);
                Destroy(gameObject);
            }
        }
    }
}