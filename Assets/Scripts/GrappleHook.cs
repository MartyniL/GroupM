using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    LineRenderer lr;
    Camera cam;
    bool grappled, selected;
    Vector3 targetPos;
    SpringJoint joint;

    public LayerMask layerMask;
    public float maxRange, reelingRate;
    public GameObject grapplingGun;
    public Transform grappleTip;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = ~layerMask;
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 0;
        cam = Camera.main;
        EndGrapple();
        grappled = false;
        selected = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!grappled)
                {
                    Debug.Log("Start Grapple");
                    StartGrapple();
                }
                else
                {
                    Debug.Log("Stop Grapple");
                    EndGrapple();
                }
            }

            if (grappled)
            {
                if (Input.GetButton("Reel"))
                {
                    if (Input.GetAxis("Reel") < -0.1f && joint.maxDistance < maxRange)
                    {
                        joint.maxDistance += reelingRate * Time.deltaTime;
                    }
                    else if (Input.GetAxis("Reel") > 0.1f && joint.maxDistance > 0.5f)
                    {
                        joint.maxDistance += -reelingRate * 2 * Time.deltaTime;
                    }
                }
            }

            UpdateGrapple();
        }
    }

    void StartGrapple()
    {
        if (!GetTarget())
        {
            Debug.Log("No Overall Target");
            return;
        }
        joint = gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = targetPos;
        joint.anchor = transform.InverseTransformPoint(grappleTip.position);

        float distance = Vector3.Distance(grappleTip.position, targetPos);

        joint.maxDistance = distance * 0.8f;
        joint.minDistance = 0.4f;

        joint.spring = 10f;
        joint.damper = 7f;
        //joint.massScale = 4.5f;
        joint.enableCollision = true;

        lr.positionCount = 2;
        grappled = true;
    }

    void EndGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
        grappled = false;
    }

    bool GetTarget()
    {
        bool hitTarget;
        /*Ray ray;
        ray = cam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));*/
        Vector3 targetObj = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(cam.transform.localPosition.z)));
        RaycastHit hit;
        //hitTarget = Physics.Raycast(ray, out hit, 10.5f, layerMask, QueryTriggerInteraction.Ignore); 

        //Vector3 targetObj = hit.transform.position;
        Vector3 rayDir = (targetObj - grappleTip.position).normalized;
        hitTarget = Physics.Raycast(grappleTip.position, rayDir, out hit, maxRange, layerMask);

        if (!hitTarget)
        {
            Debug.Log("No Target");
            return false;
        }

        targetPos = hit.point;
        return true;

    }

    void UpdateGrapple()
    {
        if(!grappled)
        {
            return;
        }

        lr.SetPosition(0, grappleTip.position);
        lr.SetPosition(1, targetPos);
    }

    public void setSelected(bool sel)
    {
        selected = sel;
        if(!sel)
        {
            EndGrapple();
        }
    }
}
