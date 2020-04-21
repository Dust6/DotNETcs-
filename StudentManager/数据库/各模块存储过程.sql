/*ѧ����洢����*/
SELECT*FROM Students
--ͨ���༶��Ų�ѯѧ������
CREATE PROC StudentListByCId
@CId INT
AS
SELECT StudentID,StudentName,Gender,Birthday,StudentIdNO,CardNO,StuImage,Age,PhoneNumber,StudentAddress,StudentClass.ClassName FROM Students INNER JOIN StudentClass ON StudentClass.ClassID=Students.ClassID WHERE StudentClass.ClassID=@CId
--�鿴
EXEC StudentListByCId 102

--ͨ��ѧ�Ż�������ѯѧ����Ϣ(ģ����ѯ)
CREATE PROC StudentLike
@Like VARCHAR(20)
AS
SELECT StudentID,StudentName,Gender,Birthday,StudentIdNO,CardNO,StuImage,Age,PhoneNumber,StudentAddress,StudentClass.ClassName FROM Students INNER JOIN StudentClass ON StudentClass.ClassID=Students.ClassID WHERE StudentID LIKE '%'+@Like+'%'OR StudentName LIKE '%'+@Like+'%'
--DROP PROC StudentLike
EXEC StudentLike 10001

--ͨ��ѧ�Ų�ѯ����ĳ��ѧԱ��Ϣ
CREATE PROC StudentByStId
@StId INT
AS
SELECT StudentID,StudentName,Gender,Birthday,StudentIdNO,CardNO,StuImage,Age,PhoneNumber,StudentAddress,Students.ClassID,StudentClass.ClassName FROM Students INNER JOIN StudentClass ON StudentClass.ClassID=Students.ClassID WHERE Students.StudentID=@STID
EXEC StudentByStId 10001
--�޸�ѧԱ��Ϣ
CREATE PROC UpStudent
@stName VARCHAR(20),
@stGender CHAR(2),
@stBirthdy SMALLDATETIME,
@stIDNO VARCHAR(20),
@stCardNO VARCHAR(20),
@stImage TEXT,
@stAge INT,
@stPhoneNumber VARCHAR(20),
@stAddress VARCHAR(20),
@stClassId INT,
@stID INT 
AS
UPDATE Students SET StudentName =@stName, Gender = @stGender, Birthday = @stBirthdy, StudentIdNO = @stIDNO, CardNO = @stCardNO, StuIMage = @stImage, Age =@stAge,PhoneNumber = @stPhoneNumber,StudentAddress = @stAddress,ClassID =@stClassId WHERE StudentID = @stID
--���ѧԱ��Ϣ
CREATE PROC InStudent
@StName VARCHAR(20),
@StGender CHAR(2),
@StBirthdy SMALLDATETIME,
@StIDNO VARCHAR(20),
@StCardNO VARCHAR(20),
@StImage TEXT,
@StAge INT,
@StPhoneNumber VARCHAR(20),
@StAddress VARCHAR(20),
@StClassId INT
AS
INSERT INTO Students(StudentName,Gender,Birthday,StudentIdNO,CardNO,StuIMage,Age,PhoneNumber,StudentAddress,ClassID) VALUES(@StName, @StGender, @StBirthdy, @StIDNO, @StCardNO,@StImage,@StAge,@StPhoneNumber,@StAddress,@StClassId)
--����ɾ��ѧԱ��Ϣ
CREATE PROC DeleStudent
@deSId INT 
AS
DELETE FROM Students WHERE StudentID=@deSId
--���Excel��ѧ������
CREATE PROC InStuBYExcel
@SteName VARCHAR(20),
@SteGender CHAR(2),
@SteBirthdy SMALLDATETIME,
@SteIDNO VARCHAR(20),
@SteCardNO VARCHAR(20),
@SteAge INT,
@StePhoneNumber VARCHAR(20),
@SteAddress VARCHAR(20),
@SteClassId INT
AS
INSERT INTO Students(StudentName,Gender,Birthday,StudentIdNO,CardNO,Age,PhoneNumber,StudentAddress,ClassID) VALUES(@SteName, @SteGender, @SteBirthdy, @SteIDNO, @SteCardNO,@SteAge,@StePhoneNumber,@SteAddress,@SteClassId)
--ѧ�Ų�ѯ�Ƿ������Ϣ
CREATE PROC CheckStuByID
@checkStId INT 
AS
SELECT COUNT(*) FROM Students WHERE StudentIdNo=@checkStId

--���ںŲ�ѯ�Ƿ������Ϣ
CREATE PROC SeleStuByCard
@CardId INT 
AS
SELECT *FROM Students WHERE CardNO=@CardId

