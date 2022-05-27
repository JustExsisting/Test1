using UnityEngine;
using UnityEngine.UI;


public class Drag : MonoBehaviour
{
    private Vector3 pointScreen;
    private Text BlueText;
    private Text RedText;
    static private int blueCNT;
    static private int redCNT;
    static public int allCNT;//счётчик оставшихся кубов
    private bool allowDragging;//можно ли игроку перетаскивать предметы

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
        //проверка на косание со стеной
        if (other.gameObject.tag == "Wall")
        {
            //проверка на цвет указанный в названии объекта
            if (gameObject.tag == (other.gameObject.ToString()).Split(' ')[0])//если цвета совпадают
            {
                Destroy(gameObject);

                if (gameObject.tag == "Blue")//если куб синий
                {
                    blueCNT++;
                    allCNT--;
                    BlueText.text = blueCNT.ToString();
                }
                else//если куб красный
                {
                    redCNT++;
                    allCNT--;
                    RedText.text = redCNT.ToString();
                }

                if (allCNT == 0) //если кубы кончились
                {
                    FindObjectOfType<EndGame>().GameOver();
                }
             }
            else//иначе -> цвета не сопадают или это пол
            {
                allowDragging = false;//забираем контроль над кубом
                                      //можно реализовать Rigidbody.AddForce по необходимости
                                      //сейчас работает за счёт встроенной физики Unity
            }
        }
    }
}
