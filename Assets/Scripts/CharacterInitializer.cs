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
    private int _pantsColorID;

    public void setCharacter(int cFaceID, int cBodyColorID, int cHairID, int cHairColorID, int cPantsColorID, Transform initPosition = null)
    {
        if (initPosition == null)
        {
            characterInstance = Instantiate(characters[1], playerInitPosition);
        }
        else
        {
            characterInstance = Instantiate(characters[1], initPosition);
        }
        rend = characterInstance.GetComponent<MiiCustomization>().rend;
        setHair(cHairID);
        setFace(cFaceID);
        setHairColor(cHairColorID);
        setBodyColor(cBodyColorID);
        setPantsColor(cPantsColorID);

        _faceID = cFaceID;
        _bodyColorID = cBodyColorID;
        _hairID = cHairID;
        _hairColorID = cHairColorID;
        _pantsColorID = cPantsColorID;
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

    private void setPantsColor(int cPantsColorID)
    {
        if (ColorUtility.TryParseHtmlString(CustomizationSingleton.Instance.pantsColors.Values.ElementAt(cPantsColorID), out Color pantsColor))
        {
            characterInstance.GetComponent<PersonalManager>().currentHairObject.GetComponent<MeshRenderer>().materials[0].SetColor("_BaseColor", pantsColor);
        }
    }
}
