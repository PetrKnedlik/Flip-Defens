using UnityEngine;

public class SideBar : MonoBehaviour
{
    public static bool sidebarVisible = false;
    public GameObject sidebarMenu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (sidebarVisible)
            {
                showSidebar();
            }
            else
            {
                hideSidebar();
            }
        }

        void showSidebar()
        {
            if (sidebarMenu != null)
            {
                sidebarMenu.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Sidebar instance reference is null.");
            }
            sidebarVisible = false;
        }

        void hideSidebar()
        {
            if (sidebarMenu != null)
            {
                sidebarMenu.SetActive(true);
            }
            sidebarVisible = true;
        }
    }
}
