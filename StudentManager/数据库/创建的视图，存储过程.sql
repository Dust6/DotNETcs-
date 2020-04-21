SELECT *FROM ScoreList
SELECT ScoreList.StudentID, StudentName,StudentClass.ClassName,CSharp,SQLServerDB,ScoreUpdateTime  FROM ScoreList JOIN Students ON ScoreList.StudentID=Students.StudentID JOIN StudentClass ON Students.ClassID=StudentClass.ClassID WHERE ScoreList.StudentID=10010
SELECT*FROM Students
SELECT*FROM Attendance

 --创建 成绩视图
CREATE VIEW AttInfor  
AS
SELECT StudentID,StudentName,Attendance.CardNO,StudentClass.ClassID,ClassName,Attendance.AUpdateTime FROM Students JOIN Attendance ON Students.CardNO=Attendance.CardNo JOIN StudentClass  ON Students.ClassID=StudentClass.ClassID

SELECT StudentID,StudentName,Students.CardNo,R.couAt FROM Students JOIN( SELECT CardNo, COUNT(CardNo) AS couAt  FROM AttInfor  GROUP BY CardNo)R ON Students.CardNo=r.CardNo



SELECT*FROM AttInfor
SELECT StudentID,StudentName,CardNO,ClassID,ClassName,AUpdateTime FROM AttInfor WHERE ClassID=

SELECT *FROM Students WHERE CardNO=20016

--创建查看管理员信息的存储过程
CREATE PROC AdminLog
@Id INT,
@Pwd VARCHAR(20)
AS
SELECT*FROM Admins WHERE LoginID=@Id AND LoginPwd=@Pwd

EXEC AdminLog 1111,123456