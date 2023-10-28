using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Onhover : MonoBehaviour
{
    [Space(10)] [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sound_click;
    [SerializeField] AudioClip sound_hover;
    public Image buttonImage;
    public Sprite normalSprite; // ���� �̹���
    public Sprite hoverSprite; // ���콺 ȣ�� �ÿ� ������ �̹���
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void UIClick()
    {
        audioSource.PlayOneShot(sound_click);
        buttonImage.sprite = normalSprite;
    }


    public void OnMouseOver()
    {
        buttonImage.sprite = hoverSprite; // ���콺�� ��ư ���� ���� �� �̹����� �ٲߴϴ�.
        audioSource.PlayOneShot(sound_hover);
    }

    public void OnMouseExit()
    {
        buttonImage.sprite = normalSprite; // ���콺�� ��ư���� �������� �� �̹����� �����մϴ�.
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
