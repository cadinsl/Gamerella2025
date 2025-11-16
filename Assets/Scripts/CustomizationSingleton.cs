using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class CustomizationSingleton : MonoBehaviour
{
    private static CustomizationSingleton _instance;

    public static CustomizationSingleton Instance { get { return _instance; } }

    public Dictionary<string, string> colors =
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

    public Dictionary<string, string> skinColors =
        new Dictionary<string, string>() {
            {"1", "#fbbea0" },
            {"2", "#fba68b"},
            {"3", "#dd793e"},
            {"4", "#893d21"},
            {"5", "#3d3d3d"},
            {"6", "#fed0ad"},
            {"7", "#fac48d"},
            {"8", "#fbb569"},
            {"9", "#ac5127"},
            {"10", "#5f2d15"}
        };

    public Dictionary<string, string> pantsColors =
        new Dictionary<string, string>() {
            {"1", "#E74C3C" },
            {"2", "#E78A3C"},
            {"3", "#FFFF00"},
            {"4", "#27D491"},
            {"5", "#4C3CE7"},
            {"6", "#7A3CE7"},
            {"7", "#1A1A1A"},
            {"8", "#7F7F7F"},
            {"9", "#EEEEEE"},
            {"10", "#d0a04b"},
            {"11", "#b7b7b7"},
            {"12", "#3d3d3d"},
            {"13", "#0a0503"},
            {"14", "#3d3d3d"},
            {"15", "#4f3e10"},
            {"16", "#875818"}
        };

    [SerializeField] public Texture[] faces;
    [SerializeField] public Mesh[] hairs;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
