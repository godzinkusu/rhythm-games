using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class longnotemiddlecontroller : MonoBehaviour
{
    public int linenum;
    private bool tap6 = false;

    private longNodeMove speed;

    private Image scoreslider;
    private Text scoretext;

    private KeyCode _detect;

    private AudioSource longnotemusic;

    private GameObject longstart;



    // Start is called before the first frame update
    void Start()
    {
        _detect = DetectKey.GetKeyCodeByLineNum(linenum);
        speed = this.transform.parent.gameObject.GetComponent<longNodeMove>();
        scoreslider = GameObject.Find("hp").GetComponent<Image>();
        scoretext = GameObject.Find("scoretext").GetComponent<Text>();
        longnotemusic = GameObject.Find("musiceffect(long)").GetComponent<AudioSource>();

        longstart = this.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (longstart.transform.GetChild(0).transform.position.z > -3.2f && longstart.transform.GetChild(0).transform.position.z < -2.3f)
        {
            Checklongnotes(_detect);
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "miss")
        {
            tap6 = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "miss")
        {
            tap6 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "miss")
        {
            tap6 = false;
        }
    }
    */


    void Checklongnotes(KeyCode key) 
    {
        if (Input.GetKeyDown(key))
        {
            longnotemusic.Play();
            longnotemusic.loop = true;
        }
        if (Input.GetKey(key))
        {            
            this.transform.position += new Vector3(0, 0, speed.speed * 5 * Time.deltaTime);
            this.transform.localScale -= new Vector3(0, 0, speed.speed * 10 * Time.deltaTime);
            Textcombo.score++;
            scoretext.text = "SCORE: " + Textcombo.score.ToString("D6");
            scoreslider.fillAmount += 0.000005f;

            if(this.transform.localScale.z <= 0.05f)
            {
                Destroy(GameObject.Find("tapeffect-long(Clone)"));
            }

        }

        if (Input.GetKeyUp(key))
        {
            Destroy(GameObject.Find("tapeffect-long(Clone)"));
            longnotemusic.loop = !longnotemusic.loop;
            longnotemusic.Stop();
            Destroy(this.gameObject);
        }
    }
}
