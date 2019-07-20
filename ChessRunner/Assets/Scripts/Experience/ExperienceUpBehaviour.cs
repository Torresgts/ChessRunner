using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceUpBehaviour : MonoBehaviour
{
    public Slider experienceSlider;
    public Text valueText;
    public Text UnlockableText;

    public ExperienceData experienceData;

    public ColorTypeListScriptableObject colorTypeList;

    private void OnEnable()
    {
        StartCoroutine(FillExperience());
    }

    private IEnumerator FillExperience()
    {
        int _actualExperience = experienceData.GetExperience();
        int _adquiredExperience = 15;
        int _maxExperience = GetMaxExperience();
        int _cachedExperience = _actualExperience;

        experienceSlider.maxValue = _maxExperience;

        
        valueText.text = string.Format("{0}/{1}", _cachedExperience, _maxExperience);
        experienceSlider.value = _cachedExperience;


        yield return new WaitForSeconds(1f);

        while(_cachedExperience < _actualExperience+_adquiredExperience && _cachedExperience < _maxExperience)
        {
            yield return new WaitForSeconds(0.1f);
            _cachedExperience++;
            valueText.text = string.Format("{0}/{1}", _cachedExperience, _maxExperience);
            experienceSlider.value = _cachedExperience;
        }

        experienceData.SetExperience(_cachedExperience);
        yield return new WaitForSeconds(0.2f);
        VerifyUnlockable();
    } 

    private void VerifyUnlockable()
    {
        if(experienceData.GetExperience() == GetMaxExperience())
        {
            experienceData.SetExperience(0);
            experienceData.SetLevel(experienceData.GetLevel()+1);

            UnlockableText.gameObject.SetActive(true);

            UnlockableText.text = string.Format("<color=red> Unlocked Color : </color> \n <b> {0} </b>", colorTypeList.colorTypes[experienceData.GetLevel()-1].colorName);

            
            valueText.text = string.Format("{0}/{1}", 0, GetMaxExperience());
            experienceSlider.value = 0;
        }
    }

    private void RefreshValues(int cached, int max)
    {
        valueText.text = string.Format("{0}/{1}", cached, max);
        experienceSlider.value = cached;
    }

    private int GetMaxExperience()
    {
        return experienceData.GetLevel()*2*experienceData.GetLevel();
    }
}