/*�༶��洢����*/
--�鿴�༶����Ϣ
CREATE PROC SeleClass
AS
SELECT * FROM StudentClass
--ͨ���༶��Ų�ѯ�༶��Ϣ
CREATE PROC SeleStuClassBycId
@classId INT 
AS
SELECT StudentID,StudentName,Gender,Birthday,StudentIdNO,CardNO,Age,PhoneNumber,StudentAddress,StudentClass.ClassName FROM Students INNER JOIN StudentClass ON StudentClass.ClassID=Students.ClassID WHERE StudentClass.ClassID=@classId
--ͨ���༶����ѯ�༶��Ϣ
CREATE PROC SeleStuClassByCname
@className VARCHAR(20)
AS
SELECT ClassID from StudentClass WHERE ClassName=@className

/*�ɼ���洢����*/
--ͨ��ѧ�Ų�ѯ�ɼ�
CREATE PROC SeleScoreByStuId
@scoStuId INT 
AS
SELECT ScoreList.StudentID, StudentName,StudentClass.ClassName,CSharp,SQLServerDB,ScoreUpdateTime  FROM ScoreList JOIN Students ON ScoreList.StudentID=Students.StudentID JOIN StudentClass ON Students.ClassID=StudentClass.ClassID WHERE ScoreList.StudentID=@scoStuId
--ͨ���༶���ѯ�ɼ�
CREATE PROC SeleScoreByclassId
@scoClassId INT 
AS
SELECT ScoreList.StudentID, StudentName,StudentClass.ClassName,CSharp,SQLServerDB,ScoreUpdateTime  FROM ScoreList JOIN Students ON ScoreList.StudentID=Students.StudentID JOIN StudentClass ON Students.ClassID=StudentClass.ClassID WHERE StudentClass.ClassID=@scoClassId
--ͨ��ѧ�Ż�������ѯ�ɼ�(ģ����ѯ)
CREATE PROC SeleScoreByStIdorname
@scoStIdorName varchar(20)
AS
SELECT ScoreList.StudentID, StudentName,StudentClass.ClassName,CSharp,SQLServerDB,ScoreUpdateTime  FROM ScoreList JOIN Students ON ScoreList.StudentID=Students.StudentID JOIN StudentClass ON Students.ClassID=StudentClass.ClassID WHERE ScoreList.StudentID LIKE '%'+@scoStIdorName+'%'OR StudentName LIKE'%'+@scoStIdorName+'%'
--�޸�ѧԱ�ɼ�
CREATE PROC UpSCore
@UpCsharp INT,
@UpSQL INT,
@UpstuId INT
AS
UPDATE ScoreList SET CSharp=@UpCsharp,SQLServerDB=@UpSQL WHERE StudentID=@UpstuId
--ɾ���ɼ�
CREATE PROC DeleScore
@DeStuId INT
AS
DELETE ScoreList WHERE StudentID=@DeStuId
--��ӳɼ�
CREATE PROC InScore
@InStId INT,
@InCshar INT,
@InSQL INT,
@Intime SMALLDATETIME
AS
INSERT ScoreList VALUES (@InStId,@InCshar,@InSQL,@Intime)
--ͨ���༶�Ż�ȡ���Ű༶��
CREATE PROC GetScoreCLssByCId
@scoreCId INT
AS
SELECT ScoreList.StudentID, StudentName,StudentClass.ClassName,CSharp,SQLServerDB,ScoreUpdateTime  FROM ScoreList JOIN Students ON ScoreList.StudentID=Students.StudentID JOIN StudentClass ON Students.ClassID=StudentClass.ClassID WHERE StudentClass.ClassID=@scoreCId

/*���ڱ�洢����*/
--ͨ���༶��Ų�ѯ���ڱ���
CREATE PROC GetAttByCid
@AttCId INT
AS
SELECT StudentID,StudentName,CardNO,ClassID,ClassName,AUpdateTime FROM AttInfor WHERE ClassID=@AttCId
--ͨ��ѧ�Ż�������ѯ������Ϣ(ģ����ѯ)
CREATE PROC GETAttendaceBySIdorName
@AttStIdorName VARCHAR(20)
AS
SELECT StudentID,StudentName,CardNO,ClassID,ClassName,AUpdateTime FROM AttInfor WHERE StudentID LIKE '%'+@AttStIdorName+'%'OR StudentName LIKE'%'+@AttStIdorName+'%'
--��ӿ���
CREATE PROC AddAttendace
@CardnoId INT,
@ADDTime SMALLDATETIME
AS
INSERT Attendance VALUES (@CardnoId,@ADDTime)
--ͨ���༶��Ų�ѯ������Ϣ
CREATE PROC SeleAttByCId
@SeAtCId INT 
AS
SELECT StudentID,StudentName,CardNO,ClassID,ClassName,AUpdateTime FROM AttInfor WHERE ClassID=@SeAtCId

--ͨ���༶��Ų�ѯ���ڴ���
CREATE PROC AttRate   --�����洢���� �鿴������
@AtReclassId int   --�༶���
AS
SELECT StudentID,StudentName,Students.CardNo,AttRate FROM Students JOIN( SELECT CardNo, COUNT(CardNo) AS AttRate  FROM AttInfor  GROUP BY CardNo)R ON Students.CardNo=r.CardNo    WHERE ClassID=@AtReclassId