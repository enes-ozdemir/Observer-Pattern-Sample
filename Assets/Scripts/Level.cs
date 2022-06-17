using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private int remainingExp = 100;
    [SerializeField] private int currentExp = 0;

    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI remainingExpText;
    [SerializeField] private TextMeshProUGUI currentExpText;

    [SerializeField] private UnityEvent onLevelUp;

    private void Start()
    {
        StartCoroutine(GainExp());
    }

    private void Update()
    {
        levelText.text = $"Level : {level} ";
        remainingExpText.text = $"RemainingExp : {remainingExp} ";
        currentExpText.text = $"CurrentExp : {currentExp} ";

        if (currentExp > remainingExp)
        {
            onLevelUp.Invoke();
            level++;
            remainingExp *= 2;
            currentExp = 0;
        }
    }

    IEnumerator GainExp()
    {
        while (true)
        {
            yield return new WaitForSeconds(.2f);
            GainExperience(10);
        }
    }

    private void GainExperience(int exp)
    {
        currentExp += exp;
    }

    public int GetExperience()
    {
        return remainingExp;
    }

    public int GetLevel()
    {
        return level;
    }
}