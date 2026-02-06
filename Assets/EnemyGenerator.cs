using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using System;


public class EnemyGenerator : MonoBehaviour
{
    // Body Parts
    public GameObject head;
    public GameObject body;
    public GameObject leftArm;
    public GameObject rightArm;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject tail;

    // Special Traits
    public GameObject StrongArm;
    public GameObject FastLeg;
    public GameObject DragonWings;
    public GameObject WingsFeathers;
    public GameObject PixieWings;
    public GameObject SturdyTorso;

    // Materials
    public Material TonedMaterial;
    public Material DragonMaterial;
    public Material PixieMaterial;

    public string role = "None";
    public string chosenTrait = "None";
    public Color enemyColor = Color.white;

    void Start()
    {
        ApplyRoleScale(role);
        ApplyTrait(chosenTrait);
        ApplyColor(enemyColor);
    }

    public void SetRole(int index) { 
        if (index == 0) role = "Minion"; 
        if (index == 1) role = "Leader"; 
        if (index == 2) role = "Boss"; 
    }

    public void SetTrait(int index) { 
        if (index == 0) chosenTrait = "None"; 
        if (index == 1) chosenTrait = "StrongArm"; 
        if (index == 2) chosenTrait = "FastLeg"; 
        if (index == 3) chosenTrait = "Wings"; 
        if (index == 4) chosenTrait = "SturdyTorso"; 
    }

    public void SetColorFromKnob(float value) {
        enemyColor = Color.HSVToRGB(value, 1f, 1f);
    }

    string RandomPart(string one, string two, string three, float weightOne, float weightTwo, float weightThree) { 
        float roll = Random.Range(0f, 1f) * 100f; 
        if (roll <= weightOne) 
            return one; 
        else if (weightOne < roll && roll <= weightOne + weightTwo) 
            return two; 
        else 
            return three; 
    }


    void ApplyRoleScale(string role)
    {
        float scale;
        switch (role)
        {
            case "Minion":
                scale = Random.Range(40.0f, 60.0f);
                break;
            case "Leader":
                scale = Random.Range(80.0f, 120.0f);
                break;
            case "Boss":
                scale = Random.Range(140.0f, 160.0f);
                break;
            default:
                scale = Random.Range(50.0f, 150.0f);
                break;
        }
        SetScale(scale);
    }

    void SetScale(float scale) { 
        transform.localScale = new Vector3(scale, scale, scale); 
    }

    void ApplyTrait(string trait)
    {
        // Disable all traits first
        StrongArm.SetActive(false);
        FastLeg.SetActive(false);
        DragonWings.SetActive(false);
        WingsFeathers.SetActive(false);
        PixieWings.SetActive(false);
        SturdyTorso.SetActive(false);
        head.SetActive(true);
        body.SetActive(true);
        leftArm.SetActive(true);
        rightArm.SetActive(true);
        leftLeg.SetActive(true);
        rightLeg.SetActive(true);
        tail.SetActive(true);


        // Enable the chosen trait
        switch (trait)
        {
            case "StrongArm":
                StrongArm.SetActive(true);
                leftArm.SetActive(false);
                rightArm.SetActive(false);
                break;
            case "FastLeg":
                FastLeg.SetActive(true);
                leftLeg.SetActive(false);
                rightLeg.SetActive(false);
                break;
            case "Wings":
                if (role == "Minion") {
                    string wingType = RandomPart("DragonWings", "WingsFeathers", "PixieWings", 20f, 20f, 60f);
                    switch (wingType)
                    {
                        case "DragonWings":
                            DragonWings.SetActive(true);
                            break;
                        case "WingsFeathers":
                            WingsFeathers.SetActive(true);
                            break;
                        case "PixieWings":
                            PixieWings.SetActive(true);
                            break;
                    }
                } else if (role == "Leader") {
                    string wingType = RandomPart("DragonWings", "WingsFeathers", "PixieWings", 20f, 60f, 20f);
                    switch (wingType)
                    {
                        case "DragonWings":
                            DragonWings.SetActive(true);
                            break;
                        case "WingsFeathers":
                            WingsFeathers.SetActive(true);
                            break;
                        case "PixieWings":
                            PixieWings.SetActive(true);
                            break;
                    }
                } else { // Boss
                    string wingType = RandomPart("DragonWings", "WingsFeathers", "PixieWings", 60f, 20f, 20f);
                    switch (wingType)
                    {
                        case "DragonWings":
                            DragonWings.SetActive(true);
                            break;
                        case "WingsFeathers":
                            WingsFeathers.SetActive(true);
                            break;
                        case "PixieWings":
                            PixieWings.SetActive(true);
                            break;
                    }
                }
                break;
            case "SturdyTorso":
                SturdyTorso.SetActive(true);    
                body.SetActive(false);
                break;
            default:
                break;
        }
    }

   

    // Apply color to all parts
    void ApplyColor(Color color)
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            if(renderer.material == TonedMaterial){
                renderer.material.color = color;
            }
        }
    }

    public void GenerateEnemy() { 
        ApplyRoleScale(role); 
        ApplyTrait(chosenTrait); 
        ApplyColor(enemyColor); 
        Debug.Log("Eenemy Generated: " + role + " with trait " + chosenTrait);
    }
}