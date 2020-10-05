using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmManager : MonoBehaviour
{
    [SerializeField] float startX, startY, endX, endY;
    public Vector2 currentPosition;

    //public List<AiSwarmFly> fliers = new List<AiSwarmFly>();
    public List<AiSwarmer> fliers = new List<AiSwarmer>();
    public List<float> assignedModifiers = new List<float>();
    public List<Vector2> assignedPositions = new List<Vector2>();
    public List<bool> isClockwise = new List<bool>();


    bool leftDirection = false;
    bool downDirection = false;
    bool active = true;

    float timeStart, timeSpan, verSpeed, horSpeed;

    Mutator target;
    float detectionRadius;

    private void Start()
    {
        target = FindObjectOfType<Mutator>();
        detectionRadius = 5;

        currentPosition = transform.localPosition;
        fliers.AddRange(GetComponentsInChildren<AiSwarmer>());
        bool nextClockwise = true;

        foreach(var f in fliers)
        {
            assignedModifiers.Add(1.5f + Random.value);
            f.speed = 0.05f + assignedModifiers[assignedModifiers.Count - 1] / 4f;

            if (nextClockwise) isClockwise.Add(true);
            else isClockwise.Add(false);

            nextClockwise = !nextClockwise;
        }

        var startingAngle = 360f / fliers.Count;

        for(int i = 1; i <= fliers.Count; i++)
        {
            assignedPositions.Add(new Vector2(Mathf.Cos(i * startingAngle), Mathf.Sin(i * startingAngle)) * assignedModifiers[i - 1]);
        }

        currentPosition = new Vector2((startX + endX) / 2f, (startY + endY) / 2f);
    }

    void FixedUpdate()
    {
        for (int i = 0; i < fliers.Count; i++)
        {
            if (fliers[i] == null)
            {
                fliers.RemoveAt(i);
                assignedModifiers.RemoveAt(i);
                assignedPositions.RemoveAt(i);
                isClockwise.RemoveAt(i);
                i--;
            }
        }

        var distance = new Vector2(currentPosition.x - target.transform.localPosition.x, currentPosition.y - target.transform.localPosition.y).magnitude;
        if (distance < detectionRadius)
        {
            if(target.GetCurrentState()!=LoopState.Roach)
            {
                foreach(var f in fliers)
                {
                    f.isAttacking = true;
                }
            }
        }
        else
        {
            foreach (var f in fliers)
            {
                f.isAttacking = false;
            }
        }

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

        for(int i = 0; i < fliers.Count; i++)
        {
            assignedModifiers[i] = Mathf.Clamp(assignedModifiers[i] + Random.value * 0.1f - 0.05f, 0.5f, 3.5f);

            var posRatio = (assignedPositions[i] - currentPosition).magnitude / assignedModifiers[i];
            var newPos = (assignedPositions[i] - currentPosition) / posRatio;

            var randomAngle = (0.03f + Random.value * 0.03f) * (isClockwise[i] ? 1f:-1f);
            newPos = new Vector2(Mathf.Cos(randomAngle) * newPos.x - Mathf.Sin(randomAngle) * newPos.y, Mathf.Sin(randomAngle) * newPos.x + Mathf.Cos(randomAngle) * newPos.y);

            assignedPositions[i] = currentPosition + newPos;

            fliers[i].assignedSwarmPosition = assignedPositions[i];

        }
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
        verSpeed = 0.02f + Random.value * 0.04f;
        horSpeed = 0.02f + Random.value * 0.04f;
    }
}
