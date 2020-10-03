using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCorpseCatcher : MonoBehaviour
{
    [SerializeField] private int corpseCount;
    [SerializeField] private float duration = 3;
    [SerializeField] private int corpsesNeeded = 3;
    [SerializeField] private BuildingNest buildingNest;
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

        if (life != null && corpseCount < 1)
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

        if (cast.collider != null && !IsBuildingNest && corpseCount >= 1)
        {
            buildingPos = transform.position;
            buildingStartDate = Time.time;
            IsBuildingNest = true;
        }

        if(IsBuildingNest && Time.time > buildingStartDate + duration)
        {
            IsBuildingNest = false;
            if ((transform.position - buildingNest.transform.position).magnitude < 1)
                buildingNest.Count++;
            else
            {
                buildingNest.Count = 1;
                buildingNest.transform.position = transform.position;
                buildingNest.gameObject.SetActive(true);
            }
            if (buildingNest.Count >= corpsesNeeded)
            {
                nest.transform.position = buildingNest.transform.position;
                buildingNest.gameObject.SetActive(false);
            }
            corpseCount = 0;
        }

        if(IsBuildingNest) Debug.Log(Time.time - buildingStartDate);
    }
}
