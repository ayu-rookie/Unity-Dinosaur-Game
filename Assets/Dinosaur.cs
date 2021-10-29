using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //�p�G "this" �S�� Rigidbody2D�A
                                        //�� RequireComponent ���}���@�w�|�]�tRigidbody2D
public class Dinosaur : MonoBehaviour
{
    public float speed; //����k�t��
    public float up;    //����V�W���O
    public Rigidbody2D rigidDino; 
    bool isjumping;
    public float Max_HP;
    float HP;           //�ͩR��
    public GameObject HP_Bar;  //�o�O��UI����
    public GameObject PrefabFire; //���B�z���� �P�H�x

    public Animator AniDino;
    public SpriteRenderer SrDino; 

    int dir; // 1�k 2��
    
    // Start is called before the first frame update
    void Start()
    {
        HP = Max_HP;
        //rigidDino = this.gameObject.GetComponent<Rigidbody2D>();
        //�W�z�y�k�� "this" �@�w�|�� Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = false;

        HP_Bar.transform.localScale = new Vector3((HP / Max_HP), HP_Bar.transform.localScale.y, HP_Bar.transform.localScale.z);

        /* ���s���� */
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // -- ���k�઺�Ĥ@�ؼg�k 

            //if (SrDino.flipX == true)
            //{
            //    SrDino.flipX = false;
            //    dir = 1;   //���s���ۥk��ADino�V���U�ϼu
            //}

            // -- ���k�઺�ĤG�ؼg�k�A�t�X�P�_�l�u���

            transform.eulerAngles = new Vector3(0, 0, 0);
            dir = 1; 

            // --�H�U���U�������Ⲿ�ʪ���k

            rigidDino.AddForce(new Vector2(speed, 0), ForceMode2D.Force);

            //this.gameObject.transform.position += new Vector3(speed, 0, 0);
            //rigidDino.velocity = new Vector2(speed, 0);


            //�������A

            isWalking = true;
            AniDino.SetInteger("Status", 1);           
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //if (SrDino.flipX == false)
            //{
            //    SrDino.flipX = true;
            //    dir = 2;   //���s���ۥ���ADino�V�k�U�ϼu
            //}

            // ** eulerAngles ������½���V

            transform.eulerAngles = new Vector3(0, 180, 0);
            dir = 2; 

            rigidDino.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);

            //this.gameObject.transform.position -= new Vector3(speed, 0, 0);
            //rigidDino.velocity = new Vector2(-speed, 0);


            //�������A

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

        // -- �P�_���S���b�����A�������A(Status)�B�ʵe

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

        /* �o�g�P�H�x */
        if (Input.GetKeyDown(KeyCode.X))
        {   
            // --���űо�
            // Instantiate(PrefabFire, this.transform.position, Quaternion.identity);


            GameObject go = Instantiate(PrefabFire, this.transform.position, Quaternion.identity);
            var FireClass = go.GetComponent<Fire>();
            FireClass.SetInitDirection(transform.rotation); // �h�쮣�s�{�b��½���V (rotation)�A
                                                            // �M��ǵ� Fire.cs ���� SetInitDirection Fuction
    
        }

        

         
        // -- ���� Force �D�ʳt��
        if (rigidDino.velocity.x > speed)
        {
            rigidDino.velocity = new Vector2(speed, 0);
        }
        if (rigidDino.velocity.x < -speed)
        {
            rigidDino.velocity = new Vector2(-speed, 0);
        }
    }

    /* �I���ƥ� (���I�쪺) */
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
        isjumping = false; //�n�I��a�~�i�H�A��
    }

    
}
