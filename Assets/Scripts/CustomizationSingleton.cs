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

    [SerializeField] public Texture[] faces;
    [SerializeField] public GameObject[] hairs;


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
