using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSystem : MonoBehaviour
{
    //Player variables
    public HealthBarScript healthBar;
    private int MaxHealth = 100;
    public static int score = 1000;
    private string status = "PERFECT STEALTH";
    public Text healthRemainingLabel;
    public Text healthRemaining;
   
    public Text scoreRemainingLabel;
    public Text scoreRemaining;
    public Text statusRemainingLabel;
    public Text statusRemaining;

    int _currentHealth;
    int _currentScore;
    string _currentStatus;
    Color OrigColor;
    int currentScore {
        get {
            return _currentScore;
        }
        set {
            _currentScore = value;
            if(_currentScore <= 0) {
                //player.GetComponent<respawn>().respawnMe(player);
                //Die(); we need to do something here
            }
        }
    }
    int currentHealth {
        get {
            return _currentHealth;
        }
        set {
            _currentHealth = value;
            if(_currentHealth <= 0) {
                //player.GetComponent<respawn>().respawnMe(player);
                //Die(); we need to do something here
            }
        }
    }

    string currentStatus {
        get {
            return _currentStatus;
        }
        set {
            _currentStatus = value;
        }
    }

    // Start is called before the first frame update
    void Start() //reset all values
    {
        healthBar.SetMaxHealth(MaxHealth);
        OrigColor = healthRemainingLabel.color;
        currentHealth = MaxHealth;
        currentScore = score;
        currentStatus = status;
        UpdateUI();
    }

    public void gunShoot(int amountScore) { //if gun is shot lower the score by set amount
        currentScore -= amountScore;
        UpdateUI();
    }

    public bool TakeDamage(int amountHealth, int amountScore) { //if hit with trap take damage lose score and see if dead
        currentHealth -= amountHealth;
        healthBar.setHealth(currentHealth);
        currentScore -= amountScore;
        UpdateUI();
        return isDead();
    }

    public bool isDead() { //method to check if dead
        if(currentHealth <= 0) {
            return true;
        }
        return false;
    }

    public void reset() { //reset all variables
        healthBar.SetMaxHealth(MaxHealth);
        currentHealth = MaxHealth;
        currentScore = score;
        currentStatus = status;
        healthRemainingLabel.color = OrigColor;
        healthRemaining.color = OrigColor;
        scoreRemainingLabel.color = OrigColor;
        scoreRemaining.color = OrigColor;
        statusRemainingLabel.color = OrigColor;
        statusRemaining.color = OrigColor;
        UpdateUI();
    }

    public void UpdateUI() { //update ui every frame
        if(healthRemainingLabel != null) {
            healthRemainingLabel.text = currentHealth.ToString();
        }
        if(healthRemainingLabel.text == "0") {
            healthRemainingLabel.color = Color.red;
            healthRemaining.color = Color.red;
        }
        if(scoreRemainingLabel != null) {
            scoreRemainingLabel.text = currentScore.ToString();
        }
        if(scoreRemainingLabel.text == "500") {
            scoreRemainingLabel.color = Color.red;
            scoreRemaining.color = Color.red;
            statusRemainingLabel.color = Color.red;
            statusRemaining.color = Color.red;
        }
        if(statusRemainingLabel != null) {
            if(currentScore > 900) statusRemainingLabel.text = "PERFECT STEALTH";
            if(currentScore <= 900 && currentScore > 700) statusRemainingLabel.text = "GOOD STEALTH";
            if(currentScore <= 700 && currentScore > 500) statusRemainingLabel.text = "OK STEALTH";
            if(currentScore <= 500) statusRemainingLabel.text = "ABYSMAL STEALTH";
        }
    }
}
