using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnTargets : MonoBehaviour
{
    [SerializeField] GameObject gameStart;
    [SerializeField] GameObject[] gameObjects;

    // Update is called once per frame
    void Update()
    {
        if (gameStart.IsDestroyed())
        {
            ActivateGameObjects(gameObjects);
            Destroy(this);
        }
    }

    private void ActivateGameObjects(GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(true);
        }
    }
}
