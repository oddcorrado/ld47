using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBrouterSpawner : MonoBehaviour
{
    public GameObject AiToSpawn;
    public float maxCount;
    public float delay;
    public float startX, endX;

    List<GameObject> existingSpawns = new List<GameObject>();
    float lastSpawnTime = 0;

    private void LateUpdate()
    {
        for (int i = 0; i < existingSpawns.Count; i++)
        {
            if (existingSpawns[i] == null)
            {
                existingSpawns.RemoveAt(i);
                i--;
            }
        }

        if(lastSpawnTime + delay < Time.time && existingSpawns.Count <= maxCount)
        {
            var ai = Instantiate(AiToSpawn);
            ai.transform.SetParent(gameObject.transform);
            ai.transform.localPosition = Vector2.zero;
            ai.transform.localScale = new Vector2(1.3f,1.3f);

            var walk = ai.GetComponent<AiWalkRandom>();
            walk.startX = startX;
            walk.endX = endX;

            existingSpawns.Add(ai);

            lastSpawnTime = Time.time;
        }
    }
}
