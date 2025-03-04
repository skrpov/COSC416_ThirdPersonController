using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    [SerializeField]
    private TMP_Text scoreText;

    void Start()
    {
        
    }
    public void IncrementScore()
    {
        ++score;
        scoreText.text = $"Score: {score}";
    }

    void Update()
    {
        
    }
}
