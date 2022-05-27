using UnityEngine;
using UnityEngine.UI;


public class Drag : MonoBehaviour
{
    private Vector3 pointScreen;
    private Text BlueText;
    private Text RedText;
    static private int blueCNT;
    static private int redCNT;
    static public int allCNT;//������� ���������� �����
    private bool allowDragging;//����� �� ������ ������������� ��������

    void Start()
    {
        blueCNT = 0;
        redCNT = 0;
        BlueText = GameObject.Find("BlueText").GetComponent<Text>();
        BlueText.text = blueCNT.ToString();
        RedText = GameObject.Find("RedText").GetComponent<Text>();
        RedText.text = redCNT.ToString();
    }
    private void Update()
    {
        if (gameObject.transform.position.y < -1)
        {
            transform.position = new Vector3(0, 1, 4);
            allowDragging = false;
        }
    }
    void OnMouseDown()
    {
        allowDragging = true;
        pointScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    }

    void OnMouseDrag()
    {
        if (allowDragging)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            transform.position = curPosition;

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //�������� �� ������� �� ������
        if (other.gameObject.tag == "Wall")
        {
            //�������� �� ���� ��������� � �������� �������
            if (gameObject.tag == (other.gameObject.ToString()).Split(' ')[0])//���� ����� ���������
            {
                Destroy(gameObject);

                if (gameObject.tag == "Blue")//���� ��� �����
                {
                    blueCNT++;
                    allCNT--;
                    BlueText.text = blueCNT.ToString();
                }
                else//���� ��� �������
                {
                    redCNT++;
                    allCNT--;
                    RedText.text = redCNT.ToString();
                }

                if (allCNT == 0) //���� ���� ���������
                {
                    FindObjectOfType<EndGame>().GameOver();
                }
             }
            else//����� -> ����� �� �������� ��� ��� ���
            {
                allowDragging = false;//�������� �������� ��� �����
                                      //����� ����������� Rigidbody.AddForce �� �������������
                                      //������ �������� �� ���� ���������� ������ Unity
            }
        }
    }
}
