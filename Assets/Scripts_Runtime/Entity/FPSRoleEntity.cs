using System;
using UnityEngine;

namespace Shooting3DTutorial {

    public class FPSRoleEntity : MonoBehaviour {

        [SerializeField] Transform body;

        void Awake() {
            // Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            byte light = 0b00000000;
            light |= 1 << 0;
            light |= 1 << 4;

            // 0b00010001 light
            // 0b00000001 1灯
            if ((light & (1 << 0)) != 0) {
                Debug.Log("0");
            }
            if ((light & (1 << 1)) != 0) {
                Debug.Log("1");
            }

        }

        public void Tick(float dt) {
            // 旋转: 身子
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            float rotSpeed = 400;
            body.Rotate(Vector3.up, x * rotSpeed * dt);

            // 发射
            if (Input.GetMouseButtonDown(0)) {
                // 检测击中
                float bulletSpeed = 100; // 100m/s
                float bulletFlyDistance = MaxBulletDistance(bulletSpeed);

                Camera cam = Camera.main;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                int layerMask = 0b00000000_00000000_00000000_00000000;
                // layerMask |= (1 << 0); // 0b00000000_00000000_00000000_00001000
                layerMask |= (1 << 3); // 0b00000000_00000000_00000000_00001000
                layerMask |= (1 << 7); // 0b00000000_00000000_00000000_10001000
                bool hasHit = Physics.Raycast(ray, out RaycastHit hit, bulletFlyDistance, layerMask);
                if (hasHit) {
                    GameObject target = hit.collider.gameObject;
                    Debug.Log("Hit: " + target.name);
                    GameObject.Destroy(target);
                }
            }

        }

        float MaxBulletDistance(float bulletSpeed) {
            return bulletSpeed;
        }

    }

}