using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour
{
    public GameObject levelCompletePanel;
    public ParticleSystem levelCompleteParticle;
    public Text income;
    public Text matchRateText;
    public Slider slider;

    void Start()
    {
        levelCompletePanel.SetActive(false);
    }

    void Update()
    {
        slider.value = GameController.instance.successRate;
        matchRateText.text = ("Match Rate: %" + GameController.instance.successRate);
    }

    public void UpdateValues(int numberOfLayers)
    {
        if (numberOfLayers == 49)
        {
            var incomeAmount = GameController.instance.GetIncome();
            levelCompletePanel.SetActive(true);
            GameController.instance.IncrementNumberOfLayers();
            levelCompleteParticle.Play();
            UpdateIncomeTexts(incomeAmount);
        }
    } 
    
    private void UpdateIncomeTexts(int amount)
    {
        income.text = "$" + amount;
        TotalIncome.totalIncome += amount;
    }

    public void OnMouseButton()
    {
        SceneManager.LoadScene(1);
    }
}
