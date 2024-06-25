using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public static class WorldTransform
{
    public static Vector2 convertToLocalPosition(Vector2 globalPosition, Transform parent){

        return new Vector2();
    }

    // private Vector2 

    public static Quaternion convertToLocalRotation(Quaternion globalRotation, Transform parent){
        Quaternion parentRotation = parent.localRotation;

        do{
            if(parent.parent){
                parent = parent.parent;
                parentRotation *= parent.localRotation;
            }else{
                parent = null;
            }
        }while(parent);

        Quaternion localRotation = globalRotation * Quaternion.Inverse(parentRotation);

        return localRotation;
    }

    public static Vector2 convertToLocalScale(Vector2 globalScale, Transform parent){
        Vector2 parentScales = parent.localScale;

        do{
            if(parent.parent){
                parent = parent.parent;
                parentScales = Vector2.Scale(parentScales,parent.localScale);
            }else{
                parent = null;
            }
        }while(parent);

        Vector2 localScale = new Vector2(
            globalScale.x / parentScales.x,
            globalScale.y / parentScales.y
        );

        return localScale;
    }
}