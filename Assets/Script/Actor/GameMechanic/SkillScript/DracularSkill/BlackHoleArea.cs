using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleArea : MonoBehaviour
{
    public float effectRadius = 5f;        // Bán kính vùng skill
    public float pullSpeed = 30f;           // Tốc độ hút vào trung tâm
    public float pushSpeed = 20f;           // Tốc độ đẩy ra
    public float duration = 5f;            // Thời gian tồn tại của vùng skill
    public Animator animator;

    public List<Rigidbody2D> objectsInArea = new List<Rigidbody2D>(); // Danh sách các đối tượng trong vùng skill
    private Vector3 skillCenter;           // Trung tâm của vùng skill
    private bool isPulling = true;
    private Action PullPush;  // Cờ để kiểm tra đang hút hay đẩy

    private void Start()
    {
        skillCenter = transform.position;  // Xác định vị trí trung tâm của vùng skill
        StartCoroutine(EffectDuration());
        PullPush += MechanicBlackHole;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem đối tượng có phải là "Enemy" hoặc có Rigidbody2D không
        if (other.CompareTag("Enemy") && other.attachedRigidbody != null)
        {
            objectsInArea.Add(other.attachedRigidbody); // Thêm object vào danh sách
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && other.attachedRigidbody != null)
        {
            objectsInArea.Add(other.attachedRigidbody); // Thêm object vào danh sách
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && other.attachedRigidbody != null)
        {
            objectsInArea.Remove(other.attachedRigidbody); // Xóa object khỏi danh sách khi rời khỏi vùng
        }
    }

    private void Update()
    {

        PullPush?.Invoke();
    }
    public void MechanicBlackHole()
    {
        if (isPulling)
        {
            // Hút các đối tượng vào trung tâm của skill
            foreach (var obj in objectsInArea)
            {
                Vector2 direction = (skillCenter - obj.transform.position).normalized;
                obj.velocity = direction * pullSpeed; // Thực hiện hút đối tượng
            }
        }
        else
        {
            // Đẩy các đối tượng ra khỏi trung tâm sau khi 3 giây
            foreach (var obj in objectsInArea)
            {
                Debug.Log(obj.name);
                Vector2 direction = (obj.transform.position - skillCenter).normalized;
                obj.velocity = direction * pushSpeed; // Thực hiện đẩy đối tượng ra
            }
        }
    }


    private IEnumerator EffectDuration()
    {
        yield return new WaitForSeconds(duration);  // Đợi 3 giây
        isPulling = false;  // Bắt đầu đẩy các đối tượng ra
        yield return new WaitForSeconds(0.5f); // Đẩy ra trong 1 giây, có thể thay đổi thời gian đẩy tùy ý
        PullPush -= MechanicBlackHole;
        foreach (var obj in objectsInArea)
        {
            Debug.Log(obj.name);
            obj.velocity = Vector3.zero;
        }
        objectsInArea.Clear();
        Destroy(gameObject);



        // Sau khi đẩy xong, xóa tất cả các đối tượng trong vùng

    }
}
