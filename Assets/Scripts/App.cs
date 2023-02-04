using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour
{
    public string version;

    private void Awake()
    {
        Object.DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync("Title");
        oper.completed += (obj) =>
        {
            TitleMain titleMain = GameObject.FindObjectOfType<TitleMain>();
            titleMain.Init(this.version);
        };
    }
}
