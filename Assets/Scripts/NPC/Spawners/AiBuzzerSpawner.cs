using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBuzzerSpawner : MonoBehaviour
{
    public GameObject AiToSpawn;
    public float maxCount;
    public float delay;
    public float startX, startY, endX, endY;

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
            ai.transform.localPosition = Vector2.zero;
            ai.GetComponent<AiFlyCombined>().body.localPosition = transform.localPosition;

            var buzzer = ai.GetComponent<AiFlyCombined>();
            buzzer.startX = startX;
            buzzer.startY = startY;
            buzzer.endX = endX;
            buzzer.endY = endY;

            buzzer.seeDistance = 3f;
            buzzer.attackSpeed = 0.2f;

            existingSpawns.Add(ai);

            lastSpawnTime = Time.time;
        }
    }
}
