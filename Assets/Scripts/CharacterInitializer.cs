using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CharacterInitializer : MonoBehaviour
{
    private Renderer rend;

    [SerializeField] private GameObject[] characters;
    [SerializeField] private Transform playerInitPosition;

    private GameObject characterInstance;


    private int _faceID;
    private int _bodyColorID;
    private int _hairID;
    private int _hairColorID;

    public void setCharacter(int cFaceID, int cBodyColorID, int cHairID, int cHairColorID)
    {
        characterInstance = Instantiate(characters[1], playerInitPosition);
        rend = characterInstance.GetComponent<MiiCustomization>().rend;
        setHair(cHairID);
        setFace(cFaceID);
        setHairColor(cHairColorID);
        setBodyColor(cBodyColorID);

        _faceID = cFaceID;
        _bodyColorID = cBodyColorID;
        _hairID = cHairID;
        _hairColorID = cHairColorID;
    }

    private void setHair(int cHairID)
    {
        characterInstance.GetComponent<PersonalManager>().setHairs(cHairID);
    }

    private void setFace(int cFaceID)
    {
        rend.materials[1].SetTexture("_BaseMap", CustomizationSingleton.Instance.faces[cFaceID]);
    }

    private void setHairColor(int cHairColorID)
    {
        if (ColorUtility.TryParseHtmlString(CustomizationSingleton.Instance.skinColors.Values.ElementAt(cHairColorID), out Color hairColor))
        {
            rend.materials[1].SetColor("_BaseColor", hairColor);
        }
    }

    private void setBodyColor(int cBodyColorID)
    {
        if (ColorUtility.TryParseHtmlString(CustomizationSingleton.Instance.colors.Values.ElementAt(cBodyColorID), out Color bodyColor))
        {
            rend.materials[0].SetColor("_BaseColor", bodyColor);
        }
    }
}
