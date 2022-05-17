using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[AddComponentMenu("subUI/scripts/taptokeycodechange")]

public class taptokeycodechange : MonoBehaviour
{
    
    //EventTriggerをアタッチしておく
    public EventTrigger _EventTrigger;

    //StopCoroutineのためにCoroutineで宣言しておく
    Coroutine PressCorutine;
    bool isPressDown = false;
    float PressTime = 0.2f;

    //設定するコンポーネントの変数.イベント名.AddListener(() => { 関数名; });

    void Awake()
    {
        //PointerDownイベントの登録
        EventTrigger.Entry pressdown = new EventTrigger.Entry();
        pressdown.eventID = EventTriggerType.PointerDown;//クリックしたとき
        pressdown.callback.AddListener((data) => PointerDown());//Addlistenerでこの後よびだす関数の設定Addlister(()=>Debug.Lon("");));
        _EventTrigger.triggers.Add(pressdown);//callbackの変数がdata


        //PointerUpイベントの登録
        EventTrigger.Entry pressup = new EventTrigger.Entry();
        pressup.eventID = EventTriggerType.PointerUp;
        pressup.callback.AddListener((data) => PointerUp());
        _EventTrigger.triggers.Add(pressup);
    }

    //EventTriggerのPointerDownイベントに登録する処理
    void PointerDown()
    {
        Debug.Log("Press Start");
        //連続でタップした時に長押しにならないよう前のCoroutineを止める
        if (PressCorutine != null)
        {
            StopCoroutine(PressCorutine);
        }
        //StopCoroutineで止められるように予め宣言したCoroutineに代入
        PressCorutine = StartCoroutine(TimeForPointerDown());
    }

    //長押しコルーチン
    IEnumerator TimeForPointerDown()
    {
        //プレス開始
        isPressDown = true;

        //待機時間
        yield return new WaitForSeconds(PressTime);

        //押されたままなら長押しの挙動
        if (isPressDown)
        {
            Debug.Log("Long Press Done");

            //お好みの長押し時の挙動をここに書く
        }

    }

    //EventTriggerのPointerUpイベントに登録する処理
    void PointerUp()
    {
        isPressDown = false;//プレス処理終了
        Debug.Log("Press End");
    }
}
