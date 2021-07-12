using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    private Text text;
    private int score;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Start()
    {
        UpdateText();
    }

    public void AddToScore(int value = 1)
    {
        score += value;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = score.ToString();
    }
}
