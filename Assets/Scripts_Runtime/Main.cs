using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooting3DTutorial {

    public class Main : MonoBehaviour {

        public int status; // 0 TRS, 1 FPS

        [SerializeField] TPSRoleEntity tpsRole;
        [SerializeField] FPSRoleEntity fpsRole;

        void Start() {
            Debug.Log("Hell");
        }

        void Update() {
            float dt = Time.deltaTime;
            if (status == 0) {
                TPSTick(dt);
            } else if (status == 1) {
                FPSTick(dt);
            }
        }

        void TPSTick(float dt) {
            tpsRole.Tick(dt);
        }

        void FPSTick(float dt) {
            fpsRole.Tick(dt);
        }

    }
}
