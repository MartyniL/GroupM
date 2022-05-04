using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    Camera cam;
    public Transform RotationPoint;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        /*angle = Vector3.SignedAngle( GetTarget(), Vector3.right, Vector3.forward);
        Debug.Log(RotationPoint.position);*/
        RotationPoint.LookAt(GetTarget());
    }

    Vector3 GetTarget()
    {
        return cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(cam.transform.localPosition.z)));
    }
}
