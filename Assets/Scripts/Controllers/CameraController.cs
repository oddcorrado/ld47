using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    private Vector3 recul;

    public float innertie;

    private void Start()
    {
        recul = new Vector3(0, 0, -15);
    }

    private void Update()
    {

        Follow();

    }

    void Follow()
    {
        Vector3 TargetPosition = target.position + recul;

        Vector3 InnertiePosition = Vector3.Lerp(transform.position, TargetPosition, innertie* Time.deltaTime);

        transform.position = InnertiePosition;
    }

}
