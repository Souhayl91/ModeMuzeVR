namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;

    public class ControlReactor : MonoBehaviour
    {
        public TextMesh go;

        private VRTK_Control_UnityEvents controlEvents;

        private void Start()
        {
            controlEvents = GetComponent<VRTK_Control_UnityEvents>();
            if (controlEvents == null)
            {
                controlEvents = gameObject.AddComponent<VRTK_Control_UnityEvents>();
            }

            controlEvents.OnValueChanged.AddListener(HandleChange);
        }

        private void HandleChange(object sender, Control3DEventArgs e)
        {
            if(e.normalizedValue >= 100)
            {
                Color newColor = new Color(0, 1, 0);
                GetComponent<MeshRenderer>().material.color = newColor;


                //TO-DO: Trigger 2nd tutorial
            }
        }
    }
}