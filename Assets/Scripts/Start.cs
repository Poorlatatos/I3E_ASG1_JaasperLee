using UnityEngine;
using UnityEngine.SceneManagement;
public class Start : MonoBehaviour
{
    // Called when Start Game button is clicked
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Replace "GameScene" with your actual scene name
    }
}