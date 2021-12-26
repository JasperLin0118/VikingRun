using UnityEngine;
public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    public GameObject bridge;
    Vector3 nextSpawnPoint;
    public int rotateDegree;
    public int count = 0;
    public bool isTurningTile = false;
    public string obstaclename = "not bridge";

    public void SpawnTile()
    {
        if (Random.Range(0, 101) <= 20 && count > 8)
        {
            count = 0;
            isTurningTile = true;
            if (Random.Range(0, 101) <= 50)
                rotateDegree += 90;
            else
                rotateDegree += -90;
        }
        GameObject temp;
        int num = Random.Range(0, 101);
        if (num <= 20  && (!isTurningTile && count >= 6))
        {
            obstaclename = "Bridge";
            temp = Instantiate(bridge, nextSpawnPoint, Quaternion.Euler(0, rotateDegree, 0));
        }
        else
        {
            obstaclename = "not bridge";
            temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.Euler(0, rotateDegree, 0));
        }
        isTurningTile = false;
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        count++;
    }
    void Start()
    {
        for (int i = 0; i < 12; i++)
            SpawnTile();
    }
}
