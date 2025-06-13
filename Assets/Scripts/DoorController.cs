using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;
    public Vector3 openPositionOffset = new Vector3(0, 4, 0);
    private Vector3 closedPosition;
    private Vector3 openPosition;
    public float openSpeed = 2f;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + openPositionOffset;
    }

    void Update()
    {
        if (isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, Time.deltaTime * openSpeed);
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
    }
}