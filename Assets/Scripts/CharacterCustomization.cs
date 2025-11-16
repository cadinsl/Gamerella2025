using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CharacterCustomization : MonoBehaviour
{
    public Renderer rend;

    private int faceID;
    private int bodyColorID;
    private int hairID;
    private int hairColorID;
    private int pantsColorID;

    public GameObject[] hairs;

    public GameObject currentSkinGameObject;
    public GameObject currentHairGameObject;


    [SerializeField] private TextMeshProUGUI faceText;
    [SerializeField] private TextMeshProUGUI hairText;
    [SerializeField] private TextMeshProUGUI bodyColorText;
    [SerializeField] private TextMeshProUGUI hairColorText;
    [SerializeField] private TextMeshProUGUI pantsColorText;

    [SerializeField] private CharacterInitializer characterInitializer;

    private void Awake()
    {
        faceID = PlayerPrefs.GetInt("face", 0);
        hairID = PlayerPrefs.GetInt("hair", 0);
        hairColorID = PlayerPrefs.GetInt("hairColor", 3);
        bodyColorID = PlayerPrefs.GetInt("bodyColor", 2);
        pantsColorID = PlayerPrefs.GetInt("pantsColor", 0);
    }

    private void Start()
    {
        rend = currentSkinGameObject.GetComponent<MiiCustomization>().rend;
        SetItem("face");
        SetItem("hair");
        SetItem("hairColor");
        SetItem("bodyColor");
    }

    public void SelectFaces(bool isForward)
    {
        if (isForward)
        {
            if (faceID == CustomizationSingleton.Instance.faces.Length - 1)
            {
                faceID = 0;
            }
            else
            {
                faceID++;
            }
        }
        else
        {
            if (faceID == 0)
            {
                faceID = CustomizationSingleton.Instance.faces.Length - 1;
            }
            else
            {
                faceID--;
            }
        }
        PlayerPrefs.SetInt("face", faceID);
        SetItem("face");
    }

    public void SelectHair(bool isForward)
    {
        if (isForward)
        {
            if (hairID == CustomizationSingleton.Instance.hairs.Length - 1)
            {
                hairID = 0;
            }
            else
            {
                hairID++;
            }
        }
        else
        {
            if (hairID == 0)
            {
                hairID = CustomizationSingleton.Instance.hairs.Length - 1;
            }
            else
            {
                hairID--;
            }
        }
        PlayerPrefs.SetInt("hair", hairID);
        SetItem("hair");
    }

    public void SelectBodyColor(bool isForward)
    {
        if (isForward)
        {
            if (bodyColorID == CustomizationSingleton.Instance.colors.Count - 1)
            {
                bodyColorID = 0;
            }
            else
            {
                bodyColorID++;
            }
        }
        else
        {
            if (bodyColorID == 0)
            {
                bodyColorID = CustomizationSingleton.Instance.colors.Count - 1;
            }
            else
            {
                bodyColorID--;
            }
        }
        PlayerPrefs.SetInt("bodyColor", bodyColorID);
        SetItem("bodyColor");
    }

    public void SelectPantsColor(bool isForward)
    {
        if (isForward)
        {
            if (pantsColorID == CustomizationSingleton.Instance.colors.Count - 1)
            {
                pantsColorID = 0;
            }
            else
            {
                pantsColorID++;
            }
        }
        else
        {
            if (pantsColorID == 0)
            {
                pantsColorID = CustomizationSingleton.Instance.colors.Count - 1;
            }
            else
            {
                pantsColorID--;
            }
        }
        PlayerPrefs.SetInt("pantsColor", pantsColorID);
        SetItem("pantsColor");
    }


    public void SelectHairColor(bool isForward)
    {
        if (isForward)
        {
            if (hairColorID == CustomizationSingleton.Instance.skinColors.Count - 1)
            {
                hairColorID = 0;
            }
            else
            {
                hairColorID++;
            }
        }
        else
        {
            if (hairColorID == 0)
            {
                hairColorID = CustomizationSingleton.Instance.skinColors.Count - 1;
            }
            else
            {
                hairColorID--;
            }
        }
        PlayerPrefs.SetInt("hairColor", hairColorID);
        SetItem("hairColor");
    }

    private void SetItem(string type)
    {
        switch (type)
        {
            case "face":
                faceText.text = CustomizationSingleton.Instance.faces[faceID].name;
                rend.materials[1].SetTexture("_BaseMap", CustomizationSingleton.Instance.faces[faceID]);
                break;
            case "hair":
                hairText.text = CustomizationSingleton.Instance.hairs[hairID].name;
                currentHairGameObject.SetActive(false);
                currentHairGameObject = hairs[hairID];
                currentHairGameObject.SetActive(true);
                SetItem("hairColor");
                break;
            case "hairColor":
                string screenColorName = CustomizationSingleton.Instance.skinColors.Keys.ElementAt(hairColorID);
                hairColorText.text = screenColorName.ToLower();
                if (ColorUtility.TryParseHtmlString(CustomizationSingleton.Instance.skinColors.Values.ElementAt(hairColorID), out Color hairColor))
                {
                    rend.materials[1].SetColor("_BaseColor", hairColor);
                }
                break;
            case "bodyColor":
                string bodyColorName = CustomizationSingleton.Instance.colors.Keys.ElementAt(bodyColorID);
                bodyColorText.text = bodyColorName.ToLower();
                if (ColorUtility.TryParseHtmlString(CustomizationSingleton.Instance.colors.Values.ElementAt(bodyColorID), out Color bodyColor))
                {
                    rend.materials[0].SetColor("_BaseColor", bodyColor);
                }
                break;
            case "pantsColor":
                string pantsColorName = CustomizationSingleton.Instance.colors.Keys.ElementAt(pantsColorID);
                pantsColorText.text = pantsColorName.ToLower();
                if (ColorUtility.TryParseHtmlString(CustomizationSingleton.Instance.colors.Values.ElementAt(pantsColorID), out Color pantsColor))
                {
                    //rend.materials[0].SetColor("_BaseColor", bodyColor);
                }
                break;
        }
    }


    public void next()
    {
        characterInitializer.setCharacter(faceID, bodyColorID, hairID, hairColorID);
    }
}
