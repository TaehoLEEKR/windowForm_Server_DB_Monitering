
---
## 💻 인턴 기간 회사 서버 DB 모니터링 폼 구현 개발
---

* 기본 마더보드 폼에 새로운 폼들을 상속시키는 구조로 개발 하였습니다.
* C# 윈도우폼 과 MSSQL 로 구현 하였습니다.
---

### Window Form Monitering 첫 폼 🔒
![image](https://user-images.githubusercontent.com/80689135/185561570-4ca50b28-a7ab-44f9-a4c3-8792032e76e6.png)

* 실행시 DB 서버가 사용중이면 Manager Servers 는 Running 상태가 되고
* Active Directory Domain 테이블에 상태를 체크하여 Local <> Global 인지 확인
* Domain Controller lists 는 활동중인 도메인을 클릭시 상태체크를 동적으로 확인해줍니다
---
### Domain Controller 🔒
![image](https://user-images.githubusercontent.com/80689135/185563015-a16b8d9a-ac31-4da2-a8ae-45982c74dd21.png)



* DomainController 폼은 파일을 클릭시 도메인컨트롤DB를 폼에서 컨트롤 할 수있게 하는 자식 폼입니다
* 데이터를 더블클릭시 이벤트로 해당 자식 폼을 띄워 업데이트가 가능하게 만드는 폼입니다.
---

### Domain  🔒
![image](https://user-images.githubusercontent.com/80689135/185563332-bd1b878b-04c2-4074-92fa-d62653e8ad27.png)

* Domain 폼은 해당 도메인이 G / L 인지 변환 해주거나 또는 초기화 시켜줄때 사용합니다

---
### Server 🔒

![image](https://user-images.githubusercontent.com/80689135/185563719-7d0f97f1-0dc5-4f98-958a-3543518a6b0c.png)

* Server 폼은 위와 같은 구성으로 DB를 수정 과 모니터링 할 수 있는 폼입니다.
