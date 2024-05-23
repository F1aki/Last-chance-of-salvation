using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    public Animator animator;
    private float _maxValue;
    public AudioSource Sound;

    private void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }

    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }
    public void AddHealth(float amount)
    {
        //value += amount;
        //value = Mathf.Clamp(value, 0, _maxValue);
        //DrawHealthBar();
    }
    private void PlayerIsDead()
    {
        animator.SetTrigger("Death");
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        Sound.Play();
        
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 0.5f);
    }
}
