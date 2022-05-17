using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DetectKey//静的なクラス、ゲームに乗っけなくても動く
{
    public static KeyCode GetKeyCodeByLineNum(int lineNum)//keycodeで割り当てられるものをそれぞれ書く
    {
        switch (lineNum)//caseによって、割り当てる
        {
                case 1:
                    return KeyCode.D;
                case 2:
                    return KeyCode.F;
                case 3:
                    return KeyCode.B;
                case 4:
                    return KeyCode.J;
                case 5:
                    return KeyCode.K;
                default:
                    return KeyCode.None;

        }
    }
}
