# 게임 제작

맵 장애물 랜덤 생성 완성

ㄴ(대단합니다! 저도 열심히 하겠습니다!)

GameManager.instance.health 로 플레이어 체력 가져오기 가능

이거를 이용해서 이 체력이 0보다 작아지면 게임오버 판넬 띄우면 될 듯

이제부터 Instantiate 말고 ObjectPool.SpawnObject 쓰셈

그리고 Destroy 말고 ObjectPool.ReturnObjectToPool 쓰셈 (아마 이거일거임)

이유는 오브젝트 풀링을 완성했기 때문 ~

- [ ] Make GameOver (카메라 흔들림 구현)
- [ ] Make Game
