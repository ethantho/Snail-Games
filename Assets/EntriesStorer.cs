using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EntriesStorer : MonoBehaviour
{
    [SerializeField] int numEntries;
    [SerializeField] TextMeshProUGUI prefab;
    // Start is called before the first frame update
    public TextMeshProUGUI[] _entryFields;
    void Start()
    {
        _entryFields = new TextMeshProUGUI[numEntries];
        for(int i = 0; i < numEntries; ++i)
        {
            _entryFields[i] = Instantiate(prefab);
            _entryFields[i].transform.position = new Vector2(_entryFields[i].transform.position.x, -20f * i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
