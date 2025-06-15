using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public string Player = "Player";

    public float amp;
    public float freq;
    Vector3 initPos;

    public int scoreValue = 1;
    public string itemName = "Unnamed Item"; // <-- Add this line
    public AudioSource playSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Player))
        {
            ScoreManager.Instance.AddScore(scoreValue);

            playSound.Play();

            // Notify the UI of this collected item
            ScoreManager.Instance.AddCollectedItem(itemName);

            Debug.Log("Collected: " + itemName);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        initPos = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp + initPos.y, initPos.z);
    }
}