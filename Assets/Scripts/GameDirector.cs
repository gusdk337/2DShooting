using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text txtScore;
    private int score;
    private int life = 3;
    public PlayerController player;

    public GameObject[] lifes;

    private void Start()
    {
        this.player.onDie = () =>
        {
            this.life -= 1;

            for (int i = 0; i < lifes.Length; i++)
                this.lifes[i].gameObject.SetActive(false);
            for (int i = 0; i < life; i++)
                this.lifes[i].gameObject.SetActive(true);

            if (this.life <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        };
    }

    public void UpdateScore(int addScore)
    {
        this.score += addScore;
        this.txtScore.text = string.Format("{0}", this.score);
    }
}
