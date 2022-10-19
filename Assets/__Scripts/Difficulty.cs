using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Difficulty : MonoBehaviour
{
    private int levelIndex;

    public void getDifficultyLevel()
    {
        string levelName = EventSystem.current.currentSelectedGameObject.name;
        if (levelName.Equals("Easy"))
        {
            levelIndex = 0;
        } else if (levelName.Equals("Medium"))
        {
            levelIndex = 1;
        } else if (levelName.Equals("Hard"))
        {
            levelIndex = 2;
        }
        Main.diffLevel = levelIndex;
    }
}
