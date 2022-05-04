using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
  private LineRenderer lr;
  private Vector3 grapplePoint;
  public LayerMask whatIsGrappleable;
  public Transform gunTip, player;
  private SpringJoint joint;
  public bool isGrappling;

  public float hotUpdateSpring, hotUpdateDampen, maxDistance;

  private void Awake()
  {
    lr = GetComponent<LineRenderer>();
  }

  private void Update()
  {
        if (Input.GetMouseButtonDown(0) && PauseMenu.paused == false)
        {
          StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
          StopGrapple();
        }
  }

  private void LateUpdate()
  {
    DrawRope();
  }

  void StartGrapple()
  {
        RaycastHit hit;
        if (Physics.Raycast(player.position, gunTip.up, out hit, maxDistance, whatIsGrappleable))
        {
                isGrappling = true;
                grapplePoint = hit.point;

                joint = player.gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grapplePoint;

                float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

                // The distance grapple will try to keep from grapple point
                joint.maxDistance = distanceFromPoint * 0.011f;
                joint.minDistance = 0;

                joint.spring = hotUpdateSpring;
                joint.damper = hotUpdateDampen;
                joint.massScale = 4.5f;

                lr.positionCount = 2;
        }
  }

  void DrawRope()
  {
    if (!joint) return;
    lr.SetPosition(0, player.position);
    lr.SetPosition(1, grapplePoint);
  }

  void StopGrapple()
  {
        isGrappling = false;
    lr.positionCount = 0;
    Destroy(joint);
  }

  public Vector3 GetGrapplePoint()
  {
    return grapplePoint;
  }
}
