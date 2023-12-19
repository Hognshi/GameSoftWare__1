using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 move;
    float sec = 0;
    int min = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isEnd)
        {
            return;
        }
        Timer();
    }

    void Timer()
    {
        sec += Time.deltaTime;
        transform.position += move * 0.1f;
        if (sec >= min)
        {
            Destroy(gameObject);
        }
    }
}
