using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyMain : MonoBehaviour
{
    public Button btnStart;
    public Button btnGun1;
    public Button btnGun2;
    public Text txtSelectedGun;

    private GameEnums.eGunType selectedGunType;

    public GameEnums.eGunType SelectedGunType
    {
        set
        {
            this.selectedGunType = value;
            this.txtSelectedGun.text = string.Format("{0} 총을 선택했습니다.", this.selectedGunType);
        }
    }

    private AsyncOperation oper;

    private void Start()
    {
        this.SelectedGunType = GameEnums.eGunType.기본;

        this.btnStart.onClick.AddListener(() =>
        {
            Debug.Log(this.selectedGunType);
            this.oper = SceneManager.LoadSceneAsync("Game");
            oper.completed += (obj) => {
                GameMain gameMain = GameObject.FindObjectOfType<GameMain>();
                gameMain.Init(this.selectedGunType);
            };
        });

        this.btnGun1.onClick.AddListener(() =>
        {
            Debug.Log("기본 건");
            this.SelectedGunType = GameEnums.eGunType.기본;
        });
        this.btnGun2.onClick.AddListener(() =>
        {
            Debug.Log("멀티 건");
            this.SelectedGunType = GameEnums.eGunType.멀티;
        });
    }
}
