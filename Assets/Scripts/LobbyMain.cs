using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyMain : MonoBehaviour
{
    public Button btnStart;

    private void Start()
    {
        this.btnStart.onClick.AddListener(() =>
        {
            AsyncOperation oper = SceneManager.LoadSceneAsync("Game");
            oper.completed += (obj) => {
                GameMain gameMain = GameObject.FindObjectOfType<GameMain>();
            };
        });
    }
}
