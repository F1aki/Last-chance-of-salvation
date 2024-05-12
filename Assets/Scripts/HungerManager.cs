using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerManager : MonoBehaviour
{
    public float hungerValue = 100;
    public RectTransform HunRectTransform;
    public PlayerController _pl;
    public PlayerHealth _ph;

    private float _maxHunValue;
    private float normspeed;

    public void Start()
    {
        _maxHunValue = hungerValue;
        DrawHunBar();
        normspeed = _pl.speed;
    }
    public void FixedUpdate()
    {
        var t = 5;
        if (IsInvoking())
        {
            t = 0;
        }
        else
        {
            Invoke("Hunger", t);
        }
    }
    private void DrawHunBar()
    {
        HunRectTransform.anchorMax = new Vector2(hungerValue / _maxHunValue, 0.5f);
    }

    public void Hunger()
    {
        if (hungerValue > 0)
        {
            hungerValue -= _pl.speed;
            _pl.speed = normspeed;
        }
        else if (hungerValue < 0)
        {
            hungerValue = 0;
            _ph.DealDamage(10);
            _pl.speed = _pl.speed / 3;
        }

        DrawHunBar();
    }

}
