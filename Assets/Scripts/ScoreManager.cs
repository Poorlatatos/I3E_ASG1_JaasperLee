using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int currentScore = 0;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI collectedItemsText; // <-- Add this in Inspector
    private List<string> collectedItems = new List<string>(); // <-- Track items

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
        UpdateCollectedItemsText();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreText();
    }

    public void AddCollectedItem(string itemName)
    {
        collectedItems.Add(itemName);
        UpdateCollectedItemsText();
    }

    void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    void UpdateCollectedItemsText()
    {
        collectedItemsText.text = "Collected:\n";
        foreach (string item in collectedItems)
        {
            collectedItemsText.text += "- " + item + "\n";
        }
    }
}