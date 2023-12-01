using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClikControll : MonoBehaviour
{
    public GameObject Win;
    public Camera _camera;
    private List<string> HiddenObj;
    public List<Text> txt_Obj;
    private List<string> inThisMoment;
    public GameObject[] objects;
    void Start() {
        HiddenObj = new List<string>();
        objects = GameObject.FindGameObjectsWithTag("HiddenObj");
        System.Random rand = new System.Random();
        for (int i = objects.Length - 1; i >= 0; --i) {
            int j = rand.Next(i + 1);
            GameObject t = objects[j];
            objects[j] = objects[i];
            objects[i] = t;
        }
        NameObj no;
        for (int i = 0; i < 15; ++i) {
            no = objects[i].GetComponent<NameObj>();
            HiddenObj.Add(no.Hidname);
        }
        inThisMoment = HiddenObj.GetRange(0,7);
    }
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
            {
                GameObject hitObject = GetNodeFromScreen(Input.mousePosition);
                if (hitObject != null)
                {
                    NameObj no = hitObject.GetComponent<NameObj>();
                    if (no.isName(inThisMoment))
                    {
                        HiddenObj.Remove(no.Hidname);
                        Destroy(hitObject);
                        int KolObg = (HiddenObj.Count > 7) ? 7 : HiddenObj.Count;
                        inThisMoment = HiddenObj.GetRange(0, KolObg);
                    }
                }
       }
    }
    void LateUpdate() {
        if (HiddenObj.Count == 0) Win.SetActive(true);
        int n = (txt_Obj.Count > HiddenObj.Count) ? HiddenObj.Count : txt_Obj.Count;
        for (int i=0; i < n; ++i) {
            txt_Obj[i].text = HiddenObj[i];
        }
        for (int i=n; i < txt_Obj.Count; ++i) {
            txt_Obj[i].text = "";
        }
    }
    private GameObject GetNodeFromScreen(Vector3 screenPosition)
    {
        GameObject node=null;
        Ray ray = _camera.ScreenPointToRay(screenPosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach (RaycastHit h in hits)
        {
            if (!h.collider.CompareTag("HiddenObj"))// && !h.collider.CompareTag(obstacleTag))
                continue;
            node = h.collider.gameObject;
            break;
        }
        return node;
    }
}
