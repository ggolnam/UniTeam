using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum IconType//요건 나중에 여건이 되면 합시다....ㅠㅠ...
{
    NormalEnmey = 0,
    NamedEnemy = 1
}

[System.Serializable]
public class Icon
{
    public Image IconImage;
    public GameObject OwnerObject;

    //public Icon(Image iconImage, GameObject ownerObject)
    //{
    //    IconImage = iconImage;
    //    OwnerObject = ownerObject;
    //}
}

public class MinimapPresenter : MonoBehaviour
{
    [SerializeField]
    private List<Icon> icons = new List<Icon>();
    [SerializeField]
    private Image parentImage;

    private const int NumberOfEnemyIcons = 2;
    private const int NumberOfNamedEnemys = 10;

    private void Awake()
    {
        
        parentImage.transform.position = RegistParent(parentImage);
        

        icons = RegistIcons(icons, "폴더 및 이미지이름", "오너 이름 및 폴더", NumberOfEnemyIcons);
        //RegistIcons(icons, "리소스 폴더 및 이미지이름", "오너 이름 및 폴더", NumberOfNamedEnemys); //여유나면 합시다... ㅠㅠ

    }

    private Vector3 RegistParent(Image parent)
    {
        parent.enabled = false;

        return parent.transform.position;
    }

    private List<Icon> RegistIcons(List<Icon> icons, string imageName, string ownerName, int numberOfEnemy)
    {
        Image image = Resources.Load("이미지 이름") as Image;
        GameObject owner = Resources.Load("오너 이름") as GameObject;

        for (int i = 0; i < numberOfEnemy; i++)
        {
            //리소스에있는 자원을 등록한다.
            
            icons[i].IconImage = image;
            icons[i].OwnerObject = owner;
            icons[i].IconImage.transform.SetParent(parentImage.transform);
        }

        return icons;
    }
    
}
