using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrayCupHandler : MonoBehaviour
{
    public TextMeshProUGUI menuName;
    public MenuParameter menuParameter;
    
    public Sprite coffeeSprite;
    public Sprite teaSprite;
    public int index;

    private Sprite defaultSprite;
    private Image image;

    void Awake(){
        image = GetComponent<Image>();
        defaultSprite = image.sprite;
        Debug.Log(defaultSprite);
    }

    public void setCup(MenuParameter menu, int index){
        menuParameter = menu;
        switch(menu.Type){
            case MenuParameter.MenuType.tea:
                image.sprite = teaSprite? teaSprite: defaultSprite;
                // Debug.Log("tea");
            break;

            case MenuParameter.MenuType.coffee:
                image.sprite = coffeeSprite? coffeeSprite: defaultSprite;
                // Debug.Log("coffee");
            break;

            default:
                image.sprite = defaultSprite;
            break;
        }
        this.index = index;
        menuName.text = menuParameter.name;
    }
}
