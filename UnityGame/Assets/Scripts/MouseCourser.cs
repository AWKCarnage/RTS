using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCourser : MonoBehaviour
{
    public Camera screenCam;
    public GameObject testObject;
    public GameObject testCube;
    private Vector3 m_StartPoint, m_EndPoint, m_Size, m_Center;
    private GameObject tempBox;
    public LayerMask layerMask;
    private List<GameObject> m_SelectedAllies = new List<GameObject>();
    [SerializeField] GameObject highlightedIcon;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        MouseInput();
    }

    //TODO need to add  a layer here
    //TODO
    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = screenCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                m_StartPoint = hit.point;
                tempBox = Instantiate(testCube, hit.point, Quaternion.identity);
            }
        }

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = screenCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                m_EndPoint = hit.point;
                Debug.DrawLine(m_StartPoint, m_EndPoint, Color.green, 0.1f);
                GetHighlightedSize();
                m_Center = ((m_StartPoint + m_EndPoint) / 2);
                tempBox.transform.position = m_Center;
                tempBox.transform.localScale = m_Size;

            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = screenCam.ScreenPointToRay(Input.mousePosition);
            Destroy(tempBox);
            if (Physics.Raycast(ray, out hit))
            {
                m_EndPoint = hit.point;
                m_Center = ((m_StartPoint + m_EndPoint) / 2);
                Collider[] m_testing = Physics.OverlapBox(m_Center, m_Size / 2);

                foreach (var item in m_testing)
                {
                    if (item.gameObject.tag == "Ally")
                    {
                        Instantiate(highlightedIcon, item.transform.position + Vector3.up, Quaternion.identity, item.transform);
                        m_SelectedAllies.Add(item.gameObject);
                    }
                }
            }
        }
        ClearSelectedList();

    }
    private void GetHighlightedSize()
    {
        m_Size = new Vector3(Mathf.Abs(m_StartPoint.x - m_EndPoint.x), 1f, Mathf.Abs(m_StartPoint.z - m_EndPoint.z));

    }
    private void ClearSelectedList()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && m_SelectedAllies.Count > 0)
        {
            foreach (var ally in m_SelectedAllies)
            {
                foreach (Transform child in ally.transform)
                {
                    if (child.gameObject.name.Contains("Selected"))
                    {
                        Destroy(child.gameObject);

                    }
                }
            }
            m_SelectedAllies.Clear();
        }
    }


}
