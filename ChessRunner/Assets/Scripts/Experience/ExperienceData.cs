using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceData : MonoBehaviour
{

    private const string labelExperience = "Experience";
    private const string labelLevel = "Level";
    
    private int experience = 0;
    private int level = 1;

    public int GetExperience()
    {
        if(PlayerPrefs.HasKey(labelExperience))
        {
            this.experience = PlayerPrefs.GetInt(labelExperience);
        } else {
            PlayerPrefs.SetInt(labelExperience, 0);
        }

        return experience;
    }

    public int GetLevel()
    {
        if(PlayerPrefs.HasKey(labelLevel))
        {
            this.level = PlayerPrefs.GetInt(labelLevel);
        } else {
            PlayerPrefs.SetInt(labelLevel, 1);
        }

        return level;
    }

    public void SetExperience(int value)
    {
        PlayerPrefs.SetInt(labelExperience, value);
    }

    public void SetLevel(int value)
    {
        PlayerPrefs.SetInt(labelLevel, value);
    }


}
