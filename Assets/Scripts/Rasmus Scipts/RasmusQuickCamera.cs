using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasmusQuickCamera : MonoBehaviour
{

    public Transform followTransform; // transform to follow
    public int sceneIndex; // Current SceneIndex
    public float camYOffset; // Offset on y axis.
    public GameObject camParent;
    public float currentCameraZoom;
    public Camera cam;
    public float normalCameraZoom;
    public float newZoom;
    public float lerpTime;

    private void Start()
    {

    }

    void Update()
    {
        //Pixelizer(chungTexture);
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(CameraShake(2f, 0.3f, 0.5f, 0.5f));
        }
        cameraZoom();
    }

    public void cameraZoom()
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime * lerpTime);
    }

    void FixedUpdate()
    {
        camParent.transform.position = new Vector3(camParent.transform.position.x, followTransform.position.y + camYOffset, camParent.transform.position.z);
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
}