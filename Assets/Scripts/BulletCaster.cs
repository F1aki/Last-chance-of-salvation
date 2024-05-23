using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCaster : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Transform bulletSourceTransform;
    public Animator animator;
    public float damage = 10;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
            bullet.damage = damage;
            animator.SetTrigger("Shoot");
        }
    }
}
