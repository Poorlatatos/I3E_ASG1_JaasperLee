using UnityEngine;

public class VentilationSwitch : MonoBehaviour
{
    public GameObject[] objectsToDestroy; // Assign in Inspector
    private bool isPlayerNear = false;
    private bool hasBeenFlipped = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && !hasBeenFlipped)
        {
            FlipSwitch();
            DestroyAssignedObjects();
            hasBeenFlipped = true;
        }
    }

    void FlipSwitch()
    {
        transform.Rotate(0, 180f, 0); // Flip the switch on the Y-axis
    }

    void DestroyAssignedObjects()
    {
        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }

        Debug.Log("Ventilation shaft cleared.");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
