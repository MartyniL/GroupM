using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody body;
    public float bulletspeed;
    public float lifeTime;
    public Vector3 bulletDir, collisionAngles;
    public Bow bowController;
    public bool stuck;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        bulletspeed = bowController.drawstrength;
        body.AddForce(transform.TransformDirection(bulletDir * bulletspeed), ForceMode.VelocityChange);
        StartCoroutine(lifespan());
    }

    private void FixedUpdate()
    {
        if (!stuck)
        {
            transform.LookAt(transform.position + body.velocity);
        }
        else
        {
            transform.eulerAngles = collisionAngles;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        body.isKinematic = true;
        stuck = true;
        transform.position = collision.GetContact(0).point;
        collisionAngles = transform.eulerAngles;
        //transform.parent = collision.collider.transform;
    }
    IEnumerator lifespan()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }


}
