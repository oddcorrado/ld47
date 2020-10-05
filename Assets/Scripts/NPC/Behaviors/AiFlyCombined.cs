using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFlyCombined : MonoBehaviour
{
    [SerializeField] Controller controller;
    [SerializeField] AiBuzzerLife life;
    [SerializeField] SpriteRenderer intentRenderer;
    public Transform body, emote;
    [SerializeField] Sprite scared, neutral, angry;

    public Mutator target;

    public float seeDistance, attackSpeed;
    public float startX, startY, endX, endY;

    LoopState lastKnownTargetState = LoopState.LarvaBirth;

    bool leftDirection = false;
    bool downDirection = false;
    bool active = true;

    float timeStart, timeSpan, verSpeed, horSpeed;

    void FixedUpdate()
    {
        if (target == null)
        {
            target = FindObjectOfType<Mutator>();
        }
        else if (lastKnownTargetState != target.GetCurrentState())
        {
            ResetTargetState();
        }

        if (target != null)
        {
            var targetDirection = target.transform.localPosition - body.localPosition;

            if (targetDirection.magnitude < seeDistance && !target.isHidden)
            {
                if (lastKnownTargetState == LoopState.LarvaToRoach || lastKnownTargetState == LoopState.Roach)
                {
                    intentRenderer.sprite = scared;
                    controller.PressedState = new Controller.Pressed()
                    {
                        hor = attackSpeed * -targetDirection.normalized.x,
                        ver = attackSpeed * -targetDirection.normalized.y,
                    };
                }
                else
                {
                    intentRenderer.sprite = angry;
                    controller.PressedState = new Controller.Pressed()
                    {
                        hor = attackSpeed * targetDirection.normalized.x,
                        ver = attackSpeed * targetDirection.normalized.y,
                    };
                }
            }
            else
            {
                intentRenderer.sprite = neutral;
                ApplyRandomMove();
            }
        }
        else
        {
            intentRenderer.sprite = neutral;
            ApplyRandomMove();
        }

        emote.localPosition = new Vector3(body.localPosition.x, body.localPosition.y + 0.4f,0);
    }

    void ApplyRandomMove()
    {
        if (timeStart + timeSpan < Time.time)
        {
            SetRandomState();
        }

        if (body.localPosition.x < startX)
        {
            leftDirection = false;
        }
        if (body.localPosition.x > endX)
        {
            leftDirection = true;
        }
        if (body.localPosition.y < startY)
        {
            downDirection = false;
        }
        if (body.localPosition.y > endY)
        {
            downDirection = true;
        }

        controller.PressedState = new Controller.Pressed()
        {
            hor = horSpeed * (leftDirection ? -1f : 1f) * (active ? 1f : 0f),
            ver = verSpeed * (downDirection ? -1f : 1f) * (active ? 1f : 0f)
        };
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

    void ResetTargetState()
    {
        lastKnownTargetState = target.GetCurrentState();
    }
}
