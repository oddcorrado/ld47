using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCorpseCatcher : MonoBehaviour
{
    [SerializeField] private int corpseCount;
    [SerializeField] private float duration = 3;
    [SerializeField] private int corpsesNeeded = 3;
    [SerializeField] private GameObject nest;

    public bool IsBuildingNest { get; set; }
    private Vector3 buildingPos;
    private float buildingStartDate = 0;

    private void OnEnable()
    {
        corpseCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var life = collision.gameObject.GetComponent<CorpseLife>();

        if (life != null && corpseCount < corpsesNeeded)
        {
            life.Die();
            corpseCount++;
        }
    }

    private void FixedUpdate()
    {
        LayerMask mask = LayerMask.GetMask("wall");
        var cast = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, mask);
        if (IsBuildingNest && (transform.position - buildingPos).magnitude > 0.1f)
        {
            IsBuildingNest = false;
        }

        if (cast.collider != null && !IsBuildingNest && corpseCount >= corpsesNeeded)
        {
            buildingPos = transform.position;
            buildingStartDate = Time.time;
            IsBuildingNest = true;
        }

        if(IsBuildingNest && Time.time > buildingStartDate + duration)
        {
            nest.transform.position = transform.position;
            corpseCount = 0;
        }

        if(IsBuildingNest) Debug.Log(Time.time - buildingStartDate);
    }
}
