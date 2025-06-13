using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int currentScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI collectedItemsText;

    private HashSet<string> collectedItems = new HashSet<string>(); // ✅ Unique items only
    public int totalRequiredItems = 5;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
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
        collectedItems.Add(itemName); // HashSet prevents duplicates
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

    public bool HasAllItems()
    {
        return collectedItems.Count >= totalRequiredItems;
    }
}
