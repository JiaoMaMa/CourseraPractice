using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    // needed for spawning
    [SerializeField]
    GameObject prefabRock;
    [SerializeField]
    Sprite greenRock;
    [SerializeField]
    Sprite magentaRock;
    [SerializeField]
    Sprite whiteRock;

    // spawn control
    const float spawnDelay = 1;
    Timer spawnTimer;

    // spawn location support
    float spawnX = Screen.width / 2;
    float spawnY = Screen.height / 2;



    // Start is called before the first frame update
    void Start()
    {
        // create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = spawnDelay;
        spawnTimer.Run();

    }

    // Update is called once per frame
    void Update()
    {
        if ((spawnTimer.Finished)&&(GameObject.FindGameObjectsWithTag("Rock").Length<3))
        {
            SpawnRock();
            spawnTimer.Run();
        }
        
    }

    void SpawnRock()
    {
        // create new rock 
        Vector3 location = new Vector3(spawnX,
        spawnY, -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        GameObject Rock = Instantiate(prefabRock) as GameObject;
        Rock.transform.position = worldLocation;

        // set random sprite for new rock
        SpriteRenderer spriteRenderer = Rock.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        switch (spriteNumber)
        {
            case 0:
                spriteRenderer.sprite = greenRock;
                break;

            case 1:
                spriteRenderer.sprite = magentaRock;
                break;
            default:
                spriteRenderer.sprite = whiteRock;
                break;
        }
    }
}
