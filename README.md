# 게임 제작


주재영 쌤이 안에 규상이 얼굴로 하면 어떻겠냐고 했는데 어때? 일단 규상이한태도 물어봐야하는데

게임점수에따라서 점점 속도가 빨라지는걸 하면 좋을것 같아서 해보려고 하는데
스크립트에서 게임 속도 장애물 생성에 관련코드가 어떤건지 좀 알려줄수 있어?






GameManager.instance.health 로 플레이어 체력 가져오기 가능

이거를 이용해서 이 체력이 0보다 작아지면 게임오버 판넬 띄우면 될 듯

이제부터 Instantiate 말고 ObjectPool.SpawnObject 쓰셈

그리고 Destroy 말고 ObjectPool.ReturnObjectToPool 쓰셈 (아마 이거일거임)

이유는 오브젝트 풀링을 완성했기 때문 ~

- [ ] Make GameOver (카메라 흔들림 구현)
- [ ] Make Game
