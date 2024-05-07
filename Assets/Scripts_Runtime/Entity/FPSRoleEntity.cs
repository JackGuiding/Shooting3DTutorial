using System;
using UnityEngine;

namespace Shooting3DTutorial {

    public class FPSRoleEntity : MonoBehaviour {

        [SerializeField] Transform body;

        void Awake() {
            // Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
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
                int layerMask = 1 << 0;
                bool hasHit = Physics.Raycast(ray, out RaycastHit hit, bulletFlyDistance, layerMask);
                if (hasHit) {
                    GameObject target = hit.collider.gameObject;
                    GameObject.Destroy(target);
                }
            }

        }

        float MaxBulletDistance(float bulletSpeed) {
            return bulletSpeed;
        }

    }

}