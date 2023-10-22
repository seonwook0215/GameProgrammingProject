using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera firstCamera;
    public Camera secondCamera;
    public Camera movingCamera;
    private bool isTransitioning = false;
    private float transitionStartTime;
    float dragSpeed = 100.0f;
    void Start()
    {
        // �ʱ� ȭ�� ����
        mainCamera.enabled = true;
        firstCamera.enabled = false;
        secondCamera.enabled = false;
        movingCamera.enabled = false;
        movingCamera.transform.position=mainCamera.transform.position;
        movingCamera.transform.rotation = mainCamera.transform.rotation;
    }

    void Update()
    {
        Vector3 toMain = mainCamera.transform.position;
        Vector3 toFirst = firstCamera.transform.position;
        Vector3 toSecond = secondCamera.transform.position;

        Quaternion toMainRotate = mainCamera.transform.rotation;
        Quaternion toFirstRotate = firstCamera.transform.rotation;
        Quaternion toSecondRotate = secondCamera.transform.rotation;
        if (mainCamera.enabled)
        {
            movingCamera.transform.position = mainCamera.transform.position;
        }
        else if(secondCamera.enabled)
        {
            movingCamera.transform.position = secondCamera.transform.position;
        }
        else if (firstCamera.enabled)
        {
            movingCamera.transform.position = firstCamera.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Q) && !isTransitioning)
        {
            if (firstCamera.enabled)//1 ���� ȭ���� ���ִٸ�
            {
                mainCamera.enabled = true;
                secondCamera.enabled = false;
                firstCamera.enabled = false;
                StartCoroutine(TransitionCameras(toMain, toMainRotate));
            }
            else
            {
                secondCamera.enabled = false;
                mainCamera.enabled = false;
                firstCamera.enabled = true;
                StartCoroutine(TransitionCameras(toFirst, toFirstRotate));
               
            }

        }
        if (Input.GetKeyDown(KeyCode.W) && !isTransitioning)
        {
            if (secondCamera.enabled)
            {
                mainCamera.enabled = true;
                secondCamera.enabled = false;
                firstCamera.enabled = false;
                StartCoroutine(TransitionCameras(toMain, toMainRotate));
               
            }
            else
            {
                mainCamera.enabled = false;
                firstCamera.enabled = false;
                secondCamera.enabled = true;
                StartCoroutine(TransitionCameras(toSecond, toSecondRotate));
            }
            
        }
    }

    IEnumerator TransitionCameras(Vector3 targerPosition,Quaternion targetRotation)
    {
        isTransitioning = true;
        movingCamera.enabled = true;
        Vector3 initialPosition = movingCamera.transform.position;
        Quaternion initialRotation = movingCamera.transform.rotation;
        
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(initialPosition, targerPosition);

        while (isTransitioning)
        {
            float distanceCovered = (Time.time - startTime) * dragSpeed;
            float journeyFraction = distanceCovered / journeyLength;
            movingCamera.transform.position = Vector3.Lerp(initialPosition, targerPosition, journeyFraction);
            movingCamera.transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, journeyFraction);

            if (journeyFraction >= 1.0f)
            {
                movingCamera.enabled = false;
                isTransitioning = false;
            }
            yield return null;
        }

        // ��ȯ �Ϸ� ��
        
     
    }
}
