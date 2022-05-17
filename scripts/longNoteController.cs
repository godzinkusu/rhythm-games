using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longNoteController : MonoBehaviour
{
    public int linenum;

    private NodeController _nodecontroller;

    private longNodeMove speed;

    private bool tap1 = false;//tap1=perfect
    private bool tap2 = false;//tap2=great
    private bool tap3 = false;//tap3=good
    private bool tap4 = false;//tap4=bad
    private bool tap5 = false;//tap5=miss

    private bool tap6 = false;//longnoteの時//start部分が停止

    private Textcombo timingtext;//textcomboのソース
    private int taptext = -1;

    public GameObject longparticle;
    public GameObject particletap;

    private KeyCode _detect;

    private Vector3 pos;//longnotesの

    private longNodeMove _longNodeMove;


    // Start is called before the first frame update
    void Start()
    {
        pos.z = -2.9f;
        pos.x = this.transform.position.x;
        pos.y = this.transform.position.y;
        _detect = DetectKey.GetKeyCodeByLineNum(linenum);
        timingtext = GameObject.Find("Main Camera").GetComponent<Textcombo>();
        speed = this.transform.parent.gameObject.GetComponent<longNodeMove>();

    }

    // Update is called once per frame
    void Update()
    {
        if (tap1 || tap2 || tap3 || tap4 || tap5 ||tap6)
        {
            Checkdetermine(_detect);
        }

        if(transform.position.z < -7f)
        {
            timingtext.TimingFunc(-1);
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)//どちらかにrigidbodyを付け、どちらかにistriggerにチェックを入れる
    {

        if (other.gameObject.tag == "miss")//missエリアに入ってから
        {
            tap5 = true;
            tap4 = false;
            tap3 = false;
            tap2 = false;
            tap1 = false;

            taptext = -1;//missと表示

        }

        if (other.gameObject.tag == "bad")//badエリアに入ってから
        {
            tap5 = false;
            tap4 = true;
            tap3 = false;
            tap2 = false;
            tap1 = false;

            taptext = 0;//badと表示
        }

        if (other.gameObject.tag == "good")//goodエリアに入ってから
        {
            tap5 = false;
            tap4 = false;
            tap3 = true;
            tap2 = false;
            tap1 = false;

            taptext = 1;//goodと表示

        }

        if (other.gameObject.tag == "great")//greatに入ってから
        {
            tap5 = false;
            tap4 = false;
            tap3 = false;
            tap2 = true;
            tap1 = false;

            taptext = 2;//greatと表示

        }

        if (other.gameObject.tag == "perfect")//perfectに入ってから
        {
            tap5 = false;
            tap4 = false;
            tap3 = false;
            tap2 = false;
            tap1 = true;

            taptext = 3;//perfectと表示

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "miss")//missエリアを出たら
        {
            tap5 = false;
            tap4 = false;
            tap3 = false;
            tap2 = false;
            tap1 = false;

            tap6 = false;

            taptext = -1;//missと表示
        }

        if (other.gameObject.tag == "bad")//badエリアを出たら
        {
            tap5 = true;
            tap4 = false;
            tap3 = false;
            tap2 = false;
            tap1 = false;

            taptext = -1;//missと表示
        }

        if (other.gameObject.tag == "good")//goodエリアを出たら
        {
            tap5 = false;
            tap4 = true;
            tap3 = false;
            tap2 = false;
            tap1 = false;

            taptext = 0;//badと表示

        }

        if (other.gameObject.tag == "great")//greatエリアを出たら
        {
            tap5 = false;
            tap4 = false;
            tap3 = true;
            tap2 = false;
            tap1 = false;

            taptext = 1;//goodと表示

        }

        if (other.gameObject.tag == "perfect")//perfectエリアを出たら
        {
            tap5 = false;
            tap4 = false;
            tap3 = false;
            tap2 = true;
            tap1 = false;

            taptext = 2;//greatと表示

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "miss")
        {
            tap6 = true;
        }
    }

    void Checkdetermine(KeyCode key)//longnotestartとlongnoteend
    {
        if (Input.GetKeyDown(key) && this.gameObject.tag == "longnotestart")
        {           
            timingtext.TimingFunc(taptext);
            GameObject tapeffectshort = Instantiate(particletap, this.transform.position = new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            GameObject tapeffect = Instantiate(longparticle, this.transform.position = new Vector3(pos.x,pos.y,pos.z), Quaternion.identity);
            Destroy(tapeffectshort, 0.2f);
        }

        if(Input.GetKey(key)&&this.gameObject.tag == "longnotestart")
        {
            this.transform.position -= new Vector3(0, 0, speed.speed * -10 * Time.deltaTime);
        }

        if (Input.GetKeyUp(key) && this.gameObject.tag == "longnotestart")
        {            
            Destroy(this.gameObject);
        }
    }
}
