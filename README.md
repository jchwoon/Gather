# Gather

### 구현 기능

[1. 캐릭터 이동](#characterMove)  
[2. 캐릭터 애니메이션](#characterAni)  
[3. 카메라가 캐릭터 따라가기](#cameraFollow)  



<div id="installation">캐릭터 이동 설명</div>
- InputAction을 활용한 캐릭터 이동
<br>

<br>
<div id="characterAni">캐릭터 애니메이션 설명</div>
- 캐릭터 이동시 반환되는 벡터 값을 이용해서 0인지 아닌지에 따라 애니메이터의 파라미터 isMove를 토글  <br>
- isMove가 true일때 idle에서 walk로 transition(이동) <br>
- isMove가 false일때 walk에서 idle로 transition(이동)  <br>


<br>
<div id="cameraFollow">카메라가 캐릭터 따라가기 설명</div>
- 캐릭터의 transform을 가져와서 해당 벡터값을 갖게 설정
