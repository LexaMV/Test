using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<HexagonController> ListHexagon;
    private HexagonController CurrentHexagon;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitB;
            var rayB = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(rayB, out hitB);

            if (CurrentHexagon == null)
            {
                return;
            }

            else if (hitB.collider != null)
            {

                foreach (HexagonController hexagon in ListHexagon)
                {
                    if (hexagon.gameObject == hitB.collider.gameObject)
                    {
                        if (CurrentHexagon != null && CurrentHexagon == hexagon)
                        {
                            if (CurrentHexagon.isFirstStepCompleted)
                            {
                                CurrentHexagon.Rotate();
                            }
                            else
                            {
                                CurrentHexagon.MoveUp();
                            }
                        }
                        else if (CurrentHexagon != null && CurrentHexagon != hexagon)
                        {
                            if (CurrentHexagon.isUp)
                            {
                                var temp1 = hexagon.gameObject.transform.position;
                                var temp2 = CurrentHexagon.gameObject.transform.position;

                                hexagon.MoveTo(temp2);
                                CurrentHexagon.MoveTo(temp1);

                                CurrentHexagon = null;
                            }
                        }
                    }

                }
            }
        }
        else
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (hit.collider != null)
            {
                foreach (HexagonController hexagon in ListHexagon)
                {
                    if (hexagon.gameObject == hit.collider.gameObject)
                    {
                        if (CurrentHexagon == hexagon)
                        {
                            return;
                        }
                        if (CurrentHexagon == null)
                        {
                            hexagon.Outline.enabled = true;
                            CurrentHexagon = hexagon;
                        }
                        else if (CurrentHexagon != null && hexagon == CurrentHexagon)
                        {
                            return;
                        }
                        else if (CurrentHexagon != null && hexagon != CurrentHexagon)
                        {
                            // CurrentHexagon.MoveDown();

                            if (!CurrentHexagon.isUp)
                            {
                                CurrentHexagon.Outline.enabled = false;
                                hexagon.Outline.enabled = true;
                                CurrentHexagon = hexagon;
                            }
                        }

                        break;
                    }
                }
            }
        }
    }
}
