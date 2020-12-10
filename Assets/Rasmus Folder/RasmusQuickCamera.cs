using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasmusQuickCamera : MonoBehaviour
{

    public Transform followTransform; // transform to follow
    public int sceneIndex; // Current SceneIndex
    [SerializeField] float camYOffset; // Offset on y axis. Used only in main menu
    public GameObject camParent;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(CameraShake(2f, 0.3f, 0.5f, 0.5f));
        }
    }
    void FixedUpdate()
    {
        camParent.transform.position = new Vector3(camParent.transform.position.x, followTransform.position.y, camParent.transform.position.z);
    }

    IEnumerator CameraShake(float duration, float maxMagnitude, float attack, float decay)
    {
        float magnitude = 0f;
        float hold = duration - attack - decay;

        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            if (elapsed < attack)
            {
                magnitude = Mathf.Lerp(0f, maxMagnitude, elapsed / attack);
                print("magnitude" + magnitude);
            }
            else if (elapsed > hold + attack)
            {
                magnitude = Mathf.Lerp(maxMagnitude, 0f, (elapsed - attack - hold) / decay);
                print("magnitude" + magnitude);
            }

            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }

    float lerp(float v0, float v1, float t)
    {
        return (1 - t) * v0 + t * v1;
    }
}