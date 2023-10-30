    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text messageText;
    
    private bool isDisplayingMessage = false;

    private void Update()
    {
        // �޽����� ǥ�� ���̶�� Ÿ�̸Ӹ� ����
        if (isDisplayingMessage)
        {
            StartCoroutine(DisplayMessageForSeconds(3f)); // 3�� ���� �޽����� ǥ���մϴ�.
        }
    }

    public void ShowMessage()
    {
        messageText.text = "��������"; // ǥ���� �޽����� ���⿡ �Է�
        isDisplayingMessage = true;
    }

    IEnumerator DisplayMessageForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        messageText.text = ""; // �޽����� ����ϴ�.
        isDisplayingMessage = false;
    }   
}
