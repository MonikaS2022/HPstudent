using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survival : MonoBehaviour
{
    // Did it like this because singletons are only supposed to be one instance so i did it without polymorphism.
    // I did it with the child classes but that did not work out properly.
    // I think for this project it is okey because we can use the singleton design pattern.


    // Different things to mange. Can be adjusted in the editor!
   

    // To call this singleton class from another script you just go Survival.Instance then what you want
    // For example Survival.Instance.CurrentKnowledge to ge the current knowledge!
    [Header("Hunger")]
    [SerializeField] protected float depletionRateHunger = 1f;
    [SerializeField] protected float currentHunger = 100;
    [SerializeField] protected float maxHunger = 100;

    [Header("Pleasure")]
    [SerializeField] protected float depletionRatePleasure = 1f;
    [SerializeField] protected float currentPleasure = 100;
    [SerializeField] protected float maxPleasure = 100;

    [Header("Knowledge")]
    [SerializeField] protected float depletionRateKnowledge = 1f;
    [SerializeField] protected float currentKnowledge = 100;
    [SerializeField] protected float maxKnowledge = 100;
    public static Survival Instance { get; private set; }

    public bool inMinigame = false;

    public bool inMinigame1 = false;
    public bool inMinigame2 = false;
    public bool inMinigame3 = false;

    public float CurrentPleasure
    {
        get { return currentPleasure; }
    }

    public float CurrentHunger
    {
        get { return currentHunger; }
    }
    public float CurrentKnowledge
    {
        get { return currentKnowledge; }
    }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Slowly ticking each down to zero and stopts when it gets to just below zero.

        if (currentPleasure > 0)
        {
            currentPleasure -= depletionRatePleasure * Time.deltaTime;
        }

        if (currentHunger > 0)
        {
            currentHunger -= depletionRateHunger * Time.deltaTime;
        }      
        
        if (currentKnowledge > 0)
        {
            currentKnowledge -= depletionRateKnowledge * Time.deltaTime;
        }
    }

    public void IncreaseHunger(float increase)
    {
        currentHunger += increase;

        if (currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
        }
    }

    public void IncreaseKnowledge(float increase)
    {
        currentKnowledge += increase;

        if (currentKnowledge > maxKnowledge)
        {
            currentKnowledge = maxKnowledge;
        }
    }

    public void IncreasePleasure(float increase)
    {
        currentPleasure += increase;

        if (currentPleasure > maxPleasure)
        {
            currentPleasure = maxPleasure;
        }
    }

}
