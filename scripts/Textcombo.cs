using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Textcombo : MonoBehaviour
{
    public TextMeshProUGUI  combo;
    public int count = 0;
    public Text scoretext;

    public static int maxcombo = 0;//共有するためのもの
    public static int perfect = 0;
    public static int great = 0;
    public static int good = 0;
    public static int bad = 0;
    public static int miss = 0;

    public Image slider;

    private float timer = 1f;

    public static int score = 0;//scoreを共有するためのもの

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        slider.fillAmount = 0;
        combo.GetComponent<TextMeshProUGUI>();
        scoretext.text = "SCORE: " + score.ToString("D6");

        maxcombo = 0;
        perfect = 0;
        great = 0;
        good = 0;
        bad = 0;
        miss = 0;
    }

    private void Awake()
    {
        combo.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(combo.color.a <1f)
        {
            combo.color = new Color(combo.color.r, combo.color.g, combo.color.b, timer);
        }

        if(maxcombo < count)
        {
            maxcombo = count;
        }
    }

    public void TimingFunc(int num)
    {
        switch (num)
        {
            case 3://perfect
                count++;
                combo.text = "<color=red>PERFECT!!</color>\nCOMBO    " + count;
                combo.fontSize = 50;
                timer = 1f;//これで文字の透明度を1にして見えるようにする
                score += 1000;
                slider.fillAmount += 0.005f;//1になったらmax
                scoretext.text = "SCORE: " + score.ToString("D6");
                perfect += 1;
                break;

            case 2://great
                count++;
                combo.text = "<color=yellow>GREAT!</color>\nCOMBO    " + count;
                combo.fontSize = 50;
                timer = 1f;
                score += 500;
                slider.fillAmount += 0.003f;
                scoretext.text = "SCORE: " + score.ToString("D6");
                great += 1;
                break;

            case 1://good
                count++;
                combo.text = "<color=green>GOOD</color>\nCOMBO    " + count;
                combo.fontSize = 50;
                timer = 1f;
                score += 300;
                slider.fillAmount += 0.001f;
                scoretext.text = "SCORE: " + score.ToString("D6");
                good += 1;
                break;

            case 0://bad
                count = 0;
                combo.text = "<color=blue>BAD</color>";
                combo.fontSize = 50;
                timer = 1f;
                score += 100;
                slider.fillAmount += 0.0005f;
                scoretext.text = "SCORE: " + score.ToString("D6");
                bad += 1;
                break;

            case -1://miss
                count= 0;
                combo.text = "\n<color=white>MISS</color>";
                combo.fontSize = 50;
                timer = 1f;
                miss += 1;
                break;
        }

    }

    //下からのものは共有するためのもの
    public static int scoreresult()
    {
        return score;
    }

    public static int maxcomboresult()
    {
        return maxcombo;
    }

    public static int perfectcombo()
    {
        return perfect;
    }

    public static int greatcombo()
    {
        return great;
    }

    public static int goodcombo()
    {
        return good;
    }

    public static int badcombo()
    {
        return bad;
    }

    public static int misscombo()
    {
        return miss;
    }
    
}
