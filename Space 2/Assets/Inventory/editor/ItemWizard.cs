using System.Collections;
using UnityEditor;
using UnityEngine;
//https://www.youtube.com/watch?v=eZJddMsTDf8&t=1223s
public class ItemWizard : ScriptableWizard //erstellt einen Itemeditor um Items erstellen und bearbeiten zu können
{
    public string itemName;
    [MenuItem("Assets/Inventory/Item Wizard")] //Zugriff durch "Assets" Reiter
   public static void CreateItemWizard() //erstellen des Wizards
    {
         ScriptableWizard.DisplayWizard<ItemWizard>("Item Wizard", "Create Item");
    }
   void OnWizardCreate()
    {
        if (itemName == null || itemName.Length < 1) // überprüfen des richtigen Namens
        {
            EditorUtility.DisplayDialog("Item WIzard", "Please give this new item a nice name.", "Ok");
            return;
        }
        Item item = ScriptableObject.CreateInstance<Item>(); //item wird erstellt
        item.itemName = itemName;     // name des prefab item wird vom Wizard übernommen
        AssetDatabase.CreateAsset(item, "Assets/Inventory/Resources/Items/" + itemName + ".asset"); //item wird im Pfad als Asset gespeichert
    }

}
