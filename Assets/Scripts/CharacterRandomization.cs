using UnityEngine;

public class CharacterRandomization : MonoBehaviour
{
    public CharacterInitializer characterInitializer;
    public Transform[] spawnPoints;
    private int currentFreeSpawnPoint = 0;
    [SerializeField] private int howManyCharactersToSpawn;
    private int numberOfCharactersSpawned = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        while (numberOfCharactersSpawned < howManyCharactersToSpawn)
        {
            spawnRandomCharacter();
            numberOfCharactersSpawned++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnRandomCharacter()
    {
        int faceID = Random.Range(0, CustomizationSingleton.Instance.faces.Length - 1);
        int hairID = Random.Range(0, CustomizationSingleton.Instance.hairs.Length - 1);
        int shirtColorID = Random.Range(0, CustomizationSingleton.Instance.colors.Count - 1);
        int hairColorID = Random.Range(0, CustomizationSingleton.Instance.pantsColors.Count - 1);
        int skinColorID = Random.Range(0, CustomizationSingleton.Instance.skinColors.Count - 1);

        characterInitializer.setCharacter(faceID, shirtColorID, hairID, skinColorID,hairColorID, spawnPoints[currentFreeSpawnPoint]);
        currentFreeSpawnPoint += 1;
    }
}
