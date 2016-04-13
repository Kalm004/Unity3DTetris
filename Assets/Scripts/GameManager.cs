using UnityEngine;
using System.Collections;

public static class GameManager {
    private static int lines = 0;
    public static int scenario_width = 8;

    public static Scenario scenario = new Scenario();

    public static ParticleSystem scoreUpEffect;

    private static bool deletingLines = false;

    public static bool DeletingLines
    {
        get
        {
            return deletingLines;
        }
        set
        {
            if (deletingLines && !value)
            {
                scenario.DeleteLines(linesToDelete);
                scenario.MoveLines(linesToDelete);
            }
            deletingLines = value;
        }
    }

    public static float DeletingTime
    {
        get
        {
            return 1f;
        }
    }

    private static ArrayList linesToDelete;

    public static ArrayList LinesToDelete {
        get
        {
            return linesToDelete;
        }
        set
        {
            linesToDelete = value;
            if (linesToDelete.Count > 0)
            {
                deletingLines = true;
            }
        }
    }

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
