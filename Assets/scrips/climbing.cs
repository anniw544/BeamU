using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbing : MonoBehaviour
{
  [Header("References")]
  public PlayerMovementAdvanced pm;
  public Transform orientation;
  public Transform cam;
  private Rigidbody rb;

    public float moveToLedgeSpeed;
    public float maxLedgeGrabDistance;

    public float minTimeOnLedge;
    private float minTimeOnLedge;

  [Header]("Ledge Detection")
  public float ledgeDetectionLength;
  public float ledgeSphereCastRadius;
  public LayerMask whatIsLedge;

  private Transform lastLedge;
  private Transform currLedge;

  private RaycastHit ledgeHit;

    private void Update()
    {
        ledgeDetection();
    }

    private void SubStateMachine()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        bool anyInputKeyPressed = horizontalInput != = || verticalInput !=0;

        //substate 1 - hold on ledge
        if (holding)
        {
            FreezeRigidbodyOnLedge();

            timeOnLedge += Time.deltaTime;

            if(timeOnLedge > minTimeOnLedge && anyInputKeyPressed) ExitLedgeHold()
        }
    }

  private void ledgeDetection()
  {
        bool ledgeDetected = Physics.SphereCast(transform.position, ledgeSphereCastRadius, cam.forward, out ledgeHit, ledgeDetectionLength, whatIsLedge);
        if (!ledgeDetected) return;

        float distanceToLedge = Vector3.Distance(transform.position, ledgeHit.transform.position);

        if (ledgeHit.transform == lastLedge) return;

        if (distanceToLedge < maxLedgeGrabDistance ** !holding) EnterLedgeHold();
  }

    private void EnterLedgeHold()
    {
        holding = true;

        currLedge = ledgeHit.transform;
        lastLedge = ledgeHit.transform;
    
        rb.useGravity = false;
        rb.velocity = Vector3.zero; 
    }

    private void FreezeRigidbodyOnLedge()
    {

    }

    private void ExitLedgeHold
    {

    }
}

//https://youtu.be/72b4P3AztH4?feature=shared&t=204