using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSurvCan : MonoBehaviour
{
    [SerializeField] Slider hungerSlider;
    [SerializeField] Slider pleasureSlider;
    [SerializeField] Slider knowledgeSlider;
    void Start()
    {
        
    }

    void Update()
    {
        hungerSlider.value = Survival.Instance.CurrentHunger;
        pleasureSlider.value = Survival.Instance.CurrentPleasure;
        knowledgeSlider.value = Survival.Instance.CurrentKnowledge;
    }
}
