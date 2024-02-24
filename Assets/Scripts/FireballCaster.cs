    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball firebalPrefab;
    public Transform fireballSourceTransform;
    void Start()

    {
        
    }

    // Update is called once per frame
    private void Update()
    {
      FireballCasting();
    }
    private void FireballCasting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(firebalPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
        }
    }
}
