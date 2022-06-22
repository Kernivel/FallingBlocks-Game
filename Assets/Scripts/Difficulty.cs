using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    static float maxDifficultyTime = 30f;


    public static float GetDifficultyPercentage(){
        return Mathf.Clamp01(Time.time/maxDifficultyTime);
    }
}
