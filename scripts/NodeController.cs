using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;//ファイル処理

public class NodeController : MonoBehaviour
{
    public GameObject[] notes;//singlenotes
    public GameObject[] longnotes;//longnotes

    private float[] _timing;
    private int[] _lineNum;
    public float[] _linelongNum;

    public GameObject panel;//nowloading用
    public Text nowloading;

    public GameObject firework;

    public GameObject[] redareas;//startの位置を指定

    private int _notesCount = 0;

    private float timeOffset = -1.5f;//ずれ

    private float count = 0f;

    private float finish = 0f;

    private int d = 0;

    private AsyncOperation async;//nowloading用

    private string music;//どのCSVか

    private string BGMname;//どの楽曲か

    public GameObject GameUI;
    public GameObject STARTUI;   

    public AudioSource BGM;//audiosourceを管理


    void Start()
    {
        //根幹はmusiccallpattarnというスクリプトに記載
        music = musicallpattarn.AllCSV(levelchoice.levelwhich(), choisetoplayarea.musicselect());//左から難易度の値、どの楽曲か,levelchoiceというスクリプトに記載、choisetoplayareaというスクリプトに記載

        BGMname = BGMcollect.AllBGM(choisetoplayarea.musicselect());//choisetoplayareaの数値に対応

        BGM.clip = Resources.Load(BGMname) as AudioClip;//audiosourceをどれにするか管理する

        _timing = new float[1024];//タイミングの時間を入れる箱
        _lineNum = new int[1024];//どの場所に送るか
        _linelongNum = new float[1024];//longnoteの時の長さ
        /*
        // 変数audioSourceは有効なAudioSourceコンポーネントを参照していること
           audioSource.PlayOneShot( Resources.Load("Oto" ,typeof(AudioClip) ) as AudioClip );
         */

        //Time.timeScale = 0.5f;//ゆっくり観察

        LoadCSV();
    }
    

    void LoadCSV()
    {
        //TextAsset csv = Resources.Load("CSV/sample") as TextAsset;CSVというファイル内にあるsampleというファイルを開く,Resourcesというフォルダを参照する
        TextAsset csv = Resources.Load(music) as TextAsset;//musicfilenameという変数を使ってファイルの場所を開く
        StringReader reader = new StringReader(csv.text);//csvのテキストを読み込ませる


        int i = 0;
        while (reader.Peek() > -1)//読み込みできる文字がなくなるまで繰り返す
        {

            string line = reader.ReadLine();// ファイルを 1 行ずつ読み込む
            string[] values = line.Split(',');//,で分割
            //for (int j = 0; j < values.Length; j++)//読み込んだ行の大きさまで読み込む
            //{
                _timing[i] = float.Parse(values[0]);//文字列を数字に変換
                _lineNum[i] = int.Parse(values[1]);
                _linelongNum[i] = float.Parse(values[2]);
            // }


            _timing[i] = _timing[i] * (60 / choisetoplayarea.BPMselect());//BPMに合わせて変換

            i++;
        }

        
    }


    void FixedUpdate()
    {
        if (d == 0)
        {
            StartCoroutine(START());
        }

        else
        {
            count += Time.deltaTime;

            while (_timing[_notesCount] + timeOffset < GetMusicTime() && _timing[_notesCount] != 0)//読み込んだtimingが終わるまでと、timingの大きさがGetMusicTimeよりも大きかったらまだ流れず、経ってから流れ出す
            {
                SpawnNotes(_lineNum[_notesCount]);//どのラインに生成する
                _notesCount++;//次の番のため

            }

            if(BGM.isPlaying == false)
            {
                GameObject[] longnote = GameObject.FindGameObjectsWithTag("longnote");//longnoteはちゃんと消す
                foreach (GameObject long_note in longnote)
                {
                    Destroy(long_note);
                }
            }

            if (_timing[_notesCount] == 0 && GameObject.Find("longnote1(Clone)") == null && GameObject.Find("longnote2(Clone)") == null && GameObject.Find("longnote3(Clone)") == null && GameObject.Find("longnote4(Clone)") == null && GameObject.Find("longnote5(Clone)") == null && BGM.isPlaying == false)
            {
                finish += Time.deltaTime;
                if (finish >= 5 && finish <= 5.02f)
                {
                    Instantiate(firework, this.transform.position, Quaternion.identity);
                }

                if (finish >= 7)
                {
                    finish = -60;
                    StartCoroutine(changescene());
                }

            }
        }

    }

    void SpawnNotes(int num)//numどのラインか？
    {

        if(num <= 4)
        {
            Instantiate(notes[num], redareas[num].transform.position, Quaternion.Euler(-20, 0, 0));//ノーツをある位置に生み出す
        }

        if(num > 4)
        {
            
            GameObject longnote = Instantiate(longnotes[num - 5], redareas[num - 5].transform.position, Quaternion.identity);//ロングノーツをある位置に生み出す
            longnote.transform.GetChild(2).gameObject.transform.position += new Vector3(0, 0,_linelongNum[_notesCount]);
            longnote.transform.GetChild(1).gameObject.transform.localScale = new Vector3(1.3f, 0.001f, (longnote.transform.GetChild(2).gameObject.transform.position.z - longnote.transform.GetChild(0).transform.position.z));
            longnote.transform.GetChild(1).gameObject.transform.position = new Vector3(longnote.transform.position.x, longnote.transform.position.y, (longnote.transform.GetChild(0).transform.position.z + longnote.transform.GetChild(2).gameObject.transform.position.z) / 2);
        }

    }

    float GetMusicTime()
    {
        return count - choisetoplayarea.waittimeselect();//waittimeに合わせて時間変化
    }

    public IEnumerator changescene()
    {
        panel.SetActive(true);

        async = SceneManager.LoadSceneAsync("Scoreresult");

        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
        {
            nowloading.text = "LOADING..." + (async.progress) * 100 + "％";
            yield return null;
        }

        nowloading.text = "LOADING..." + 100 + "％";

        yield return new WaitForSeconds(1);

        async.allowSceneActivation = true;


    }

    private IEnumerator START()
    {
        
        yield return new WaitForSeconds(4);

        GameUI.SetActive(false);
        STARTUI.SetActive(false);

        yield return new WaitForSeconds(0.2f);

        d = 1;

        BGM.Play();
    }
}
