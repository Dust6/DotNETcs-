/*学生表存储过程*/
SELECT*FROM Students
--通过班级编号查询学生表集合
CREATE PROC StudentListByCId
@CId INT
AS
SELECT StudentID,StudentName,Gender,Birthday,StudentIdNO,CardNO,StuImage,Age,PhoneNumber,StudentAddress,StudentClass.ClassName FROM Students INNER JOIN StudentClass ON StudentClass.ClassID=Students.ClassID WHERE StudentClass.ClassID=@CId
--查看
EXEC StudentListByCId 102

--通过学号或姓名查询学生信息(模糊查询)
CREATE PROC StudentLike
@Like VARCHAR(20)
AS
SELECT StudentID,StudentName,Gender,Birthday,StudentIdNO,CardNO,StuImage,Age,PhoneNumber,StudentAddress,StudentClass.ClassName FROM Students INNER JOIN StudentClass ON StudentClass.ClassID=Students.ClassID WHERE StudentID LIKE '%'+@Like+'%'OR StudentName LIKE '%'+@Like+'%'
--DROP PROC StudentLike
EXEC StudentLike 10001

--通过学号查询具体某个学员信息
CREATE PROC StudentByStId
@StId INT
AS
SELECT StudentID,StudentName,Gender,Birthday,StudentIdNO,CardNO,StuImage,Age,PhoneNumber,StudentAddress,Students.ClassID,StudentClass.ClassName FROM Students INNER JOIN StudentClass ON StudentClass.ClassID=Students.ClassID WHERE Students.StudentID=@STID
EXEC StudentByStId 10001
--修改学员信息
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
--添加学员信息
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
--创建删除学员信息
CREATE PROC DeleStudent
@deSId INT 
AS
DELETE FROM Students WHERE StudentID=@deSId
--添加Excel表学生数据
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
--学号查询是否符合信息
CREATE PROC CheckStuByID
@checkStId INT 
AS
SELECT COUNT(*) FROM Students WHERE StudentIdNo=@checkStId

--考勤号查询是否符合信息
CREATE PROC SeleStuByCard
@CardId INT 
AS
SELECT *FROM Students WHERE CardNO=@CardId

/*班级表存储过程*/
--查看班级表信息
CREATE PROC SeleClass
AS
SELECT * FROM StudentClass
--通过班级编号查询班级信息
CREATE PROC SeleStuClassBycId
@classId INT 
AS
SELECT StudentID,StudentName,Gender,Birthday,StudentIdNO,CardNO,Age,PhoneNumber,StudentAddress,StudentClass.ClassName FROM Students INNER JOIN StudentClass ON StudentClass.ClassID=Students.ClassID WHERE StudentClass.ClassID=@classId
--通过班级名查询班级信息
CREATE PROC SeleStuClassByCname
@className VARCHAR(20)
AS
SELECT ClassID from StudentClass WHERE ClassName=@className

/*成绩表存储过程*/
--通过学号查询成绩
CREATE PROC SeleScoreByStuId
@scoStuId INT 
AS
SELECT ScoreList.StudentID, StudentName,StudentClass.ClassName,CSharp,SQLServerDB,ScoreUpdateTime  FROM ScoreList JOIN Students ON ScoreList.StudentID=Students.StudentID JOIN StudentClass ON Students.ClassID=StudentClass.ClassID WHERE ScoreList.StudentID=@scoStuId
--通过班级编查询成绩
CREATE PROC SeleScoreByclassId
@scoClassId INT 
AS
SELECT ScoreList.StudentID, StudentName,StudentClass.ClassName,CSharp,SQLServerDB,ScoreUpdateTime  FROM ScoreList JOIN Students ON ScoreList.StudentID=Students.StudentID JOIN StudentClass ON Students.ClassID=StudentClass.ClassID WHERE StudentClass.ClassID=@scoClassId
--通过学号或姓名查询成绩(模糊查询)
CREATE PROC SeleScoreByStIdorname
@scoStIdorName varchar(20)
AS
SELECT ScoreList.StudentID, StudentName,StudentClass.ClassName,CSharp,SQLServerDB,ScoreUpdateTime  FROM ScoreList JOIN Students ON ScoreList.StudentID=Students.StudentID JOIN StudentClass ON Students.ClassID=StudentClass.ClassID WHERE ScoreList.StudentID LIKE '%'+@scoStIdorName+'%'OR StudentName LIKE'%'+@scoStIdorName+'%'
--修改学员成绩
CREATE PROC UpSCore
@UpCsharp INT,
@UpSQL INT,
@UpstuId INT
AS
UPDATE ScoreList SET CSharp=@UpCsharp,SQLServerDB=@UpSQL WHERE StudentID=@UpstuId
--删除成绩
CREATE PROC DeleScore
@DeStuId INT
AS
DELETE ScoreList WHERE StudentID=@DeStuId
--添加成绩
CREATE PROC InScore
@InStId INT,
@InCshar INT,
@InSQL INT,
@Intime SMALLDATETIME
AS
INSERT ScoreList VALUES (@InStId,@InCshar,@InSQL,@Intime)
--通过班级号获取单张班级表
CREATE PROC GetScoreCLssByCId
@scoreCId INT
AS
SELECT ScoreList.StudentID, StudentName,StudentClass.ClassName,CSharp,SQLServerDB,ScoreUpdateTime  FROM ScoreList JOIN Students ON ScoreList.StudentID=Students.StudentID JOIN StudentClass ON Students.ClassID=StudentClass.ClassID WHERE StudentClass.ClassID=@scoreCId

/*考勤表存储过程*/
--通过班级编号查询考勤表集合
CREATE PROC GetAttByCid
@AttCId INT
AS
SELECT StudentID,StudentName,CardNO,ClassID,ClassName,AUpdateTime FROM AttInfor WHERE ClassID=@AttCId
--通过学号或姓名查询考勤信息(模糊查询)
CREATE PROC GETAttendaceBySIdorName
@AttStIdorName VARCHAR(20)
AS
SELECT StudentID,StudentName,CardNO,ClassID,ClassName,AUpdateTime FROM AttInfor WHERE StudentID LIKE '%'+@AttStIdorName+'%'OR StudentName LIKE'%'+@AttStIdorName+'%'
--添加考勤
CREATE PROC AddAttendace
@CardnoId INT,
@ADDTime SMALLDATETIME
AS
INSERT Attendance VALUES (@CardnoId,@ADDTime)
--通过班级编号查询考勤信息
CREATE PROC SeleAttByCId
@SeAtCId INT 
AS
SELECT StudentID,StudentName,CardNO,ClassID,ClassName,AUpdateTime FROM AttInfor WHERE ClassID=@SeAtCId

--通过班级编号查询出勤次数
CREATE PROC AttRate   --创建存储过程 查看出勤率
@AtReclassId int   --班级编号
AS
SELECT StudentID,StudentName,Students.CardNo,AttRate FROM Students JOIN( SELECT CardNo, COUNT(CardNo) AS AttRate  FROM AttInfor  GROUP BY CardNo)R ON Students.CardNo=r.CardNo    WHERE ClassID=@AtReclassId