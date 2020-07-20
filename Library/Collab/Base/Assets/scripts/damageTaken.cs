using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageTaken : MonoBehaviour
{
    public int lives = 5;

    int _currentLives;
    int currentLives {
        get {
            return _currentLives;
        }
        set {
            _currentLives = value;
            if(_currentLives <= 0) {
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
        currentLives = lives;
    }

    public void TakeDamage(int amount = 1) {
        currentLives -= amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
