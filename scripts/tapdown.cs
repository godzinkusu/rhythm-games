using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapdown : MonoBehaviour
{
    public int lineNum;//ラインの変数
    private KeyCode _detect;//関数を変数にすべて保管

    public GameObject particletap;

    private AudioSource eaudiosource;//音を鳴らす元
    public AudioClip tap;

    // Start is called before the first frame update
    void Start()
    {
        _detect = DetectKey.GetKeyCodeByLineNum(lineNum);
        eaudiosource = GameObject.Find("musiceffect").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckKey(_detect);
    }

    void CheckKey(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            eaudiosource.PlayOneShot(tap);
            GameObject i = Instantiate(particletap, this.transform.position, Quaternion.Euler(-90, 0, 0));
            this.transform.position -= new Vector3(0, 0.3f, 0);
            Destroy(i, 0.2f);
            
        }

        else if (Input.GetKeyUp(key))
        {           
            this.transform.position += new Vector3(0, 0.3f, 0);
        }

    }
}
