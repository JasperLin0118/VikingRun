using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;
    public GameObject obstaclePrefab2;
    public GameObject coinPrefab;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        if (!groundSpawner.obstaclename.Equals("Bridge"))
        {
            if (!groundSpawner.isTurningTile && groundSpawner.count > 6)
                SpawnObstacle();
            SpawnCoins();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 3);
    }

    public void SpawnObstacle()
    {
        if (Random.Range(0, 101) <= 30)
        {
            //choose a point to spawn obstacle
            Transform spawnPoint = transform.GetChild(2).transform;
            //spawn it
            if(Random.Range(0, 3) == 0)
                Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.Euler(0, groundSpawner.rotateDegree, 0), transform);
            else
                Instantiate(obstaclePrefab2, spawnPoint.position + new Vector3(Random.Range(0.2f, 4f), 1, 0), Quaternion.Euler(0, groundSpawner.rotateDegree, 0), transform);

        }
    }
    void SpawnCoins()
    {
        if (Random.Range(0, 101) <= 50)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
    Vector3 GetRandomPointInCollider (Collider collider)
    {
        float bound_dif_x = collider.bounds.max.x - collider.bounds.min.x;
        float bound_dif_z = collider.bounds.max.z - collider.bounds.min.z;
        float[] points_x = new float[] { 0, bound_dif_x / 3 - 0.5f, 2 * bound_dif_x / 3 - 0.5f};
        float[] points_z = new float[] { 0, bound_dif_x / 3 - 0.5f, 2 * bound_dif_z / 3 - 0.5f};
        Vector3 point = new Vector3(
            collider.bounds.min.x + points_x[Random.Range(0, 3)] + 1.5f, 2.05f, collider.bounds.min.z + points_z[Random.Range(0, 3)] + 1.5f);
        return point;
    }
}