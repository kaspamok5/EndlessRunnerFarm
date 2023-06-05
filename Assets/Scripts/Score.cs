using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().startedRunning)
        {
            score++;
            scoreText.text = score.ToString();
        }

    }
}
