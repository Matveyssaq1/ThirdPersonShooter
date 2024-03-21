using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public List<PlayerProgressLevel> levels;
    public RectTransform expirienceValueRectTransform;
    public TextMeshProUGUI levelValueTMP;

    private int _levelValue = 1;
    private float _expirienceCurrentValue = 0;
    private float _expirienceTargetValue = 100;
    
    public void Start()
    {
        SetLevelValue(_levelValue);
        DrawUI();
    }

    public void AddExperience(float value)
    {
        _expirienceCurrentValue += value;
        if(_expirienceCurrentValue >= _expirienceTargetValue)
        {
            SetLevelValue(_levelValue + 1);
            _expirienceCurrentValue = 0;
        }
        DrawUI();
    }
    public void SetLevelValue(int value)
    {
        _levelValue = value;
        var currentLevel = levels[_levelValue - 1];
        _expirienceTargetValue = currentLevel.expirienceForTheNextLevel;
        GetComponent<FireballCaster>().damage = currentLevel.fireballDamage;
        var grenadeCaster = GetComponent<GrenadeCaster>();
        grenadeCaster.damage = currentLevel.grenadeDamage;
        if (currentLevel.grenadeDamage < 0)
            grenadeCaster.enabled = false;
        else
            grenadeCaster.enabled = true;
        

        
    }
    
    
    public void DrawUI()
    {
        expirienceValueRectTransform.anchorMax = new Vector2(_expirienceCurrentValue / _expirienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }
}
