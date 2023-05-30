using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    CardDealer cardDealer;

    public GameObject borderParticles;
    public GameObject UncommonParticle;
    public GameObject RareParticle;
    public GameObject EpicParticle;
    public GameObject LegendaryParticle;
    public GameObject RainbowParticle;
    public Material particleMaterial;

    public int aICardNumber;

    public void Update()
    {

        if(aICardNumber >= 1 && aICardNumber <=15)
        {
            Common();
        }

        if (aICardNumber >= 16 && aICardNumber <= 23)
        {
            Uncommon();
        }

        if (aICardNumber >= 24 && aICardNumber <= 27)
        {
            Rare();
        }

        if (aICardNumber == 28 || aICardNumber == 29)
        {
            Epic();
        }

        if (aICardNumber == 30 || aICardNumber == 31)
        {
            Legendary();
        }

        if (aICardNumber == 32)
        {
            Rainbow();
        }
    }


    public void Common()
    {
       
        borderParticles.SetActive(true);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(false);
        particleMaterial.color = Color.black;

    }

    public void Uncommon()
    {
        borderParticles.SetActive(true);
        UncommonParticle.SetActive(true);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(false);
        particleMaterial.color = Color.gray;
    }

    public void Rare()
    {
        borderParticles.SetActive(true);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(true);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(false);
        particleMaterial.color = Color.red;
    }

    public void Epic()
    {
        borderParticles.SetActive(true);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(true);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(false);
        particleMaterial.color = Color.green;
    }

    public void Legendary()
    {
        borderParticles.SetActive(true);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(true);
        RainbowParticle.SetActive(false);
        particleMaterial.color = Color.yellow;

    }

    public void Rainbow()
    {
        borderParticles.SetActive(false);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(true);
    }
 
}
