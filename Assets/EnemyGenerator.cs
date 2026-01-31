using UnityEngine;
using TMPro;

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
    public GameObject Wings;
    public GameObject SturdyTorso;

    // Secondary Trait Variants (if any)
    public GameObject StrongArmSecondary;
    public GameObject FastLegSecondary;
    public GameObject WingsSecondary;
    public GameObject SturdyTorsoSecondary;

    // Materials
    public Material TonedMaterial;

    public string role = "None";
    public string chosenTrait = "None";
    public string secondaryTrait = "None";
    public Color enemyColor = Color.white;

    void Start()
    {
        ApplyRoleScale(role);
        ApplyTrait(chosenTrait);
        ApplySecondaryTrait(secondaryTrait);
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

    public void SetSecondaryTrait(int index) { 
        if (index == 0) secondaryTrait = "None"; 
        if (index == 1) secondaryTrait = "StrongArm"; 
        if (index == 2) secondaryTrait = "FastLeg"; 
        if (index == 3) secondaryTrait = "Wings"; 
        if (index == 4) secondaryTrait = "SturdyTorso"; 
    }

    public void SetColorFromKnob(float value) {
        enemyColor = Color.HSVToRGB(value, 1f, 1f);
        GenerateEnemy();
    }

    void ApplyRoleScale(string role)
    {
        float scale = 50.0f;
        switch (role)
        {
            case "Minion":
                scale = 50.0f;
                break;
            case "Leader":
                scale = 100.0f;
                break;
            case "Boss":
                scale = 150.0f;
                break;
            default:
                scale = 50.0f;
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
        Wings.SetActive(false);
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
                Wings.SetActive(true);
                break;
            case "SturdyTorso":
                SturdyTorso.SetActive(true);    
                body.SetActive(false);
                break;
            default:
                break;
        }
    }

    void ApplySecondaryTrait(string trait)
    {
        // Disable all secondary traits first
        StrongArmSecondary.SetActive(false);
        FastLegSecondary.SetActive(false);
        WingsSecondary.SetActive(false);
        SturdyTorsoSecondary.SetActive(false);

        // Enable the chosen secondary trait
        switch (trait)
        {
            case "StrongArm":
                StrongArmSecondary.SetActive(true);
                leftArm.SetActive(false);
                rightArm.SetActive(false);
                break;
            case "FastLeg":
                FastLegSecondary.SetActive(true);
                leftLeg.SetActive(false);
                rightLeg.SetActive(false);
                break;
            case "Wings":
                WingsSecondary.SetActive(true);
                break;
            case "SturdyTorso":
                SturdyTorsoSecondary.SetActive(true);  
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
            renderer.material.color = color;
        }
    }

    public void GenerateEnemy() { 
        ApplyRoleScale(role); 
        ApplyTrait(chosenTrait); 
        ApplySecondaryTrait(secondaryTrait);
        ApplyColor(enemyColor); 
    }
}