using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KiraGameManager : MonoBehaviour
{
    public KiraCharacterCustomization kiracustom;
    public GameObject kiraPrefab;

    int loadScene = 0;
    private void Awake()
    {

    }
    private void Start()
    {
        HideExcessPart();
        Initialize();
    }

    private void LoadNextScene()
    {
        StartCoroutine(GoNextScene());
    }
    IEnumerator GoNextScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadScene + 1);
        while (!asyncLoad.isDone) { yield return null; }
    }
    private void Initialize()
    {

        if (kiraPrefab.activeInHierarchy)
        {
            Button kiraHairNextBTN = kiracustom.kiraHairTypes.nextBTN;
            kiraHairNextBTN.onClick.AddListener(NextHair);
            kiraHairNextBTN.onClick.AddListener(kiracustom.kiraHairTypes.HairIncrement);

            Button kiraHairPreviousBTN = kiracustom.kiraHairTypes.prevBTN;
            kiraHairPreviousBTN.onClick.AddListener(PreviousHair);
            kiraHairPreviousBTN.onClick.AddListener(kiracustom.kiraHairTypes.HairDecrement);

            Button kiraClothesNextBTN = kiracustom.kiraClotheTypes.nextBTN;
            kiraClothesNextBTN.onClick.AddListener(NextClothe);
            kiraClothesNextBTN.onClick.AddListener(kiracustom.kiraClotheTypes.ClotheIncrement);

            Button kiraClothesPreviousBTN = kiracustom.kiraClotheTypes.prevBTN;
            kiraClothesPreviousBTN.onClick.AddListener(PreviousClothe);
            kiraClothesPreviousBTN.onClick.AddListener(kiracustom.kiraClotheTypes.ClotheDecrement);

            Button kiraPantNextBTN = kiracustom.kiraPantTypes.nextBTN;
            kiraPantNextBTN.onClick.AddListener(NextPant);
            kiraPantNextBTN.onClick.AddListener(kiracustom.kiraPantTypes.PantIncrement); ;

            Button kiraPantPreviousBTN = kiracustom.kiraPantTypes.prevBTN;
            kiraPantPreviousBTN.onClick.AddListener(PreviousPant);
            kiraPantPreviousBTN.onClick.AddListener(kiracustom.kiraPantTypes.PantDecrement); ;
        }
    }
    public void ResetHidden()
    {
        foreach (Transform child in kiraPrefab.transform) { child.gameObject.SetActive(true); }
    }

    public void HideExcessPart()
    {
        int kiraHairPartsLength = kiracustom.kiraHairTypes.hairParts.Length;
        int kiraClothePartsLength = kiracustom.kiraClotheTypes.clothesParts.Length;
        int kiraPantPartsLength = kiracustom.kiraPantTypes.pantParts.Length;
        GameObject[] kiraHairParts = kiracustom.kiraHairTypes.hairParts;
        GameObject[] kiraClotheParts = kiracustom.kiraClotheTypes.clothesParts;
        GameObject[] kiraPantParts = kiracustom.kiraPantTypes.pantParts;
        for (int i = 1; i < kiraHairPartsLength; i++) { kiraHairParts[i].SetActive(false); }
        for (int i = 1; i < kiraClothePartsLength; i++) { kiraClotheParts[i].SetActive(false); }
        for (int i = 1; i < kiraPantPartsLength; i++) { kiraPantParts[i].SetActive(false); }
    }

    public void NextHair()
    {
        int kiraIndex = kiracustom.kiraHairTypes.currentIndex;
        SetHairToggle(kiraIndex, false);
        kiraIndex++;
        SetHairToggle(kiraIndex, true);
    }
    public void PreviousHair()
    {
        int kiraIndex = kiracustom.kiraHairTypes.currentIndex;
        SetHairToggle(kiraIndex, false);
        kiraIndex--;
        SetHairToggle(kiraIndex, true);
    }
    public void NextClothe()
    {
        int kiraIndex = kiracustom.kiraClotheTypes.currentIndex;
        SetClotheToggle(kiraIndex, false);
        kiraIndex++;
        SetClotheToggle(kiraIndex, true);
    }
    public void PreviousClothe()
    {
        int kiraIndex = kiracustom.kiraClotheTypes.currentIndex;
        SetClotheToggle(kiraIndex, false);
        kiraIndex--;
        SetClotheToggle(kiraIndex, true);
    }
    public void NextPant()
    {
        int kiraIndex = kiracustom.kiraPantTypes.currentIndex;
        SetPantToggle(kiraIndex, false);
        kiraIndex++;
        SetPantToggle(kiraIndex, true);
    }
    public void PreviousPant()
    {
        int kiraIndex = kiracustom.kiraPantTypes.currentIndex;
        SetPantToggle(kiraIndex, false);
        kiraIndex--;
        SetPantToggle(kiraIndex, true);

    }

    public void SetHairToggle(int kiraIndex, bool isActive)
    {
        int kiraHairLength = kiracustom.kiraHairTypes.hairParts.Length;
        GameObject[] kiraHairParts = kiracustom.kiraHairTypes.hairParts;
            if (kiraIndex >= 0 && kiraIndex < kiraHairLength)
            {
                for (int i = 0; i <= kiraHairLength; i++)
                    kiraHairParts[kiraIndex].SetActive(isActive);
            }
            if (!isActive && (kiraIndex == kiraHairLength)) { kiraHairParts[0].SetActive(true); }
           
    } 
    public void SetClotheToggle(int kiraIndex, bool isActive)
    {
        int kiraClotheLength = kiracustom.kiraClotheTypes.clothesParts.Length;
        GameObject[] kiraClotheParts = kiracustom.kiraClotheTypes.clothesParts;

            if (kiraIndex >= 0 && kiraIndex < kiraClotheLength)
            {
                for (int i = 0; i < kiraClotheLength; i++)
                    kiraClotheParts[kiraIndex].SetActive(isActive);
                if(!isActive && (kiraIndex == kiraClotheLength)) { kiraClotheParts[0].SetActive(true);}
            }
    }

    public void SetPantToggle(int kiraIndex, bool isActive)
    {
        int kiraPantLength = kiracustom.kiraPantTypes.pantParts.Length;
        GameObject[] kiraPantParts = kiracustom.kiraPantTypes.pantParts;
            if (kiraIndex >= 0 && kiraIndex < kiraPantLength)
            {
                for (int i = 0; i < kiraPantLength; i++)
                    kiraPantParts[kiraIndex].SetActive(isActive);
            }
            if (kiraIndex == 0) { kiraPantParts[0].SetActive(true); }
            else { kiraPantParts[0].SetActive(false); }
    }
}