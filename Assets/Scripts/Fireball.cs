using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    void Start()
    {
        Invoke("DestroyFireball", lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveFixedUpdate();
        
        
    }
    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        DestroyFireball();  
    }
    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
}
