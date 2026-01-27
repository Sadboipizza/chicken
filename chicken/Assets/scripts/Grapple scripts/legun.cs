using UnityEngine;

public class legun : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector2 targetPosition;
    public LayerMask grappleableLayer;
    public Transform tip, maincamera, player;
    private float maxDistance = 100f;
    private TargetJoint2D targetJoint;
    private Vector2 currentGrapPosition;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    public void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            StartGraple();
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGraple();
        }
    }
   void LateUpdate()
    {
        DrawRope();
    }

    public void StartGraple()
    {
        RaycastHit2D hit = Physics2D.Raycast(
             maincamera.position,(Camera.main.ScreenToWorldPoint(Input.mousePosition) - maincamera.position).normalized,
            maxDistance,
            grappleableLayer.value 
        );

        if (hit.collider != null)
        {
            targetPosition = hit.point;
          
            targetJoint = player.gameObject.AddComponent<TargetJoint2D>();
            targetJoint.autoConfigureTarget = false;
            targetJoint.target = targetPosition;
            float distance = Vector2.Distance(player.position, targetPosition);

            targetJoint.maxForce = 0.8f * distance;

            targetJoint.dampingRatio = 1f;
            targetJoint.frequency = 5f;
            lineRenderer.positionCount = 2;
            currentGrapPosition = targetPosition;
        }
    }
    void DrawRope()
    {
        if (!targetJoint) return;
        lineRenderer.SetPosition(0, tip.position);
        lineRenderer.SetPosition(1, targetPosition);
        currentGrapPosition = Vector2.Lerp(currentGrapPosition, targetPosition, Time.deltaTime * 8f);
    }
    public void StopGraple()
    {
        lineRenderer.positionCount = 0;
        Destroy(targetJoint);
    }
    public bool IsGrapling()
    {
        return targetJoint != null;
    }
    public Vector2 GetGrapplePosition()
    {
        return currentGrapPosition;
    }
}
