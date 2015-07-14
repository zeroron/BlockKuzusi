using UnityEngine;
using System.Collections;
//using UnityEngine.UI;
namespace MyGame
{
    public class Block : MonoBehaviour
    {
        //public Text scoreText;
        public static int ObjCount = 0;

        public void Awake()
        {
            ObjCount++;
        }

        void OnCollisionEnter(Collision collision)
        {
            GameController.getPoint(); //以下の動作をGameControllerに定義する
            /*string[] str;
            int score;
            str = scoreText.text.Split(':');
            score = int.Parse(str[1]) + 100;
            scoreText.text = str[0] + ":" + score;
            */
            ObjCount--;
            Debug.Log(ObjCount);

            Destroy(gameObject);
        }

    }
}