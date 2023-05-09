using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private GameObject playerCard;
    private GameObject rainbowCard;
    private GameObject borderPartcilces;
    private GameObject UncommonParticle;
    private GameObject RareParticle;
    private GameObject EpicParticle;
    private GameObject LegendaryParticle;
    private GameObject RainbowParticle;
    public Material particleMaterial;
    public Material cardMaterial;
    public string cardName;
    public int commonValue;
    public int uncommonValue;
    public int rareValue;
    public int epicValue;
    public int legendaryValue;
    public int rainbowValue;

    
    
    private void Start()
    {
        borderPartcilces = GameObject.Find("Border Particle Effect");
        UncommonParticle = GameObject.Find("Uncommon Particle");
        RareParticle = GameObject.Find("Rare Particle");
        EpicParticle = GameObject.Find("Epic Particle");
        LegendaryParticle = GameObject.Find("Legendary Particle");
        RainbowParticle = GameObject.Find("Rainbow Particle");
        playerCard = GameObject.Find("Player Card");
        rainbowCard = GameObject.Find("Rainbow Card");
    }


    public void Common()
    {
        borderPartcilces.SetActive(true);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(false);
        playerCard.SetActive(true);
        rainbowCard.SetActive(false);
        particleMaterial.color = Color.black;
        cardMaterial.color = Color.black;
    }

    public void Uncommon()
    {
        borderPartcilces.SetActive(true);
        UncommonParticle.SetActive(true);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(false);
        playerCard.SetActive(true);
        rainbowCard.SetActive(false);
        particleMaterial.color = Color.gray;
        cardMaterial.color = Color.gray;
    }

    public void Rare()
    {
        borderPartcilces.SetActive(true);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(true);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(false);
        playerCard.SetActive(true);
        rainbowCard.SetActive(false);
        particleMaterial.color = Color.red;
        cardMaterial.color = Color.red;
    }

    public void Epic()
    {
        borderPartcilces.SetActive(true);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(true);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(false);
        playerCard.SetActive(true);
        rainbowCard.SetActive(false);
        particleMaterial.color = Color.green;
        cardMaterial.color = Color.green;
    }

    public void Legendary()
    {
        borderPartcilces.SetActive(true);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(true);
        RainbowParticle.SetActive(false);
        playerCard.SetActive(true);
        rainbowCard.SetActive(false);
        particleMaterial.color = Color.yellow;
        cardMaterial.color = Color.yellow;
    }

    public void Rainbow()
    {
        borderPartcilces.SetActive(false);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(true);
        playerCard.SetActive(false);
        rainbowCard.SetActive(true);
    }
 
}
