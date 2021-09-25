using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    Text highScoreText;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        highScoreText = GetComponent<Text>();
        highScoreText.text = UIMenu.Instance.highscore;
    }

    public void SetHighScore(string player, int score)
    {
        if (player != null && highScoreText!= null)
        {
            highScoreText.text = $"Best Score: {player}:{score}";
        }
    }
}
