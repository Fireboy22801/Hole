using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }
    const int POOL_SIZE = 10;

    [SerializeField] private float floatingTime;
    [SerializeField] private TMP_Text points;
    [SerializeField] private TMP_Text targetNumber;

    private Queue<TMP_Text> textPool = new Queue<TMP_Text>();
    private List<ActiveText> activeText = new List<ActiveText>();

    private Camera m_Camera;
    private Transform m_Transform;

    private class ActiveText
    {
        public TMP_Text UIText;
        public float maxTime;
        public float Timer;
        public Vector3 unitPosition;

        public void MoveText(Camera camera)
        {
            float delta = 1f - (Timer / maxTime);
            Vector3 pos = unitPosition + new Vector3(delta, delta, 0f);
            pos = camera.WorldToScreenPoint(pos);
            pos.z = 0f;

            UIText.transform.position = pos;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        IncreaseText();

        m_Camera = Camera.main;
        m_Transform = transform;

        for (int i = 0; i < POOL_SIZE; i++)
        {
            TMP_Text temp = Instantiate(points, m_Transform);
            temp.gameObject.SetActive(false);
            textPool.Enqueue(temp);
        }
    }

    private void Update()
    {
        for (int i = 0; i < activeText.Count; i++)
        {
            ActiveText at = activeText[i];
            at.Timer -= Time.deltaTime;

            if (at.Timer <= 0f)
            {
                at.UIText.gameObject.SetActive(false);
                textPool.Enqueue(at.UIText);
                activeText.RemoveAt(i);
                --i;
            }
            else
            {
                var color = at.UIText.color;
                color.a = at.Timer / at.maxTime;
                at.UIText.color = color;

                at.MoveText(m_Camera);
            }
        }
    }

    public void AddText(int amount, Vector3 unitPos)
    {
        var t = textPool.Dequeue();
        t.text = "+" + amount.ToString();
        t.gameObject.SetActive(true);

        ActiveText at = new ActiveText() { maxTime = floatingTime };
        at.Timer = at.maxTime;
        at.UIText = t;
        at.unitPosition = unitPos + Vector3.up;

        at.MoveText(m_Camera);
        activeText.Add(at);
    }

    public void IncreaseText()
    {
        points.text = "Score: " + PlayerSize.Instance.points.ToString();
        targetNumber.text = "To Increse: " + PlayerSize.Instance.scaleValue.ToString() + "/" + PlayerSize.Instance.ScaleIncreaseTreshold.ToString();
    }
}