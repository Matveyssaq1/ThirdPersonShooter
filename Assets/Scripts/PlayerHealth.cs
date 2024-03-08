using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{ 

    public float health = 100;
    public RectTransform valueRectTransform;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    private float _maxHealth;
// Start is called before the first frame update
    void Start()
    {
        _maxHealth = health;
        DrawHealthBar();
    }


    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameOverScreen.SetActive(true);
            gameplayUI.SetActive(false);
            PlayerIsDead();

        }
        DrawHealthBar();
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(health / _maxHealth, 1) ;
    }
    private void PlayerIsDead()
    {
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }

}
