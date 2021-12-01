using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StretchingLineColor {
    Default,
    Error
}

public class StretchingLine : MonoBehaviour {

    public float MinLineWidth = 0.006f;
    public float MaxLineWidth = 0.05f;
    public LineRenderer LineRenderer;

    public Color DefaultColor = new Color32(255, 115, 0, 255);
    public Color ErrorColor = Color.red;

    void Start() {
        Hide();
    }

    public void SetPositions(Vector3 pos0, Vector3 pos1, float dist, float distToConnect, StretchingLineColor color = StretchingLineColor.Default) {
        if (color == 0) {
            LineRenderer.material.SetColor("_EmissionColor", DefaultColor);
        } else if (color == StretchingLineColor.Error) {
            LineRenderer.material.SetColor("_EmissionColor", ErrorColor);
        }

        Show();
        LineRenderer.enabled = true;
        LineRenderer.SetPosition(0, pos0);
        LineRenderer.SetPosition(1, pos1);
        float lineWidth = Mathf.Lerp(MaxLineWidth, MinLineWidth, dist / distToConnect);
        LineRenderer.startWidth = lineWidth;
    }

    public void Show() {
        LineRenderer.enabled = true;
    }

    public void Hide() {
        LineRenderer.enabled = false;
    }

}
