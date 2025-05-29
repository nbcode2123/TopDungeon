using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAttackSpawner : MonoBehaviour
{
    public GameObject Spike;
    public float RangeSpawner;
    public float TimeActive = 5f;
    public float TimeDelayEachSpike = 0.5f;
    public GameObject CenterPos;
    private float TimeCounter = 0;
    public int SpikeCounter = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    public IEnumerator Active()
    {
        // while ()
        // {

        // }
        // var x = Random.Range(CenterPos.transform.position.x - RangeSpawner, CenterPos.transform.position.x + RangeSpawner);
        // var y = Random.Range(CenterPos.transform.position.y - RangeSpawner, CenterPos.transform.position.y + RangeSpawner);
        // Vector3 _tempPos = new Vector3(x, y, 0);
        // Instantiate(Spike, _tempPos, Quaternion.identity);
        // TimeCounter += TimeDelayEachSpike;
        for (int i = 0; i < SpikeCounter; i++)
        {
            var x = Random.Range(CenterPos.transform.position.x - RangeSpawner, CenterPos.transform.position.x + RangeSpawner);
            var y = Random.Range(CenterPos.transform.position.y - RangeSpawner, CenterPos.transform.position.y + RangeSpawner);
            Vector3 _tempPos = new Vector3(x, y, 0);
            Instantiate(Spike, _tempPos, Quaternion.identity);
            yield return new WaitForSeconds(TimeDelayEachSpike);
        }
    }
}
