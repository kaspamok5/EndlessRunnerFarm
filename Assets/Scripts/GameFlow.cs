using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameFlow : MonoBehaviour
{
    public GameObject tile1Obj;
    private Vector3 nextTileSpawn = Vector3.zero;
    private List<GameObject> tiles = new List<GameObject>();
    public GameObject[] obstacles;
    private float[] availableX = new float[] { -2.7f,0f,2.7f };
    public GameObject coin;

    void Start()
    {

        nextTileSpawn.z = 36;
        for (int i = 0; i < 4; i++)
        {

            tiles.Add(Instantiate(tile1Obj, Vector3.forward * i * 9, tile1Obj.transform.rotation));
        }

        //tiles.Add(Instantiate(tile1Obj, Vector3.forward * 9, tile1Obj.rotation));
        //tiles.Add(Instantiate(tile1Obj, Vector3.forward * 18, tile1Obj.rotation));
        //tiles.Add(Instantiate(tile1Obj, Vector3.forward * 27, tile1Obj.rotation));
        StartCoroutine(SpawnTile());
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnCoin());

    }

    private GameObject FindFirstNonNullObject(List<GameObject> objects)
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                return obj;
            }
        }

        return null;
    }

    IEnumerator SpawnTile()
    {
        //tiles.ForEach(tile => { print(tile); });
        yield return new WaitForSeconds(.45f);
        tiles.Add(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.transform.rotation));
        
        nextTileSpawn.z += 9;
        StartCoroutine(SpawnTile());
    }

    IEnumerator DestroyLastTile()
    {
        yield return new WaitForSeconds(1.24f);
        Destroy(tiles[0]);
        tiles.Remove(tiles[0]);
        StartCoroutine(DestroyLastTile());
    }

    IEnumerator SpawnObstacle()
    {
        // x == -2.7 arba 0 arba 2.7
        // z == rand, bet po nextTileSpawn
        yield return new WaitForSeconds(.4f);
        var gameObject = obstacles[Random.Range(0, obstacles.Length)];
        float zCord = nextTileSpawn.z;
        Instantiate(gameObject, new Vector3(availableX[Random.Range(0,availableX.Length)], 0f, (int)Random.Range(zCord, zCord + 9)), gameObject.transform.rotation);
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnCoin()
    {
        yield return new WaitForSeconds(.1f);
        Instantiate(coin, new Vector3(availableX[Random.Range(0, availableX.Length)], .5f, (int)Random.Range(nextTileSpawn.z, nextTileSpawn.z + 9)), gameObject.transform.rotation);
        StartCoroutine (SpawnCoin());
    }
}
