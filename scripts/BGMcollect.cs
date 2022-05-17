using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BGMcollect
{
    public static string BGMname;

    public static string AllBGM(int musicpattarn)
    {
        switch (musicpattarn)
        {
            case 1:
                BGMname = "BGM/springmusic";
                return BGMname;

            case 2:
                BGMname = "BGM/Avalonica";
                return BGMname;

            case 3:
                BGMname = "BGM/Blue Impulse";
                return BGMname;

            case 4:
                BGMname = "BGM/The light of alpha";
                return BGMname;

        }

        return BGMname;
    }
    
}
