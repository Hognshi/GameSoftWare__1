using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public SpriteRenderer sprite;
    public int speed = 5;
    public Camera camera;
    public GameObject weapon;

    Transform prPos;
    float x, y;
    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        prPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isEnd)
        {
            return;
        }
        Movement();
        Attack();
    }

    private void Movement()
    {
        x = Input.GetAxis("Horizontal"); // 가로
        y = Input.GetAxis("Vertical"); // 가로

        if (x > 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        prPos.transform.position += new Vector3(x, y, 0) * Time.deltaTime * speed;
    }

    private void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            mousePos = camera.ScreenToWorldPoint(mousePos);
            GameObject bullet = Instantiate(weapon, gameObject.transform );
            bullet.tag = "Bullet";
            bullet.GetComponent<Bullet>().move = (mousePos - gameObject.transform.position).normalized;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Player" && collision.gameObject.tag == "Wall")
        {
            GameManager.instance.GameOver();
        }
    }
}
