using UnityEngine;


public sealed class TrafficSignSpawner : MonoBehaviour {

    public int prefabCount = 20;                                    // per line
    public GameObject[] extraTrafficSignPrefabs;
    public GameObject[] mandatoryTrafficSignPrefabs;
    public GameObject[] informativeTrafficSignPrefabs;
    public GameObject[] prohibitionTrafficSignPrefabs;
    public GameObject[] speedLimitTrafficSignPrefabs;
    public GameObject[] precedenceTrafficSignPrefabs;
    public GameObject[] warningTrafficSignPrefabs;
    public GameObject[] trainTrafficSignPrefabs;

    private int x, y, z;
    

    private void Start() {
        int spawnedTrafficSigns = x = y = z = 0;

        spawnedTrafficSigns += Spawn(extraTrafficSignPrefabs);
        spawnedTrafficSigns += Spawn(mandatoryTrafficSignPrefabs);
        spawnedTrafficSigns += Spawn(informativeTrafficSignPrefabs);
        spawnedTrafficSigns += Spawn(prohibitionTrafficSignPrefabs);
        spawnedTrafficSigns += Spawn(speedLimitTrafficSignPrefabs);
        spawnedTrafficSigns += Spawn(precedenceTrafficSignPrefabs);
        spawnedTrafficSigns += Spawn(warningTrafficSignPrefabs);
        spawnedTrafficSigns += Spawn(trainTrafficSignPrefabs);

        Debug.Log(spawnedTrafficSigns + " traffic signs spawned in the " + transform.parent.name);
    }
    
    private int Spawn(GameObject[] prefabs) {
        int spawnedPrefabs = 0;

        if (prefabs.Length == 0) {
            return spawnedPrefabs;
        }
        
        foreach (GameObject prefab in prefabs) {
            Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity, transform);
            x += 2;

            if (x >= prefabCount) {
                x = 0;
                z += 2;
            }

            spawnedPrefabs++;
        }

        return spawnedPrefabs;
    }

}