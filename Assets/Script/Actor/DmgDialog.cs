using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DmgDialog : MonoBehaviour
{

    public GameObject damageTextPrefab; // Gắn prefab TMP text
    public TextMeshProUGUI textDialog;
    public GameObject Canvas;
    public Vector3 Position;
    private void Start()
    {
        ObserverManager.AddListener<Vector3>("ShowDamage", PositionSetup);
        ObserverManager.AddListener<int>("ShowDamage", ShowDamage);


    }
    public void PositionSetup(Vector3 position)
    {

        Position = Camera.main.WorldToScreenPoint(position);

    }


    public void ShowDamage(int damage)
    {
        Debug.Log(damage);
        GameObject damageObj = Instantiate(damageTextPrefab);
        damageObj.transform.SetParent(Canvas.transform);
        damageObj.transform.position = Position; // offset bay lên
        textDialog = damageObj.GetComponent<TextMeshProUGUI>();
        textDialog.text = damage.ToString();

        // Gợi ý: Thêm hiệu ứng fade + bay lên
        // Destroy(damageObj, 1.0f);
    }
    private void OnDestroy()
    {
        ObserverManager.RemoveListener<Vector3>("ShowDamage", PositionSetup);

        ObserverManager.RemoveListener<int>("ShowDamage", ShowDamage);

    }
    private void OnDisable()
    {
        ObserverManager.RemoveListener<Vector3>("ShowDamage", PositionSetup);

        ObserverManager.RemoveListener<int>("ShowDamage", ShowDamage);

    }


}
