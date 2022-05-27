using UnityEngine;

public class StartGame : MonoBehaviour
{
    private GameObject endGameUI;

    void Start()
    {
        endGameUI = GameObject.Find("EndGameUI");
        //endGameUI.SetActive(false);

        int rndcount = Random.Range(5, 15);//генерация случайного числа от 5 до 15

        for (int i = 0; i < rndcount; i++)//цикл для спавна кубов
        {
            float rndcolor = Random.Range(0f, 100f);//генерация случайного "цвета"

            if (rndcolor <= 50)
            {
                CubeSpawn("BlueCube");
            }
            else
            {
                CubeSpawn("RedCube");
            }
            Drag.allCNT = rndcount;//запись количества кубов
        }
    }

    void CubeSpawn(string cubeName)
    {
        float rndX = Random.Range(-3f, 1f);
        float rndY = Random.Range(0.1f, 8.5f);
        float rndZ = Random.Range(5f, 10f);

        GameObject newTarget = Instantiate(Resources.Load(cubeName), new Vector3(rndX, rndY, rndZ), Quaternion.identity) as GameObject;
    }
}
