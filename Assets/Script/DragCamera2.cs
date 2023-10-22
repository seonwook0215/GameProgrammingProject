using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DragCamera2 : MonoBehaviour
{
    public Camera first;
    Vector2 clickPoint;
    float dragSpeed = 100.0f;
    Vector3 lineStart = new Vector3(-71f, 80f, -36.5f);
    Vector3 lineEnd = new Vector3(-70.5f, 71f, 16.5f);
    

    // �߰� ����: ī�޶� �̵� ������ ���θ� ��Ÿ���� �÷���
    bool isCameraMoving = false;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            clickPoint = Input.mousePosition;

            // ���콺 ��ư�� ���� �� ī�޶� �̵� �÷��� �ʱ�ȭ
            isCameraMoving = false;
        }

        if (Input.GetMouseButton(0)&&first.enabled)
        {
            Vector3 position = first.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);
            position.z = position.y;
            position.y = 0.0f;

            Vector3 move = position * (Time.deltaTime * dragSpeed);

            float y = transform.position.y;

            transform.Translate(move);
            Vector3 newPosition = new Vector3(transform.position.x, y, transform.position.z);

            // �巡�� ���� ���
            Vector2 currentMousePosition = Input.mousePosition;
            Vector2 dragDirection = currentMousePosition - clickPoint;

            clickPoint = currentMousePosition;

            // ���ʿ��� ���������� �巡���ϴ� ���
            if (dragDirection.x > 0)
            {
                // ī�޶� �̵� ���� ��쿡�� lineStart�� �̵�
                if (!isCameraMoving)
                {
                    StartCoroutine(MoveCameraToPosition(lineStart));
                }
            }
            // �����ʿ��� �������� �巡���ϴ� ���
            else if (dragDirection.x < 0)
            {
                if (!isCameraMoving)
                {
                    StartCoroutine(MoveCameraToPosition(lineEnd));
                }
            }
        }
    }

    // ī�޶� ��ǥ ��ġ�� �ε巴�� �̵���Ű�� �ڷ�ƾ
    IEnumerator MoveCameraToPosition(Vector3 targetPosition)
    {
        isCameraMoving = true;
        Vector3 initialPosition = transform.position;
        float journeyLength = Vector3.Distance(initialPosition, targetPosition);
        float startTime = Time.time;

        while (isCameraMoving)
        {
            float distanceCovered = (Time.time - startTime) * dragSpeed;
            float journeyFraction = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, journeyFraction);

            if (journeyFraction >= 1.0f)
            {
                // �̵��� �Ϸ�Ǹ� �̵� �÷��� ����
                isCameraMoving = false;
            }

            yield return null;
        }
    }
}
