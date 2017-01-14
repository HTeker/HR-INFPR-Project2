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

        public bool isHuman;

        private Vector3 target;
        private Vector3 oldTarget;
        private Vector3 targetPosition;

        private bool hasLoad;

        private float progress = 0;

        // Kleur welke de speler op moet pakken
        private ShipType targetColor;

        private void Start()
        {
            targetColor = targetShip.GetTargetType();
        }

        private void ProcessHumanInput()
        {
            target.x += (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) ? 1 : 0;
            target.x -= (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) ? 1 : 0;

            target.y -= (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) ? 1 : 0;
            target.y += (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) ? 1 : 0;
        }

        private void ProcessAIInput()
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

                    state = State.Move;
                    break;
                case State.Input:
                    if (Input.GetKey(KeyCode.Space))
                    {
                        state = (hasLoad) ? State.DropContainer : State.TakeContainer;
                        break;
                    }

                    oldTarget = target;

                    if (isHuman)
                        ProcessHumanInput();
                    else
                        ProcessAIInput();
                    
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

                        // Dehighlight old container
                        if (oldTarget.y < containersTopLayer[0].Count)
                        {
                            oldTarget.z = -1;
                            for (int layer = 0; layer < containers.Count; ++layer)
                            {
                                if (containers[layer][(int)oldTarget.x][(int)oldTarget.y].childCount > 0)
                                {
                                    oldTarget.z = layer;
                                    break;
                                }
                            }

                            if (oldTarget.z != -1)
                            {
                                var hc = containers[(int)oldTarget.z][(int)oldTarget.x][(int)oldTarget.y].GetComponentInChildren<HighlightController>();
                                if (hc)
                                    hc.Normal();
                            }
                        }

                        // highlight contrainer
                        if (!hasLoad && target.y < containersTopLayer[0].Count)
                        {
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
                                var hc = containers[(int)target.z][(int)target.x][(int)target.y].GetComponentInChildren<HighlightController>();
                                if (hc)
                                    hc.Highlight();
                            }
                        }

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
                case State.TakeContainerProgress:
                case State.DropContainerProgress:
                    var t = Time.deltaTime / ((target.z + 0.5f) * grabSpeed) * Mathf.PI;
                    progress += t;

                    var s1 = Mathf.Sin(progress);
                    var s2 = Mathf.Sin(progress + t);

                    var pos = cable.localPosition;
                    pos.y = Mathf.Max(s1, 0) * targetPosition.y;
                    cable.localPosition = pos;

                    // Moment dat de kabel op het laagste punt staat
                    Transform container;
                    if (s2 < s1)
                    {
                        switch (state)
                        {
                            case State.TakeContainerProgress:
                                if (hasLoad)
                                    break;
                                    
                                hasLoad = true;

                                container = containers[(int)target.z][(int)target.x][(int)target.y].GetChild(0);
                                container.parent = attatchPoint;
                                container.localPosition = Vector3.zero;
                                container.localEulerAngles = Vector3.zero;
                                break;
                            case State.DropContainerProgress:
                                if (!hasLoad)
                                    break;

                                hasLoad = false;
                                container = attatchPoint.GetChild(0);

                                if (target.z == containers.Count)
                                {
                                    // TODO plaats op kade
                                    Destroy(container.gameObject);

                                    targetShip.containerCount[container.GetComponent<Container>().Type] --;

                                    if (targetShip.IsShipEmpty())
                                    {
                                        // Schip is leeg
                                    }
                                    else
                                    {
                                        targetColor = targetShip.GetTargetType();
                                    }
                                }
                                else
                                {
                                    container.parent = containers[(int)target.z][(int)target.x][(int)target.y];
                                    container.localPosition = Vector3.zero;
                                    container.localEulerAngles = Vector3.zero;
                                }
                                break;
                        }
                    }

                    // Moment dat de kabel weer terug is
                    if (s1 <= 0)
                    {
                        targetShip.CalculateBalance();
                        if (Math.Abs(targetShip.Balance) > targetShip.MaxBalance)
                        {
                            // Schip is unbalnaced
                        }
                        state = State.Input;
                    }

                    break;
            }
        }
    }
}
