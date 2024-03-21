    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball firebalPrefab;
    public Transform fireballSourceTransform;
    public float damage = 10;
    private void Update()
    {
      FireballCasting();
    }
    private void FireballCasting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var fireball = Instantiate(firebalPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
            fireball.damage = damage;
        }
    }
}
