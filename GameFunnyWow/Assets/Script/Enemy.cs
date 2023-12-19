using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject pr;
    public int hp;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isEnd)
        {
            return;
        }
        pr = GameObject.Find("Player");
        gameObject.transform.position += (pr.transform.position - gameObject.transform.position) * Time.deltaTime;

        if (hp < 0)
        {
            GameManager.instance.CatchedEnemy++;
            Destroy(gameObject);
        }
    }

    public void BeAttack()
    {
        hp--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            BeAttack();
        }
        else if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.GameOver();
        }
    }
}
