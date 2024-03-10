using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKitSpawner : MonoBehaviour
{
    public AidKit aidkitPrefab;
    public float delayMin = 3;
    public float delayMax = 9;
    private List<Transform> _spawnerPoints;

    private AidKit _aidKit;
    
    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }
    
    private void Update()
    {
        if (_aidKit != null) return;
        if (IsInvoking()) return;
        Invoke( "CreateAidKit",Random.Range(delayMin,delayMax));
        
        

        
    }

    private void CreateAidKit()
    {
        _aidKit = Instantiate(aidkitPrefab);
        _aidKit.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
    }
}
