using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI tHp;

    Transform[] tr;
    int dir = 0;
    int hp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //tHp.text = hp.ToString();
        if (dir == 0 && Mathf.Abs(tr[dir].position.y - this.transform.position.y) < 0.01f)
        {
            dir++;
        }
        else if (dir == 1 && Mathf.Abs(tr[dir].position.x - this.transform.position.x) < 0.01f)
        {
            dir++;
        }
        else if (dir == 2 && Mathf.Abs(tr[dir].position.y - this.transform.position.y) < 0.01f)
        {
            DefenceManager.Instance.SetLife(-1);
            Destroy(this.gameObject);
        }
        this.transform.Translate(Time.deltaTime * (tr[dir].position-this.transform.position).normalized);
    }

    public void Init(Transform[] _tr, int _hp)
    {
        tr = _tr;
        hp = _hp;
    }
}
