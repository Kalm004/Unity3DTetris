using UnityEngine;
using System.Collections;

public static class GameManager {
    private static int lines = 0;
    public static int scenario_width = 8;

    public static Scenario scenario = new Scenario();

    public static ParticleSystem scoreUpEffect;

    public static int Lines
    {
        get
        {
            return lines;
        }
        set
        {
            if (value > lines)
            {
                scoreUpEffect.Play();
            }
            lines = value;
        }
    }

    public static void RestartGame()
    {
        lines = 0;
        scenario = new Scenario();
    }

    public static float GetMovementDelay()
    {
        if(lines < 10)
        {
            return 0.4f;
        } else if (lines < 30)
        {
            return 0.35f;
        } else {
            return 0.15f;
        }
    }
}
