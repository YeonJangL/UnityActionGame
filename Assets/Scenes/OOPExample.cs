using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#region OOP
// ��ü ���� ���α׷���(OOP)
// ���� ��� : ���α׷��� ���ɾ���� ����
// ��ü ����� ���� : ���α׷��� ��ü���� ����

// Ŭ���� : ��ü ���� ���α׷��� �⺻ �������, ����� ���� ������ Ÿ��
// -> ���� & �Լ� ���� ���� ������ �ڷᱸ��

// ��ü : Ŭ������ ������ �޸� �� �Ҵ�� �ν��Ͻ�
// �ʵ� : Ŭ���� ���ο� ����� ����, ��ü�� �Ӽ� ǥ��
// �޼ҵ� : Ŭ���� ���ο� ����� �Լ�, ��ü�� ���, ���� ǥ��

// ��ü ���� ������ ����(Ư¡)

// 1. ĸ��ȭ : Ŭ���� ������ ���� �����Ǿ��ִ� �Ӽ��� ����� �ϳ��� ĸ��ó�� �����
// �����Ͱ� �ܺηκ��� ����Ǵ� ���� �����ϴ� �����

// 2. ��� class �ڽ� Ŭ������ : �θ� Ŭ�������� ���·� ���� ��
// �θ� Ŭ������ ���� ��� ������ �Լ��� ��ӹް� ��� ��� ����
// ��Ȳ�� �°� ������ �Ͽ� ���ο� ������� ���� �� ����

// 3. ������ : ���� �̸��� ����, �Լ����� ��Ȳ�� ���� �ٸ� �ǹ̷� ���� �� ����.(���ǿ� ���� �ٸ��� ����)
#endregion

// �ڷ� ����(Data Structure)
// ȿ������ ���ٰ� ������ �����ϰ��ϴ� �ڷ��� ����, ����, ����, ������ ���� ����, �������� ���� ���� �����ؼ� ���´� ��

// �ڷ� ���� ������ ����
// T : Ÿ��, K : Ű , V : ��
// ��Ī                               �뵵
// LinkedList<T>                 �������� ��ϰ� ������ ����ϰ� �߻��ϴ� ��� �ش� �ڷᱸ�� ���
// List<T>                       �����Ͱ� ����� ����(�ε���)�� ������ Ž�� ����
// Stack<T>                      �����͸� ���� ����(LIFO) ������� ����� ���
// Queue<T>                      �����͸� ���� ����(FIFO) ������� ����� ���
// Dictionary<K, V>              Ư�� Ű�� ���� Ư�� ���� ��ȸ�ϴ� ��� ���
// HashSet<T>                    �ߺ����� ���� �����͸� �����Ҷ� ���(���������� ������ ���� ǥ�� �ÿ��� ���)
// T[]                           ����Ʈó�� �����Ͱ� �ε����� ���� �����Ǹ�, �޸� �� ���������� ����Ǵ� �ڷᱸ��
//                               ������ ũ�⸦ ������ �ְ�, �߰� �Ҹ�Ǵ� �޸� ���� �� ũ�⿡ �°� ������
//                               ����Ƽ ������ �󿡼� �迭�� ����Ʈ�� �����ϰ� ��޵ǳ� ��ũ��Ʈ �۾� �ÿ��� �迭�� ����Ʈ�� ������ �ٸ��� ������ �����ؾ���

// �ڷ� ���� �� �˰����� �ܰ��� ��
// ������ ���� N���� ���� �˰������� �ܰ� ���� �ľ��ϸ� �ش� �ڷᱸ���� ������, ������ �Ǵ� ����
// ���� ���� �ڷ� ���� ������� �ð� ���⵵ ǥ��
// O(1) : �������� ����, ���ҿ� ������ ���� �ʰ� �ܰ���� �����ϰ� ������
// O(n) : �׷����� ���� �Ϻ��ϰ� �밢���� ���·� ǥ��, ������ �߰��� �˰������� 1�ܰ辿 ����
//        -> �����Ͱ� ���������� �۾� ȿ�� �϶�
// O(long n) : ���� ���ݾ� �����ϴ� ������ �������� �����Ͱ� �� �ι����� ������ ������ 1�ܰ� ���� �þ

// ȿ�� �м�
// O(1) > O(log n) > 0(N)

// O(1)�� O(log n)�� �������� ����ϴ�. �������� ������ �� 1000�� �̻��� ���� ���O(1)�� ȿ������

// �α�(log)�� �̷��� �����غ���
// 2�� ��� ���ؾ� N�� �����°�? log2N
// 1�� �ɶ����� N�� 2�� ��� ���ؾ��ϴ°�? log2N

// ��Ī               �߰�               �˻�              ����              �ε��� ���� ����
// LinkedList<T>      O(1)               O(n)              O(n)              O(n)
// List<T>            O(1)               O(n)              O(n)              O(1)
// Stack<T>           O(1)                -                O(1)               -
// Queue<T>           0(1)                -                O(1)               -
// Dictionary<K, V>   O(1)               O(1)              O(1)               -  (�ε��� ��� Ű�� �ε��� ó�� ���)
// HashSet<T>         O(1)               O(1)              O(1)               -
// T[]                O(n)               O(n)              O(n)              O(1)
// �迭�� ��� �߰�, �˻�, ������ ����� ���� ������ ���� ������ ¥ �����ؾ� ��
// �迭�� �� ������� ������ �����Ϳ� ���� ���ʿ��� �޸� ���� ���� ���� ����ϴ� ��찡 ���� ����

public class OOPExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}