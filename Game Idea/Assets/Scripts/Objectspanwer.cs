using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectspanwer : MonoBehaviour
{
    public GameObject SpikePrefab; // Assign your spike prefab in the Inspector
    public GameObject CubePrefab; // Assign your cube prefab in the Inspector
    public int numberOfSpikes = 10; // Number of spikes to spawn
    public int numberOfCubes = 10; // Number of cubes to spawn
    public float spacing = 2f; // Space between each object

    void Start()
    {
        // Instantiate spikes
        for (int i = 0; i < numberOfSpikes; i++)
        {
            Vector3 spikePosition = new Vector3(i * spacing, 0, 0); // Adjust Y position as needed
            Instantiate(SpikePrefab, spikePosition, Quaternion.identity);
            Debug.Log("Spawned Spike at: " + spikePosition);
        }

        // Instantiate cubes
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 cubePosition = new Vector3(i * spacing, 1, 0); // Adjust Y position as needed
            Instantiate(CubePrefab, cubePosition, Quaternion.identity);
            Debug.Log("Spawned Cube at: " + cubePosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
