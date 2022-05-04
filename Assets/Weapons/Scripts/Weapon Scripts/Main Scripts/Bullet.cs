using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody body;
    public float bulletspeed;
    public float lifeTime;
    public Vector3 bulletDir;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        body.AddForce(transform.TransformDirection(bulletDir * bulletspeed), ForceMode.VelocityChange);
        StartCoroutine(lifespan());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    IEnumerator lifespan()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
