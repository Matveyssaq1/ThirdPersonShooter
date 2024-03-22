using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCheck : MonoBehaviour
{
    public PlayerProgress playerProgress;
    public GameObject portalPrefab;
    public float checkValue = 2;
    public GameObject gate1;
    public GameObject gate2;
    public void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }
    private void Update()
    {
        LevelPassCheck();
    }
    public void LevelPassCheck()
    {
        if (playerProgress.check == checkValue)
        {
            var portal = Instantiate(portalPrefab);
            portal.transform.position = transform.position;
            Destroy(gate1);
            Destroy(gate2);
        }
    }
}
