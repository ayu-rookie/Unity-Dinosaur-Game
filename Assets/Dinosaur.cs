using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //如果 "this" 沒有 Rigidbody2D，
                                        //用 RequireComponent 讓腳本一定會包含Rigidbody2D
public class Dinosaur : MonoBehaviour
{
    public float speed; //控制左右速度
    public float up;    //控制向上的力
    public Rigidbody2D rigidDino; 
    bool isjumping;
    public float Max_HP;
    float HP;           //生命值
    public GameObject HP_Bar;  //這是用UI做的
    public GameObject PrefabFire; //欲處理物件 仙人掌

    public Animator AniDino;
    public SpriteRenderer SrDino; 

    int dir; // 1右 2左
    
    // Start is called before the first frame update
    void Start()
    {
        HP = Max_HP;
        //rigidDino = this.gameObject.GetComponent<Rigidbody2D>();
        //上述語法中 "this" 一定會有 Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = false;

        HP_Bar.transform.localScale = new Vector3((HP / Max_HP), HP_Bar.transform.localScale.y, HP_Bar.transform.localScale.z);

        /* 恐龍移動 */
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // -- 左右轉的第一種寫法 

            //if (SrDino.flipX == true)
            //{
            //    SrDino.flipX = false;
            //    dir = 1;   //恐龍面相右邊，Dino向左下反彈
            //}

            // -- 左右轉的第二種寫法，配合判斷子彈方位

            transform.eulerAngles = new Vector3(0, 0, 0);
            dir = 1; 

            // --以下為各種讓角色移動的方法

            rigidDino.AddForce(new Vector2(speed, 0), ForceMode2D.Force);

            //this.gameObject.transform.position += new Vector3(speed, 0, 0);
            //rigidDino.velocity = new Vector2(speed, 0);


            //走路狀態

            isWalking = true;
            AniDino.SetInteger("Status", 1);           
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //if (SrDino.flipX == false)
            //{
            //    SrDino.flipX = true;
            //    dir = 2;   //恐龍面相左邊，Dino向右下反彈
            //}

            // ** eulerAngles 讓物體翻轉方向

            transform.eulerAngles = new Vector3(0, 180, 0);
            dir = 2; 

            rigidDino.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);

            //this.gameObject.transform.position -= new Vector3(speed, 0, 0);
            //rigidDino.velocity = new Vector2(-speed, 0);


            //走路狀態

            isWalking = true;
            AniDino.SetInteger("Status", 1);        
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isjumping == false) 
        {
            rigidDino.AddForce(new Vector2(0, up),ForceMode2D.Impulse);

            //this.gameObject.transform.position += new Vector3(0, 3, 0);
            //rigidDino.velocity = new Vector2(0, up);

            isjumping =true;
        }

        // -- 判斷有沒有在走路，切換狀態(Status)、動畫

        if (isWalking)
        {
            if (AniDino.GetInteger("Status") == 0)
                AniDino.SetInteger("Status", 1);
        }
        else
        {
            if (AniDino.GetInteger("Status") == 1)
                AniDino.SetInteger("Status", 0);
        }

        /* 發射仙人掌 */
        if (Input.GetKeyDown(KeyCode.X))
        {   
            // --阿空教學
            // Instantiate(PrefabFire, this.transform.position, Quaternion.identity);


            GameObject go = Instantiate(PrefabFire, this.transform.position, Quaternion.identity);
            var FireClass = go.GetComponent<Fire>();
            FireClass.SetInitDirection(transform.rotation); // 去抓恐龍現在的翻轉方向 (rotation)，
                                                            // 然後傳給 Fire.cs 中的 SetInitDirection Fuction
    
        }

        

         
        // -- 限制 Force 慣性速度
        if (rigidDino.velocity.x > speed)
        {
            rigidDino.velocity = new Vector2(speed, 0);
        }
        if (rigidDino.velocity.x < -speed)
        {
            rigidDino.velocity = new Vector2(-speed, 0);
        }
    }

    /* 碰撞事件 (有碰到的) */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy_Bird")
        {
            if (dir == 1)
            { 
                this.gameObject.transform.position += new Vector3(-2, -2, 0);
                HP -= 1;
            }

            if (dir == 2)
            {
                this.gameObject.transform.position += new Vector3(2, -2, 0);
                HP -= 1;
            }

        }
        isjumping = false; //要碰到地才可以再跳
    }

    
}
