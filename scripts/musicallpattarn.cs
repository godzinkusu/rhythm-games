using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class musicallpattarn
{
    public static string musicname;
    public static string AllCSV(int levelmusic, int musicpattarn)//pattarnはどの楽曲か
    {
        if(levelmusic == 1)//levelは難易度
        {
            switch (musicpattarn)
            {
                case 1:
                    musicname = "CSV/spring_easy";
                    return musicname;

                case 2:
                    musicname = "CSV/Avalonica_easy";
                    return musicname;

                case 3:
                    musicname = "CSV/Blue Impulse_easy";
                    return musicname;

                case 4:
                    musicname = "CSV/The light of alpha_easy";
                    return musicname;

            }
        }

        if (levelmusic == 2)
        {
            switch (musicpattarn)
            {
                case 1:
                    musicname = "CSV/spring_normal";
                    return musicname;

                case 2:
                    musicname = "CSV/Avalonica_normal";
                    return musicname;

                case 3:
                    musicname = "CSV/Blue Impulse_normal";
                    return musicname;

                case 4:
                    musicname = "CSV/The light of alpha_normal";
                    return musicname;
            }
        }

        if (levelmusic == 3)
        {
            switch (musicpattarn)
            {
                case 1:
                    musicname = "CSV/spring_hard";
                    return musicname;

                case 2:
                    musicname = "CSV/Avalonica_hard";
                    return musicname;

                case 3:
                    musicname = "CSV/Blue Impulse_hard";
                    return musicname;

                case 4:
                    musicname = "CSV/The light of alpha_hard";
                    return musicname;
            }
        }

        return musicname;
    }
}
