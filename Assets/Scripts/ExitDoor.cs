using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ExitDoor : MonoBehaviour
{
    public string playerTag = "Player";
    public TextMeshProUGUI messageText; // UI message to display

    private bool isPlayerNear = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (ScoreManager.Instance.HasAllItems())
            {
                ExitLevel();
            }
            else
            {
                messageText.text = "You still need to collect all 5 items!";
            }
        }
    }

    void ExitLevel()
    {
        messageText.text = "You unlocked the exit!";
        Debug.Log("Level Complete!");
        SceneManager.LoadScene("EndScreen");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerNear = false;
            messageText.text = ""; // Clear message on exit
        }
    }
}
