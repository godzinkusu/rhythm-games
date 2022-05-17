using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taptiming : MonoBehaviour
{
    public int lineNum;//ラインの変数
    private KeyCode _detect;//関数を変数にすべて保管

    public GameObject particletap2;

    private bool tap1 = false;//tap1=perfect
    private bool tap2 = false;//tap2=great
    private bool tap3 = false;//tap3=good
    private bool tap4 = false;//tap4=bad
    private bool tap5 = false;//tap5=miss

    private Vector3 pos;//singlenotesの

    private Textcombo timingtext;//textcomboのソース
    private int taptext = -1;

    // Start is called before the first frame update
    void Start()
    {
        pos.z = -2.9f;
        pos.x = this.transform.position.x;
        pos.y = this.transform.position.y;
        _detect = DetectKey.GetKeyCodeByLineNum(lineNum);//NOTEを5つ作ります、それでNOTE0の時、lineNum変数を0にしますすると、detectKeyでそれぞれの値に対応してkeyを変える
        timingtext = GameObject.Find("Main Camera").GetComponent<Textcombo>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z < -7.0f)
        {
            timingtext.TimingFunc(-1);
            Destroy(this.gameObject);
        }

        if (tap1 || tap2 || tap3 || tap4 || tap5)
        {
            Checkdetermine(_detect);
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

    void Checkdetermine(KeyCode key)
    {
        if (Input.GetKeyDown(key) && (this.gameObject.tag =="note" || this.gameObject.tag == "longnoteend"))
        {
            if(this.gameObject.tag == "note")
            {
                Destroy(this.gameObject);
            }

            if (this.gameObject.tag == "longnoteend")
            {
                Destroy(this.transform.parent.gameObject);
            }

            timingtext.TimingFunc(taptext);
            GameObject tapeffect = Instantiate(particletap2, this.transform.position =new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            Destroy(tapeffect, 0.2f);

        }

        if(Input.GetKeyUp(key) && this.gameObject.tag == "longnoteend")
        {
            Destroy(GameObject.Find("tapeffect-long(Clone)"));
            timingtext.TimingFunc(taptext);
            GameObject tapeffect = Instantiate(particletap2, this.transform.position = new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            Destroy(tapeffect, 0.2f);
            Destroy(this.transform.parent.gameObject);
        }
    }

}
