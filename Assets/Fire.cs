using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float timer;
    int dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Quaternion m_TargetInitRotation;
    public void SetInitDirection(Quaternion rotate) 
    {
        m_TargetInitRotation = rotate; // Dinosaur.cs �Ƕi�Ӫ����s½����
    }

    // Update is called once per frame
    void Update()
    {

        // --���űо�
        //this.gameObject.transform.position += new Vector3(0.5f * Time.deltaTime * 50, 0, 0);

        //timer -= Time.deltaTime;  //��s�v

        //if (timer < 0)
        //{
        //    Destroy(this.gameObject);
        //}

        if (m_TargetInitRotation.y < 180 && m_TargetInitRotation.y != 0) //���s���V���� rotation (0,-180,0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            this.gameObject.transform.position -= new Vector3(0.5f * Time.deltaTime * 40, 0, 0);  //�P�H�x�����g
        }
        else
        {
            this.gameObject.transform.position += new Vector3(0.5f * Time.deltaTime * 40, 0, 0);  //�P�H�x���k�g
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
