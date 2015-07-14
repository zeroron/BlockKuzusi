using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MyGame;
public class GameController : MonoBehaviour {
    private static GameObject ball;
    private static GameObject canvas;
    private static GameObject EndScreen;
    private static bool end = false;
    private static Text scoreText;
	// Use this for initialization
	void Start () {
        canvas = GameObject.Find("Canvas");
        ball = GameObject.Find("Sphere");
        EndScreen = (GameObject)Resources.Load("EndScreen");
        scoreText = GameObject.FindObjectOfType<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Block.ObjCount<=0) {
            setEnd(true);
        }
	
	}
    public static void getPoint()
    {
        int score;
        string[] str = scoreText.text.Split(':');
        score = int.Parse(str[1]) + 100;
        scoreText.text = str[0] + ":" + score;
    }
    public static void setEnd(bool win)
    {
        if (end == false)
        {
            GameObject screen;
            screen = Instantiate(EndScreen);  //プレハブからスクリーン生成
            screen.transform.SetParent(canvas.transform, false);  //canvasの子クラスに設定
            Text[] texts = screen.GetComponentsInChildren<Text>();  //プレハブの子クラスの中からText型のものを配列として取得
            foreach (Text text in texts)
            {
                if (text.tag == "judge")  //tagは後で設定するこれによってどれがどのテキストなのかを特定する
                {
                    if (win)
                    {
                        text.text = "CLEAR";
                    }
                    else
                    {
                        text.text = "FAILE";
                    }
                }
                if (text.tag == "score")
                {
                    string[] tmp = scoreText.text.Split(':');
                    text.text = "Score:" + tmp[1];
                }
            }
            Destroy(ball);
            Debug.Log("End");
            end = true;
        }
    }
}
