using System.Collections.Generic;
using UnityEngine;

public class NotaDataManager : MonoBehaviour
{
    public static NotaDataManager Instance { get; private set;}

    [SerializeField]
    private GameObject minimizedNota;
    [SerializeField]
    private GameObject maximizedNota;

    [SerializeField]
    private int maximumNota;

    private NotaDataBuffer currentPickedMenu;

    public NotaDataBuffer BufferedNota{
        get{return currentPickedMenu;}
    }

    public class NotaDataBuffer{
        public List<MenuParameter> menu;
    }

    private List<NotaDataBuffer> notaBuffers = new List<NotaDataBuffer>();

    public List<NotaDataBuffer> NotaBuffers{
        get{return notaBuffers;}
    }

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    void OnEnable(){
        displayMinimizedMenu();
    }

    public void writeMenu(List<MenuParameter> menus){
        NotaDataBuffer buffer = new NotaDataBuffer{menu = menus};
        notaBuffers.Add(buffer);
        currentPickedMenu = buffer;
        displayMaximizedMenu();
    }

    public void showMenu(int index){
        currentPickedMenu = notaBuffers[index];
        displayMaximizedMenu();
    }

    public bool isMaxed(){
        return NotaBuffers.Count >= maximumNota;
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
