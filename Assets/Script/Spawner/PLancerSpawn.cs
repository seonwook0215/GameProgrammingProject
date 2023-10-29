using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLancerSpawn : MonoBehaviour
{
    public GameObject rangeobject;

    BoxCollider rangeCollider;
    public GameObject unit;
    public float num;
    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        for (float i = 0; i < num; i++)
        {
            yield return new WaitForSeconds(0);

            GameObject instantUnit = Instantiate(unit, Return_RandomPosition(), Quaternion.identity);
        }
    }
    private void Awake()
    {
        rangeCollider = rangeobject.GetComponent<BoxCollider>();
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeobject.transform.position;

        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPosition = new Vector3(range_X, 1, range_Z);

        Vector3 respawnPosition = originPosition + RandomPosition;

        return respawnPosition;
    }
}
