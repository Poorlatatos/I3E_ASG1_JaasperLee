using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{

    // Called when Exit Game button is clicked
    public void ExitGame()
    {
        Debug.Log("Exiting game..."); // Useful for testing in editor
        Application.Quit();
    }
}
