using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Craft
{
    public string craftName;//�̸�
    public GameObject go_Prefab;//���� ��ġ��  ������.
    public GameObject go_PreviewPrefab;//�̸����� ������
    public int[] craftNeedMP;
    
}
public class CraftManual : MonoBehaviour
{
    [Space(10)] [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip build_success;
    public Camera mainCamera;
    public Camera firstCamera;
    public Camera secondCamera;
    public Camera movingCamera;


    //camera�� ���缭 ���� �ϸ� �ɰͰ���/�ǹ� ���� -> �ǹ����� ������ ���� �������ٰ� �ֱ� -> ������ ��� & �ܰ����� fog -> �ڿ��� ���� == �ǹ� ���� (�ᱹ�� �̰� �ҷ��� turn ���� manager �� �־���)
    //����ȭ�� �ι� ���� ȭ�� -> 1�� ���� ȭ�� -> �¸� �й�ȭ��  -> AI �־��ֱ�
    // Start is called before the first frame update
    private bool isActivated = false;
    private bool isPreviewActivated = false;

    private int selectedSlotNumber;
    [SerializeField]
    private GameObject go_BaseUI;


    [SerializeField]
    private Craft[] craft_building;

    private GameObject go_Preview;//�̸����� ���� ����
    private GameObject go_Prefab; // ���� ������ �������� ���� ���� 
    //RayCast �ʿ� ���� ����
    private RaycastHit hitInfo;

     [SerializeField]
     private LayerMask layerMask;
    //private int layerMask;

    void Start()
    {
        
    }


    public void SlotClick(int _slotNumber)
    {
        Vector3 mousePositionScreen = Input.mousePosition;
        selectedSlotNumber = _slotNumber;
        // ���콺 ��ǥ�� ���� ��ǥ�� ��ȯ�մϴ�.
        var mousePos = Input.mousePosition;
        if (firstCamera.enabled)
        {
            mousePos.z = firstCamera.transform.position.y - 20;
            Vector3 mousePositionWorld = firstCamera.ScreenToWorldPoint(mousePos);
            go_Preview = Instantiate(craft_building[_slotNumber].go_PreviewPrefab, mousePositionWorld, Quaternion.identity);
        }
        else
        {
            mousePos.z = secondCamera.transform.position.y - 20;
            Vector3 mousePositionWorld = secondCamera.ScreenToWorldPoint(mousePos);
            go_Preview = Instantiate(craft_building[_slotNumber].go_PreviewPrefab, mousePositionWorld, Quaternion.identity);
        }
        
        go_Prefab = craft_building[_slotNumber].go_Prefab;
        isPreviewActivated = true;
        go_BaseUI.SetActive(false);
    }
    void Update()
    {
      
        //GetMouseCursorpos();
        if (movingCamera.enabled||TurnManager.instance.StartWar)
        {
            Cancel();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab)&&!isPreviewActivated)
            {
                Window();
            }
        }
        if (Input.GetButtonDown("Fire1"))
            Build();

        if (Input.GetKeyDown(KeyCode.Escape))
            Cancel();
        if (isPreviewActivated)
            PreviewPositionUpdate();
       
    }

    private void PreviewPositionUpdate()
    {
        Vector3 mousePositionScreen = Input.mousePosition;
        Vector3 mousePositionWorld;
    
        var mousePos = Input.mousePosition;

        if (firstCamera.enabled)
        {
            mousePos.z = firstCamera.transform.position.y - 20;
            mousePositionWorld = firstCamera.ScreenToWorldPoint(mousePos);
            
        }
        else
        {
            mousePos.z = secondCamera.transform.position.y-20;
            mousePositionWorld = secondCamera.ScreenToWorldPoint(mousePos);
        }

        if (Physics.Raycast(mousePositionWorld, Vector3.down, out hitInfo, Mathf.Infinity, layerMask))
        {
            Vector3 _location = hitInfo.point;
            //Debug.Log($"Raycast {hitInfo.collider.gameObject.name}");
            go_Preview.transform.position = _location;

        }   
    }
    private void Build()
    {
        if (isPreviewActivated && go_Preview.GetComponent<PreviewObject>().isBuildable())
        {
            if (PResourceManager.instance.MP - craft_building[selectedSlotNumber].craftNeedMP[0] >= 0)
            {
                PResourceManager.instance.MP = PResourceManager.instance.MP - craft_building[selectedSlotNumber].craftNeedMP[0];
                Instantiate(go_Prefab, hitInfo.point, Quaternion.identity);
                Destroy(go_Preview);
                audioSource.PlayOneShot(build_success);
                
                isActivated = false;
                isPreviewActivated = false;
                go_Preview = null;
                go_Prefab = null;
            }
            else
            {
                Debug.Log("���̾����ϴ�.");
                TurnManager.instance.DoNotHaveMoney();
                Destroy(go_Preview);
                isActivated = false;
                isPreviewActivated = false;
                go_Preview = null;
                go_Prefab = null;
            }
        }
    }
    public void Cancel()
    {
        if(isPreviewActivated)
            Destroy(go_Preview);
        isActivated = false;
        isPreviewActivated = false;
        go_Preview = null;

        go_BaseUI.SetActive(false);
    }
    private void Window()
    {
        if (!isActivated && (firstCamera.enabled||secondCamera.enabled))
            OpenWindow();
        else
            CloseWindow();
    }
    private void OpenWindow()
    {
        isActivated = true;
        go_BaseUI.SetActive(true);
    }
    private void CloseWindow()
    {
        isActivated = false;
        go_BaseUI.SetActive(false);
    }
}
