using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDrop : MonoBehaviour
{
    private float acceleration;
    private float spinSpeed;
    private Vector3 spinAngle;

    private float minAcceleration = .1f;
    private float maxAcceleration = .25f;
    private float minSpinSpeed = 25f;
    private float maxSpinSpeed = 50f;

    private float secondsCounter = 0f;

    private void Awake()
    {
        acceleration = Random.Range(minAcceleration, maxAcceleration);
        spinSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
        spinAngle = new Vector3(0, Random.Range(0, 1), 0);

        SetScale();
    }

    // Update is called once per frame
    void Update()
    {
        Spin();
        Fall();
        DestroyIfGrounded();
    }

    void Fall()
    {
        secondsCounter += Time.deltaTime;
        float velocity = secondsCounter * acceleration;
        transform.Translate(Vector3.down * velocity);
    }

    void Spin()
    {
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
    }

    void SetScale()
    {
        float scaleFactor = Random.Range(0, 3);
        transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor);

    }

    void DestroyIfGrounded()
    {
        Camera camera = Camera.main;
        if (camera.WorldToViewportPoint(gameObject.transform.position).y <= -5f)
            Destroy(gameObject);
    }
}
