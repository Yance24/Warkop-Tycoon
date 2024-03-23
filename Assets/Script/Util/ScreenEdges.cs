using UnityEngine;

public class ScreenEdges{
        public float top;
        public float bottom;
        public float right;
        public float left;

        public float worldLeft{
            get{return Camera.main.ScreenToWorldPoint(new Vector2(0,0)).x;}
        }

        public float worldRight{
            get{return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,0)).x;}
        }

        public void getWorldCoordinates(){
            Vector2 leftBot = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
            Vector2 rightTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
            left = leftBot.x;
            bottom = leftBot.y;
            right = rightTop.x;
            top = rightTop.y;
        }

        public void showEdgeCoordinates(){
            Debug.Log("top = "+top);
            Debug.Log("bottom = "+bottom);
            Debug.Log("left = "+left);
            Debug.Log("right = "+right);
        }
    }
