using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public GameObject tile1Obj;
    private Vector3 nextTileSpawn = Vector3.zero;
    private List<GameObject> tiles = new List<GameObject>();

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
        StartCoroutine(DestroyLastTile());

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
        tiles.ForEach(tile => { print(tile); });
        yield return new WaitForSeconds(1);
        tiles.Add(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.transform.rotation));
        
        nextTileSpawn.z += 9;
        StartCoroutine(SpawnTile());
    }

    IEnumerator DestroyLastTile()
    {
        yield return new WaitForSeconds(1.1f);
        Destroy(FindFirstNonNullObject(tiles));
        StartCoroutine(DestroyLastTile());
    }
}
