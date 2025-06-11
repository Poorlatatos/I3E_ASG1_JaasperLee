using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public DoorController door;
    private bool isPlayerNear = false;
    public bool flipY = false;
    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            door.OpenDoor();

            Vector3 eulerAngles = transform.localEulerAngles;
            if (flipY) { eulerAngles.y = 180; }
            transform.localEulerAngles = eulerAngles;
        }
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