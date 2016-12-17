using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Scripts.Epic2
{
    public class Crane : MonoBehaviour
    {
        enum State
        {
            ShipInit,
            Input,
            Move,
            TakeContainer,
            TakeContainerProgress,
            DropContainer,
            DropContainerProgress,
        }

        // additional secondes for eacht layer, half of it for the first
        [Tooltip("Secondes for each layer, half of it for the first")]
        public float grabSpeed = 2;

        // units per sec
        [Tooltip("Units per seconde")]
        public float moveSpeed = 100;

        private State state;

        public Ship targetShip;

        public Transform crane;
        public Transform cab;
        public Transform cable;
        public Transform attatchPoint;

        private Vector3 target;
        private Vector3 targetPosition;

        private bool hasLoad;

        private float progress = 0;

        private void Start()
        {

        }

        private void Update()
        {
            var containers = targetShip.containers;
            var containersTopLayer = containers[0];
            
            switch (state)
            {
                case State.ShipInit:
                    if (Vector3.Distance(targetShip.transform.localPosition, Vector3.zero) > 0.1f)
                        break;

                    target.x = containersTopLayer.IndexOf(containersTopLayer.Aggregate((x, y) => Math.Abs(x[0].position.z - crane.position.z) < Math.Abs(y[0].position.z - crane.position.z) ? x : y));
                    target.y = containersTopLayer[0].Count;

                    state = State.Input;
                    break;
                case State.Input:
                    if (Input.GetKey(KeyCode.Space))
                    {
                        state = (hasLoad) ? State.DropContainer : State.TakeContainer;
                        break;
                    }

                    var oldTarget = target;

                    target.x += (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) ? 1 : 0;
                    target.x -= (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) ? 1 : 0;

                    target.y -= (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) ? 1 : 0;
                    target.y += (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) ? 1 : 0;

                    if (target != oldTarget)
                    {
                        target.x = Mathf.Clamp(target.x, 0, containersTopLayer.Count - 1);
                        target.y = Mathf.Clamp(target.y, 0, containersTopLayer[0].Count);

                        if (hasLoad)
                        {
                            if (oldTarget.y < containersTopLayer[0].Count && containersTopLayer[(int)target.x][(int)oldTarget.y].childCount != 0)
                                target.x = oldTarget.x;
                            if (target.y < containersTopLayer[0].Count && containersTopLayer[(int)oldTarget.x][(int)target.y].childCount != 0)
                                target.y = oldTarget.y;
                            if (target.y < containersTopLayer[0].Count && containersTopLayer[(int)target.x][(int)target.y].childCount != 0)
                                target.y = oldTarget.y;
                        }

                        // Crane
                        targetPosition.x = crane.parent.InverseTransformPoint(containersTopLayer[(int)target.x][0].position).x;

                        // Cab
                        targetPosition.z = ((target.y < containersTopLayer[0].Count) ? cab.parent.InverseTransformPoint(containersTopLayer[(int)target.x][(int)target.y].position).z : 0)
                            - cab.InverseTransformPoint(attatchPoint.position).z;

                        state = State.Move;
                        break;
                    }
                    break;
                case State.Move:
                    var delta = new Vector2(targetPosition.x - crane.localPosition.x, targetPosition.z - cab.localPosition.z);

                    if (delta.magnitude <= Time.deltaTime * moveSpeed)
                    {
                        crane.localPosition = new Vector3(
                            targetPosition.x,
                            crane.localPosition.y,
                            crane.localPosition.z);
                        cab.localPosition = new Vector3(
                            cab.localPosition.x,
                            cab.localPosition.y,
                            targetPosition.z);
                        state = State.Input;

                    }
                    else
                    {
                        delta = delta.normalized * Time.deltaTime * moveSpeed;
                        crane.localPosition = new Vector3(
                            crane.localPosition.x + delta.x,
                            crane.localPosition.y,
                            crane.localPosition.z);
                        cab.localPosition = new Vector3(
                            cab.localPosition.x,
                            cab.localPosition.y,
                            cab.localPosition.z + delta.y);
                    }
                    break;
                case State.TakeContainer:
                    if (target.y >= containersTopLayer[0].Count)
                    {
                        state = State.Input;
                        break;
                    }

                    target.z = -1;
                    for (int layer = 0; layer < containers.Count; ++layer)
                    {
                        if (containers[layer][(int)target.x][(int)target.y].childCount > 0)
                        {
                            target.z = layer;
                            break;
                        }
                    }

                    if (target.z != -1)
                    {
                        progress = 0;
                        targetPosition.y = cable.parent.InverseTransformPoint(containers[(int)target.z][(int)target.x][(int)target.y].position).y - cable.InverseTransformPoint(attatchPoint.position).y;
                        state = State.TakeContainerProgress;
                        break;
                    }

                    state = State.Input;
                    break;
                case State.TakeContainerProgress:
                    {
                        var t = Time.deltaTime / ((target.z + 0.5f) * grabSpeed) * Mathf.PI;
                        progress += t;

                        var s1 = Mathf.Sin(progress);
                        var s2 = Mathf.Sin(progress + t);

                        var pos = cable.localPosition;
                        pos.y = Mathf.Max(s1, 0) * targetPosition.y;
                        cable.localPosition = pos;

                        if (!hasLoad && s2 < s1)
                        {
                            hasLoad = true;
                            containers[(int)target.z][(int)target.x][(int)target.y].GetChild(0).parent = attatchPoint;
                            attatchPoint.GetChild(0).localPosition = Vector3.zero;
                        }

                        if (s1 <= 0)
                            state = State.Input;

                        break;
                    }
                case State.DropContainer:
                    if (target.y >= containers.Count)
                    {
                        target.z = containers.Count;
                        // TODO bepaal kade hoogte
                        targetPosition.y = cable.parent.InverseTransformPoint(containers[containers.Count - 1][0][0].position).y - cable.InverseTransformPoint(attatchPoint.position).y;
                    }
                    else
                    {
                        for (int layer = containers.Count - 1; layer >= 0 ; --layer)
                        {
                            if (containers[layer][(int)target.x][(int)target.y].childCount == 0)
                            {
                                target.z = layer;
                                targetPosition.y = cable.parent.InverseTransformPoint(containers[(int)target.z][(int)target.x][(int)target.y].position).y - cable.InverseTransformPoint(attatchPoint.position).y;
                                break;
                            }
                        }
                    }

                    progress = 0;
                    state = State.DropContainerProgress;

                    break;
                case State.DropContainerProgress:
                    {
                        var t = Time.deltaTime / ((target.z + 0.5f) * grabSpeed) * Mathf.PI;
                        progress += t;

                        var s1 = Mathf.Sin(progress);
                        var s2 = Mathf.Sin(progress + t);

                        var pos = cable.localPosition;
                        pos.y = Mathf.Max(s1, 0) * targetPosition.y;
                        cable.localPosition = pos;

                        if (hasLoad && s2 < s1)
                        {
                            hasLoad = false;
                            if (target.z == containers.Count)
                            {
                                // TODO plaats op kade
                                Destroy(attatchPoint.GetChild(0).gameObject);
                            }
                            else
                            {
                                attatchPoint.GetChild(0).parent = containers[(int)target.z][(int)target.x][(int)target.y];
                                containers[(int)target.z][(int)target.x][(int)target.y].GetChild(0).localPosition = Vector3.zero;
                            }
                        }

                        if (s1 <= 0)
                            state = State.Input;

                        break;
                    }
            }
        }
    }
}
