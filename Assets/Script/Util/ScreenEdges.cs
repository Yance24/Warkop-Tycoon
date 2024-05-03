using UnityEngine;

public class ScreenEdges{
    public float Left{
        get{return Camera.main.ScreenToWorldPoint(new Vector2(0,0)).x;}
    }
    public float Right{
        get{return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,0)).x;}
    }
    public float Bot{
        get{return Camera.main.ScreenToWorldPoint(new Vector2(0,0)).y;}
    }
    public float Top{
        get{return Camera.main.ScreenToWorldPoint(new Vector2(0,Screen.height)).y;}
    }
    public float Width{
        get{return Right - Left;}
    }
    public float Height{
        get{return Top - Bot;}
    }
}
