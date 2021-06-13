using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    private void Start()
    {
        if (!SaveManager.hasSave())
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
