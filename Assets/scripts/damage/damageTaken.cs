using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageTaken : MonoBehaviour
{
    public int health = 100;

    double _currentHealth;
    double currentHealth {
        get {
            return _currentHealth;
        }
        set {
            _currentHealth = value;
            if(_currentHealth <= 0) {
                Die();
            }
        }
    }

    public void Die() {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
