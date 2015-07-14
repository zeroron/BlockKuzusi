using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MyGame;
namespace MyGame
{
    public class GameControllerDumy : MonoBehaviour
    {
        public Text scoreText;
        private int scorePoint = 0;
        private bool end = false;
        [SerializeField] private GameObject canvas;
        [SerializeField] private GameObject EndScreen;
        [SerializeField] private GameObject ball;
        //シングルトンパターン(ゲーム上に唯一になるものに多く使われる)
        private static GameControllerDumy mInstance;
        public static GameControllerDumy Instance
        {
            get
            {
                if (mInstance == null)
                {
                    return GameControllerDumy.mInstance;
                }
                return mInstance;
            }
        }
        void Awake()
        {
            if (mInstance == null)
            {
                mInstance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (BlockDumy.ObjCount <= 0) //ブロックの数がゼロ
            {
                setEnd(true);
            }
        }

        public void getPoint()
        {
            string[] str;
            str = scoreText.text.Split(':');
            scorePoint = int.Parse(str[1]) + 100;
            scoreText.text = str[0] + ":" + scorePoint;
        }

        public void setEnd(bool win)
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
                        text.text = "Score:" + scorePoint;
                    }
                }
                Destroy(ball);
                Debug.Log("End");
                end = true;
            }
        }

    }
}