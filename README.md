# 게임 제작


주재영 쌤이 안에 규상이 얼굴로 하면 어떻겠냐고 했는데 어때? 일단 규상이한태도 물어봐야하는데

게임점수에따라서 점점 속도가 빨라지는걸 하면 좋을것 같아서 해보려고 하는데
내가 만든 V_Value 잘못 만든것 같아 애초에 잘못됬다
땅 생성하고 장애물생성 도 같이 바꿔야 하네

우리 5인 책친구는 언제할까 학교 남아서 해야될거 같은데 녹음도 해야된데




GameManager.instance.health 로 플레이어 체력 가져오기 가능

이거를 이용해서 이 체력이 0보다 작아지면 게임오버 판넬 띄우면 될 듯

이제부터 Instantiate 말고 ObjectPool.SpawnObject 쓰셈

그리고 Destroy 말고 ObjectPool.ReturnObjectToPool 쓰셈 (아마 이거일거임)

이유는 오브젝트 풀링을 완성했기 때문 ~

- [ ] Make GameOver (카메라 흔들림 구현)
- [ ] Make Game
