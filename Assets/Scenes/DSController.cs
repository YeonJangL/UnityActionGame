using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// �̺�Ʈ Ʈ���Ÿ� ���� ����
public class DSController : MonoBehaviour
{
    // ����� ��� ��� �ؽ�Ʈ
    // TMP ���� TMP ���·� �۾�
    public Text ResultText;

    // �迭 ���
    public void DSArray()
    {
        // �迭 ����
        // �ڷ���[] �迭�� = new �ڷ���[�迭�� ����];
        int[] exp = new int[10];

        for (int i = 0; i < exp.Length; i++)
        {
            exp[i] = i * 100 + (i * 50);
            ResultText.text += $"[DSArray]���� ���� {i}���� �䱸 ����ġ = {exp[i]}\n";
        }
    }

    public void DSList()
    {
        // ����Ʈ<T> ����Ʈ �� = new List<T>();
        List<int> exp = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            exp.Add(i * 100 + (i * 50));
        }

        // ������ �ִ� ������ ���� 4�� ��� ���� ����
        // exp.RemoveAll(x => (x % 4) == 0);

        exp.Sort((a, b) => b.CompareTo(a));

        for (int i = 0;i < exp.Count; i++)
        {
            ResultText.text += $"[DSArray]���� ���� {i}���� �䱸 ����ġ = {exp[i]}\n";
        }

        // C# ���� ���Ǵ� ����Ʈ ����
        // 1. Add(��) : �ش� ���� ����Ʈ�� �߰�
        // 2. Remove(��) : �ش� ���� ����Ʈ���� ����
        // 3. Insert(��ġ, ��) : ����Ʈ�� �ش� ��ġ�� �� �߰�
        // 4. Contains(��) : ����Ʈ�� �ش� ���� ������ �ִ��� �Ǵ�(bool)
        // 5. Clear() : ����Ʈ�� ��� ��� ����
        // 6. Reverse() : ��Ҹ� �������� ����
        // 7. RemoveAll(���ǽ�) : �ش� ������ �����ϴ� ��� ��� ����
        // 8. Sort() : �������� ����
        // 9. Sort((a, b)) => b.CompareTo(a)); ���� ���� ����
    }

    public void DSDictionary()
    {
        // ����
        // Dictionary<K, V> ��ųʸ� �� = new Dictionary<K, V>();

        // ���� �� �ʱ�ȭ
        Dictionary<string, int> items = new Dictionary<string, int>
        {
            {"red apple", 10},
            {"meat", 100}
        };

        // ��� �߰�
        items.Add("cake", 50);

        // Ű ����
        if (items.ContainsKey("cake"))
        {
            items.Remove("cake");
        }

        if (items.ContainsValue(100))
        {
            Debug.Log("�ش� �� ����");
        }

        // ��ųʸ��� �ٽ�
        // 1. Ű�� �̿��� ���� ���� ����
        // 2. �ش� Ű�� �����ϴ°��� ���� ����
        // 3. Ű, ���� ���� ������ ������ �� �ִ°�?(����Ʈ ��ȯ)
        // 4. ��ųʸ��� Ű�� ��� �ߺ� ��� ����, ���� �ߺ� �Ͽ�
        // ���� Add ������ ��, ������ �ִ� Ű�� �ٽ� Add �ϴ� ��� �� Ű�� ���� ���� ����   

        // ��ųʸ��� Ű -> ����Ʈ�� �ٲٴ� ���
        var KList = new List<string>(items.Keys);

        // ��ųʸ��� �� -> ����Ʈ�� �ٲٴ� ���
        var VList = new List<int>(items.Values);

        // ����Ʈ -> ��ųʸ��� �ٲٴ� ��
        // 1. Ű�� �� ����Ʈ�� ���� �� ����Ʈ�� �غ�
        var KtoD = new List<string>() {"a", "b", "c", "d", "e"};
        var VtoD = new List<int>() { 1, 2, 3, 4, 5, };

        // ��ųʸ��� �����ϰ� Zip�Լ��� ���� ���� ����
        // Ű.Zip(��, (k, v) => new{k, v}) ī�� �� �ϳ��ϳ��� {Ű, ��} ���·� ����
        // ToDictionary�� ���� Ű�� �� ����. �׸��� ��ųʸ� ���·� ��ȯ
        var NewDictionary = KtoD.Zip(VtoD, (k, v) => new { k, v }).ToDictionary(a => a.k, a => a.v);
    }

    // �ش� �Լ� ȣ�� �� ȭ�鿡 �����ִ� �ؽ�Ʈ�� ���� ���
    public void DSResultReset()
    {
        ResultText.text = "";
    }
}
