using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
    void Start()
    {
        for (int i = 0; i < 12; i++)
            SpawnTile();
    }
}
