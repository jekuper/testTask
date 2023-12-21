using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class HorizontalGridManager : MonoBehaviour {
    public int constraint {
        get {
            return gl.constraintCount;
        }
    }

    [SerializeField] private GridLayoutGroup gl;
    [SerializeField] private RectTransform rt;
    [SerializeField] private RectTransform viewPort;

    private float pureViewHeight {
        get {
            return viewPort.rect.height - gl.padding.bottom - gl.padding.top;
        }
    }
    private float pureViewWidth {
        get {
            return viewPort.rect.width - gl.padding.left - gl.padding.right;
        }
    }

    private void Start() {
        gl.spacing = Vector2.zero;
    }
    private void Update() {
        SetCellSize();
    }

    public Vector2 GetCellSize() {
        Vector2 cellSize = new Vector2(1, 1);
        if (gl.constraint == GridLayoutGroup.Constraint.FixedRowCount) {
            cellSize.y = (pureViewHeight) / gl.constraintCount;


            cellSize.x = cellSize.y;
            int cellCount = (int)(pureViewWidth / cellSize.y);

            cellSize.x += (pureViewWidth - (cellCount * cellSize.x)) / cellCount;

            cellSize.x = Mathf.Min(cellSize.x, pureViewWidth);
        }
        else {
            Debug.LogError("Row count have to be fixed to use this component");
        }

        return cellSize;
    }
    public int FullCellCount() {
        if (gl.constraint == GridLayoutGroup.Constraint.FixedRowCount) {
            return (int)(pureViewWidth / GetCellSize().x) * gl.constraintCount;
        }
        else {
            Debug.LogError("Row count have to be fixed to use this component");
        }
        return 0;
    }

    void SetCellSize() {

        Vector2 cellSize = GetCellSize();

        gl.cellSize = cellSize;
    }
}
