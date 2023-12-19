using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public Button StartBTN;
    public Button EndBTN;
    // Start is called before the first frame update
    void Start()
    {
        StartBTN.onClick.AddListener(OnStart);
        EndBTN.onClick.AddListener(OnEnd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnEnd()
    {
        //Á¾·á
    }
}
