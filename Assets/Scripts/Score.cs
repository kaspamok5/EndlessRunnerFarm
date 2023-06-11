using System.Runtime.CompilerServices;
using System.Text;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreTextObject;
    public int score;
    public GameObject player;
    public int scoreTextSize = 8;
    private string scoreText;
    private string newScoreText;
    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().startedRunning)
        {
            score++;
            scoreText = scoreTextObject.text;
            scoreText = score.ToString().PadLeft(8, '0');
            scoreTextObject.text = scoreText;
            //newScoreText = score.ToString();
            //scoreText = scoreText.Insert(scoreText.Length - newScoreText.Length, newScoreText);
            //scoreTextObject.text = scoreText.Insert(scoreText.Length - newScoreText.Length-1, newScoreText).Remove(scoreTextSize);
            //for (int i = 0; i < scoreTextObject.text.Length; i++)
            //{
            //    StringBuilder sb = new StringBuilder(scoreText);
            //    sb[scoreTextObject.text.Length - i] = score.ToString()[i];
            //    scoreText = sb.ToString();
            //}
        }

    }
}
