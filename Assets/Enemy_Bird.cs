using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bird : MonoBehaviour
{
    public GameObject HP_Bar; //這是用圖片做的
    public float Max_HP;
    float HP;
    // Start is called before the first frame update
    void Start()
    {
          HP = Max_HP;
    }

    // Update is called once per frame
    void Update()
    {
        HP_Bar.transform.localScale = new Vector3((HP / Max_HP), HP_Bar.transform.localScale.y, HP_Bar.transform.localScale.z);
        
    }

    /* 碰撞事件 (沒碰到的) */
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Fire")
        {
            HP -= 1;
            Destroy(other.gameObject);
        }
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
