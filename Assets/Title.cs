using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // -- 新方法 Step1

// -- 跳轉頁面的使用方法

// 先 Create Empty 一個物件 (System)，
// 將這個 script (Title.cs) 丟到 System 裡面，
// 再把 System 丟到 button 的 On Click 調整到 GameStart Fuction

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        // -- 新方法 Step2
        SceneManager.LoadScene(0);

        // -- 舊方法
        //Application.LoadLevel(0);
    }
}
