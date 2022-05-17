using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;//ファイルを使うときに必要

public class CSVReader : MonoBehaviour
{
    private float[] _timing;
    private int[] _lineNum;
    private float[] _linelongNum;

    public string filePass;//どこのファイルを参照するかを選ぶ

    void Start()
    {
        _timing = new float[1024];
        _lineNum = new int[1024];
        _linelongNum = new float[1024];
        LoadCSV();
    }

    void LoadCSV()
    {
        //TextAsset csv = Resources.Load("CSV/sample") as TextAsset;CSVというファイル内にあるsampleというファイルを開く,Resourcesというフォルダを参照する
        TextAsset csv = Resources.Load(filePass) as TextAsset;//filepassという変数を使ってファイルの場所を開く
        Debug.Log(csv.text);//textが出るように
        StringReader reader = new StringReader(csv.text);//csvのテキストを読み込ませる

        int i = 0;
        while (reader.Peek() > -1)//読み込みできる文字がなくなるまで繰り返す
        {

            string line = reader.ReadLine();// ファイルを 1 行ずつ読み込む
            string[] values = line.Split(',');//,で分割
            for (int j = 0; j < values.Length; j++)
            {
                _timing[i] = float.Parse(values[0]);//文字列を数字に変換
                _lineNum[i] = int.Parse(values[1]);
                _linelongNum[i] = float.Parse(values[2]);
            }
            i++;
        }
    }
}
