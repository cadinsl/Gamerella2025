using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CharacterCustomization : MonoBehaviour
{
    [SerializeField] private Renderer rend;

    private Dictionary<string, string> colors =
        new Dictionary<string, string>() {
            {"Red", "#E74C3C" },
            {"Orange", "#E78A3C"},
            {"Yellow", "#FFFF00"},
            {"Green", "#27D491"},
            {"Blue", "#4C3CE7"},
            {"Violet", "#7A3CE7"},
            {"Black", "#1A1A1A"},
            {"Gray", "#7F7F7F"},
            {"White", "#EEEEEE"}
        };

    private int faceID;
    private int bodyColorID;
    private int hairID;
    private int hairColorID;

    [SerializeField] private Texture[] faces;
    [SerializeField] private Texture[] hairs;

    [SerializeField] private TextMeshProUGUI faceText;
    [SerializeField] private TextMeshProUGUI hairText;
    [SerializeField] private TextMeshProUGUI bodyColorText;
    [SerializeField] private TextMeshProUGUI hairColorText;

    private void Awake()
    {
        faceID = PlayerPrefs.GetInt("face", 0);
        hairID = PlayerPrefs.GetInt("hair", 0);
        hairColorID = PlayerPrefs.GetInt("hairColor", 3);
        bodyColorID = PlayerPrefs.GetInt("bodyColor", 2);
    }

    private void Start()
    {
        SetItem("face");
        SetItem("hair");
        SetItem("hairColor");
        SetItem("bodyColor");
    }

    public void SelectFaces(bool isForward)
    {
        if (isForward)
        {
            if (faceID == faces.Length - 1)
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
                faceID = faces.Length - 1;
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
            if (hairID == hairs.Length - 1)
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
                hairID = hairs.Length - 1;
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
            if (bodyColorID == colors.Count - 1)
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
                bodyColorID = colors.Count - 1;
            }
            else
            {
                bodyColorID--;
            }
        }
        PlayerPrefs.SetInt("bodyColor", bodyColorID);
        SetItem("bodyColor");
    }

    public void SelectHairColor(bool isForward)
    {
        if (isForward)
        {
            if (hairColorID == colors.Count - 1)
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
                hairColorID = colors.Count - 1;
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
                faceText.text = faces[faceID].name;
                rend.materials[2].SetTexture("_PrimaryTexture", faces[faceID]);
                break;
            case "hair":
                hairText.text = hairs[hairID].name;
                rend.materials[2].SetTexture("_SecondaryTexture", hairs[hairID]);
                break;
            case "hairColor":
                string screenColorName = colors.Keys.ElementAt(hairColorID);
                hairColorText.text = screenColorName.ToLower();
                if (ColorUtility.TryParseHtmlString(colors.Values.ElementAt(hairColorID), out Color hairColor))
                {
                    rend.materials[2].SetColor("_BaseColor", hairColor);
                }
                break;
            case "bodyColor":
                string bodyColorName = colors.Keys.ElementAt(bodyColorID);
                bodyColorText.text = bodyColorName.ToLower();
                if (ColorUtility.TryParseHtmlString(colors.Values.ElementAt(bodyColorID), out Color bodyColor))
                {
                    rend.materials[0].SetColor("_BaseColor", bodyColor);
                }
                break;
        }
    }
}
