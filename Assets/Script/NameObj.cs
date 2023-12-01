using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameObj : MonoBehaviour {

    public string Hidname;
    public bool isName(List<string>names) {
        return names.Contains(Hidname);
    }
}
