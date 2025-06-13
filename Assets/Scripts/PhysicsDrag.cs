using UnityEngine;

public class PhysicsDrag : MonoBehaviour
{
    public float dragForce = 500f; // Base force for dragging
    public float maxDragDistance = 10f;
    public LayerMask grabbableLayer;
    public Transform holdPoint; // An empty GameObject in front of the player

    private Rigidbody grabbedObject;
    private float originalDrag;
    private float originalAngularDrag;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            TryGrabObject();
        }

        if (Input.GetMouseButtonUp(0))
        {
            ReleaseObject();
        }
    }

    void FixedUpdate()
    {
        if (grabbedObject != null)
        {
            Vector3 direction = (holdPoint.position - grabbedObject.position);
            float distance = direction.magnitude;

            // Force is weaker for heavier objects
            float forceMultiplier = dragForce / grabbedObject.mass;

            grabbedObject.AddForce(direction.normalized * forceMultiplier, ForceMode.Force);

            // Optional: limit max drag distance
            if (distance > maxDragDistance)
            {
                ReleaseObject();
            }
        }
    }

    void TryGrabObject()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDragDistance, grabbableLayer))
        {
            Rigidbody rb = hit.collider.attachedRigidbody;
            if (rb != null && !rb.isKinematic)
            {
                grabbedObject = rb;

                // Store original drag settings
                originalDrag = rb.linearDamping;
                originalAngularDrag = rb.angularDamping;

                // Optional: increase drag to reduce spinning
                rb.linearDamping = 5f;
                rb.angularDamping = 10f;
            }
        }
    }

    void ReleaseObject()
    {
        if (grabbedObject != null)
        {
            // Restore original drag
            grabbedObject.linearDamping = originalDrag;
            grabbedObject.angularDamping = originalAngularDrag;

            grabbedObject = null;
        }
    }
}
