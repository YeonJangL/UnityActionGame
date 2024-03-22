using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // 시작 체력
    public int startingHealth = 100;

    // 현재 체력
    public int currentHealth;

    // 체력 UI와 연결
    public Slider healthSlidier;

    // 대미지 받았을때 화면 색 변경
    public Image damageImage;

    // 플레이어 대미지 받았을때 재생할 오디오
    public AudioClip deathClip;

    // 애니메이터데 전달
    Animator anim;

    // 효과음 컴포넌트
    AudioSource playerAudio;

    // 플레이어 움직임 관리
    PlayerMovement playerMovement;

    // 플레이어가 죽었는지에 대한 판단(플래그)
    bool isDead;

    // 오브젝트 시작 시 호출되는 Awake, Start 전에 실행됨

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio =  GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = startingHealth;
        DeathText.gameObject.SetActive(false);
    }

    /// <summary>
    /// 플레이어가 공격을 받았을때 호출되는 함수
    /// </summary>
    /// <param name="amount">대미지 수치</param>
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        healthSlidier.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
        else
        {
            anim.SetTrigger("Damage");
        }
    }

    public Text DeathText;

    void Death()
    {
        StageController.Instance.FinishGame();
        isDead = true;
        anim.SetTrigger("Die");
        playerMovement.enabled = false;

        /*// 죽음 텍스트 화면에 표시
        if (DeathText != null)
        {
            DeathText.gameObject.SetActive(true);
            DeathText.text = "You Died";
        }*/
    }

    private void Update()
    {
        
    }
}