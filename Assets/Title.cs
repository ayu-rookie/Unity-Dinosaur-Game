using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // -- �s��k Step1

// -- ���୶�����ϥΤ�k

// �� Create Empty �@�Ӫ��� (System)�A
// �N�o�� script (Title.cs) ��� System �̭��A
// �A�� System ��� button �� On Click �վ�� GameStart Fuction

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
        // -- �s��k Step2
        SceneManager.LoadScene(0);

        // -- �¤�k
        //Application.LoadLevel(0);
    }
}
