using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelchoice : MonoBehaviour
{
    public static int level = 1;//共有するレベル

    public Image easy;
    public Image normal;
    public Image hard;

    // Start is called before the first frame update
    void Start()
    {
        easy.fillAmount = 1;//長さを変える
        normal.fillAmount = 0.15f;
        hard.fillAmount = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            easy.fillAmount = 1;

            normal.fillAmount = 0.15f;
            hard.fillAmount = 0.15f;

            level = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            normal.fillAmount = 1;

            easy.fillAmount = 0.15f;
            hard.fillAmount = 0.15f;

            level = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            hard.fillAmount = 1;

            easy.fillAmount = 0.15f;
            normal.fillAmount = 0.15f;

            level = 3;
        }
    }

    public static int levelwhich()//levelを変える
    {
        return level;
    }
}
