using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public DoorController door;

    public VentilationSwitch vent;
    private bool isPlayerNear = false;
    private bool hasBeenFlipped = false;
    public AudioSource playSound;
    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && !hasBeenFlipped)
        {
            door.OpenDoor();
            FlipSwitch();
            hasBeenFlipped = true; // Prevent multiple flips
            playSound.Play();
        }
    }

    void FlipSwitch()
    {
        // Flip the switch 180 degrees on the Y axis
        transform.Rotate(0, 180f, 0);
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