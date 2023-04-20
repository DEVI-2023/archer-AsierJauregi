using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VatSpawner : MonoBehaviour
{

    [SerializeField] private GameObject vatPrefab;
    [SerializeField] private GameObject currentVat;
    [SerializeField] private float xMinRange;
    [SerializeField] private float xMaxRange;
    [SerializeField] private float zMinRange;
    [SerializeField] private float zMaxRange;

    // Update is called once per frame
    void Update()
    {
        if (currentVat == null)
        {
            SpawnVat();
        }
    }

    private IEnumerator SpawnVat()
    {
        yield return new WaitForSeconds(3f);
        GameObject newVat = Instantiate(vatPrefab);
        newVat.transform.position.Set(Random.Range(xMinRange, xMaxRange),0,Random.Range(zMinRange, zMaxRange));
        currentVat = newVat;
    }
}
