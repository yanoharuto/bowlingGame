using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    // Ringを全部取得
    [Header("Ringを全部入れる")] 
    [SerializeField] GameObject[] Rings;

    // 差の最小と最大を決める
    [Header("Ring取得時のPlayerとの最小差")]
    [SerializeField] Vector3 betweenMin;
    [Header("Ring取得時のPlayerとの最大差")]
    [SerializeField] Vector3 betweenMax;
    public bool isGetRingPerfect { get; private set; }
    // 座標差保存変数
    Vector3 preservation;

    // リング取得数保持
    public int counter { get; private set; } = 0;
    public int allRings { get; private set; }

    // シーン切り替えのために取得
    ScenesTransition m_ScenesTransition;

    // Start is called before the first frame update
    void Start()
    {
        preservation = Vector3.zero;
        m_ScenesTransition = new ScenesTransition();
        allRings = Rings.Length;
    }

    // Update is called once per frame
    void Update()
    {
        counter = 0;
        for (int i = 0; i < Rings.Length; i++)
        {
            // Ringがアクティブじゃなければ飛ばす
            if (Rings[i].activeSelf != false)
            {
                // 差分を取得
                preservation = Rings[i].transform.position - this.transform.position;


                // 差の範囲内であれば
                if (betweenMax.x >= preservation.x && preservation.x >= betweenMin.x &&
                    betweenMax.y >= preservation.y && preservation.y >= betweenMin.y &&
                    betweenMax.z >= preservation.z && preservation.z >= betweenMin.z)
                {
                    Debug.Log("active false");
                    Debug.Log(Rings[i]);
                    // ノンアクティブ化
                    Rings[i].SetActive(false);
                }
            }
            else
            {
                counter++;
                if (counter == Rings.Length)
                {
                    isGetRingPerfect = true;
                }
            }
        }
    }
}