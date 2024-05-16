using System.Collections.Generic;
using UnityEngine;

public class NotaDataManager : MonoBehaviour
{
    public static NotaDataManager Instance { get; private set;}

    [SerializeField]
    private GameObject minimizedNota;
    [SerializeField]
    private GameObject maximizedNota;

    private NotaDataBuffer currentPickedMenu;

    public NotaDataBuffer BufferedNota{
        get{return currentPickedMenu;}
    }

    public class NotaDataBuffer{
        public List<MenuParameter> menu;
    }

    private List<NotaDataBuffer> notaBuffers = new List<NotaDataBuffer>();


    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    public void writeMenu(List<MenuParameter> menus){
        NotaDataBuffer buffer = new NotaDataBuffer{menu = menus};
        notaBuffers.Add(buffer);
        currentPickedMenu = buffer;
        displayMaximizedMenu();
    }

    public void displayMinimizedMenu(){
        maximizedNota.SetActive(false);
        minimizedNota.SetActive(true);
    }

    public void displayMaximizedMenu(){
        minimizedNota.SetActive(false);
        maximizedNota.SetActive(true);
    }
}
