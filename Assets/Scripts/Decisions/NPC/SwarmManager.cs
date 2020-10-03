using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmManager : MonoBehaviour
{
    public float centerThreshold, centerModThreshold;
    [SerializeField] float startX, startY, endX, endY;

    public List<AiSwarmFly> fliers = new List<AiSwarmFly>();

    Vector2 currentPosition;

    bool leftDirection = false;
    bool downDirection = false;
    bool active = true;

    float timeStart, timeSpan, verSpeed, horSpeed;

    void FixedUpdate()
    {
        if (currentPosition.x < startX)
        {
            leftDirection = false;
        }
        if (currentPosition.x > endX)
        {
            leftDirection = true;
        }
        if (currentPosition.y < startY)
        {
            downDirection = false;
        }
        if (currentPosition.y > endY)
        {
            downDirection = true;
        }

        if (timeStart + timeSpan < Time.time)
        {
            SetRandomState();
        }
        currentPosition.x += horSpeed * (leftDirection ? -1f : 1f) * (active ? 1f : 0f);
        currentPosition.y += verSpeed * (downDirection ? -1f : 1f) * (active ? 1f : 0f);

        foreach (var f in fliers)
        {
            var centerDirection = currentPosition + f.currentCenterThresholdMod - (Vector2)f.transform.localPosition;
            var closestDirection = GetClosestFlier(f) * (f.isGoingForward ? 1f : -1f);

            f.currentCenterThresholdMod = new Vector2
                (
                    Mathf.Clamp(f.currentCenterThresholdMod.x + (Random.value * centerModThreshold * 0.2f) - centerModThreshold * 0.1f, -centerModThreshold, centerModThreshold),
                    Mathf.Clamp(f.currentCenterThresholdMod.y + (Random.value * centerModThreshold * 0.2f) - centerModThreshold * 0.1f, -centerModThreshold, centerModThreshold)
                );

            if (Random.value > 0.9f) f.isGoingForward = !f.isGoingForward;
            f.bestDirection = centerDirection + closestDirection;
        }
    }

    Vector2 GetClosestFlier(AiSwarmFly target)
    {
        var closestDistance = float.MaxValue;
        var closestVector = Vector2.zero;

        for(int i = 0; i <fliers.Count; i++)
        {
            
            if(fliers[i] != target) 
            {
            var dist = (fliers[i].transform.localPosition - target.transform.localPosition).magnitude;
                if (dist < closestDistance)
                {
                    closestDistance = dist;
                    closestVector = fliers[i].transform.localPosition - target.transform.localPosition;
                }
            }
        }

        return closestVector;
    }

    void SetRandomState()
    {
        active = Random.value > 0.25f;

        if (Random.value > 0.5f)
        {
            leftDirection = Random.value > 0.5f;
        }
        if (Random.value > 0.5f)
        {
            downDirection = Random.value > 0.5f;
        }

        timeStart = Time.time;
        timeSpan = 0.2f + Random.value;
        verSpeed = 0.06f + Random.value * 0.12f;
        horSpeed = 0.06f + Random.value * 0.12f;
    }
}
