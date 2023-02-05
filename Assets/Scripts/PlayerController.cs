using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum eState
    {
        Idle = 0,
        Left,
        Right
    }
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public GameObject boomPrefab;
    public Animator anim;
    public Gun gun;
    private eState state;

    public float speed = 1f;

    public System.Action onDie;


    public void Init(Gun gun)
    {
        this.gun = gun;
        this.gun.gameObject.transform.SetParent(this.transform);
        this.gun.transform.localPosition = Vector3.zero;
    }

    private void Start()
    {
        this.anim = this.GetComponent<Animator>();
        this.state = eState.Idle;
    }


    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        this.transform.Translate(dir.normalized * this.speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.anim.SetInteger("State", 1);
            this.state = eState.Left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.anim.SetInteger("State", 2);
            this.state = eState.Right;
        }

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            this.anim.SetInteger("State", 0);
            this.state = eState.Idle;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Shoot();
        }
    }

    private void Shoot()
    {
        this.gun.Shoot();
        //GameObject bulletGo = Instantiate(this.bulletPrefab);
        //bulletGo.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.9f, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            this.onDie();

            var fx = Instantiate(this.explosionPrefab);
            fx.transform.position = this.transform.position;

            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Boom")
        {
            Boom boom = other.gameObject.GetComponent<Boom>();

            GameObject effectGo = Instantiate(boomPrefab);
            effectGo.transform.position = this.transform.position;

            
            Destroy(other.gameObject);
            
            
        }
    }

    public void AttachGun(Gun gun)
    {
        this.gun = gun;
        this.gun.transform.SetParent(this.transform);
        this.gun.transform.localPosition = Vector3.zero;
    }

    public void DettachGun()
    {
        //자식으로 붙은 Gun게임 오브젝트를 제거 
        Destroy(this.gun.gameObject);
        Debug.LogFormat("gun: {0}", this.gun);
        this.gun = null;
    }


}
