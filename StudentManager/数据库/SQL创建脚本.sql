CREATE DATABASE StudentManageDB
ON PRIMARY
(
	NAME ='StudentManageDB',
	FILENAME='E:\peixun\SQL Server数据库List\StudentManage\StudnetMangeDB.mdf',
	SIZE=6MB,
	FILEGROWTH=20%

)
LOG ON
(
	NAME='StudentManageDB_log',
	FILENAME='E:\peixun\SQL Server数据库List\StudentManage\StudentNamageDB_log.ldf',
	SIZE=5MB,
	FILEGROWTH=20%
)
GO
USE StudentManageDB
--创建管理员表
CREATE TABLE Admins
(
	[LoginID] INT NOT NULL IDENTITY(1111,1), --管理员账号
	[LoginPwd] VARCHAR(20) NOT NULL, --管理员密码
	[AdminName] VARCHAR(20) NOT NULL --管理员名称
)
GO
ALTER TABLE [Admins]
ADD CONSTRAINT ['PK_LoginID'] PRIMARY KEY(LoginID)  --添加主键约束
GO 
ALTER TABLE [Admins]
ADD CONSTRAINT ['UQ_AdminName'] UNIQUE(AdminName)  --管理员名添加唯一约束
GO
--打卡表
CREATE TABLE Attendance
(
	[AID] INT NOT NULL IDENTITY(1,1),   --序号
	[CardNo] VARCHAR(20) NOT NULL,   --打卡学生编号
	[AUpdateTime] SMALLDATETIME NOT NULL    --打卡时间
)
GO
ALTER TABLE [Attendance]
ADD CONSTRAINT [PK_AID] PRIMARY KEY(AID) --打卡编号设置主键
ALTER TABLE[Attendance]
ADD CONSTRAINT [DF_AUpdateTime] DEFAULT(GETDATE()) FOR[AUpdateTime] --打卡时间设置默认约束现在时间
GO
--创建班级表
CREATE TABLE StudentClass
(
	[ClassID] INT NOT NULL IDENTITY(101,1), --班级号
	[ClassName] VARCHAR(20) NOT NULL --班级名
)
GO
ALTER TABLE [StudentClass]
ADD CONSTRAINT [PK_ClassID] PRIMARY KEY(ClassID) --班级编号添加主键约束
ALTER TABLE[StudentClass]
ADD CONSTRAINT [UQ_ClassName] UNIQUE(ClassName) --班级名天添加唯一约束
GO
--创键学生表
CREATE TABLE Students
(
	[StudentID] INT NOT NULL IDENTITY(10001,1), --学号
	[StudentName] VARCHAR(20) NOT NULL,    --姓名
	[Gender] CHAR(2) NOT NULL,  --性别
	[Birthday] SMALLDATETIME NOT NULL, --出生日期
	[StudentIdNO] VARCHAR(20) NOT NULL, --身份证号
	[CardNO] VARCHAR(20) NOT NULL, --考勤打卡号
	[StuIMage] text NULL,   --照片
	[Age] INT NOT NULL, --年龄
	[PhoneNumber] VARCHAR(20) NULL, --手机号
	[StudentAddress] VARCHAR(50) NULL, --地址 
	[ClassID] INT NOT NULL --班级编号
)
GO
ALTER TABLE [Students]
ADD CONSTRAINT [PK_StudentID] PRIMARY KEY(StudentID) --给学号设置主键
ALTER TABLE [Students]
ADD CONSTRAINT [FK_ClassID] FOREIGN KEY(ClassID) REFERENCES [StudentClass](ClassID)  --给学生表中班级编号添加外键引用班级表中班级ID
ALTER TABLE[Students]
ADD CONSTRAINT [UP_StudentIdNO] UNIQUE(sTUDENTiDNO) --身份证号设置唯一
ALTER TABLE[Students]
ADD CONSTRAINT [CK_Age] CHECK(Age>18) --给年龄添加检查大于18岁
ALTER TABLE[Students]
ADD CONSTRAINT [CK_STUDENTIdNO] CHECK((len([StudentIdNo])=(18))) --身份证号必须18位
ALTER TABLE[Students]
ADD CONSTRAINT [DF_StudentAddress] DEFAULT('地址不详') FOR[StudentAddress]
GO
--创建成绩表
CREATE TABLE ScoreList
(
	[ScoreID] INT NOT NULL IDENTITY(1,1), --编号
	[StudentID] INT NOT NULL, --学号
	[CSharp] INT NOT NULL, --c#课程成绩
	[SQLServerDB] INT NOT NULL, --SQL 数据库课程成绩
	[ScoreUpdateTime] SMALLDATETIME NOT NULL  --录入时间
)
ALTER TABLE [ScoreList]
ADD CONSTRAINT [PK_ScoreID] PRIMARY KEY(ScoreID) --设置主键
ALTER TABLE [ScoreList]
ADD CONSTRAINT [FK_StudentID] FOREIGN KEY(StudentID) REFERENCES [Students](StudentID) 
ALTER TABLE [ScoreList]
ADD CONSTRAINT [DF_ScoreUpdateTime] DEFAULT(GETDATE()) FOR[ScoreUpdateTime] --设置默认时间为系统时间
GO

SELECT*FROM Admins --管理员信息
SELECT *FROM StudentClass --班级
SELECT*FROM Students --学生表
SELECT*FROM Admins --管理员信息
SELECT*FROM Attendance --打卡信息表




/*DROP TABLE Admins
DROP TABLE Attendance
DROP TABLE ScoreList
DROP TABLE Students
DROP TABLE StudentClass*/


TRUNCATE TABLE Students

--管理员表中添加数据
INSERT Admins VALUES ('123456','A管理员')
INSERT Admins VALUES ('234567','B管理员')
--班级表添加数据
INSERT StudentClass VALUES('C#101班')
INSERT StudentClass VALUES('C#102班')
INSERT StudentClass VALUES('SQLServer101班')
INSERT StudentClass VALUES('SQLServer102班')
--学生表信息添加数据
/*学号，姓名，性别，生日，身份证号，考勤号，图片，年龄，电话，地址，班级号*/
INSERT Students VALUES ('王二狗','男','1998/07/02',610321199990816141,20001,'',21,13900100212,'陕西宝鸡',102)
INSERT Students VALUES ('李二锤','女','1999/08/21',610321199990821137,20002,'',21,13900100212,'陕西渭南',103)
INSERT Students VALUES ('李逵','男','1997/06/21',610321199996216124,20003,'',21,13900100212,'陕西汉中',104)
---考勤表添加数据
INSERT Attendance VALUES('王二狗','')
INSERT Attendance VALUES('李二锤','2020-02-28')
INSERT Attendance VALUES('李逵','2020-02-27')
SELECT StudentID AS'学号',StudentName AS'姓名',ClassName AS'班级' FROM Students JOIN StudentClass ON Students.ClassID=StudentClass.ClassID
--成绩表添加数据
---学号，C#，SQLserver,录入时间
INSERT ScoreList VALUES(10002,89,97,'2020-02-28')
INSERT ScoreList VALUES(10001,79,98,'2020/02/27')
/*学号，姓名，性别，生日，身份证号，考勤号，图片，年龄，电话，地址，班级号*/
INSERT Students VALUES ('李茂','男','1999/06/12',610321199990612142,20004,'',21,13900100212,'陕西渭南',102)
INSERT Students VALUES ('宋冬野','男','1999/11/12',610321199991112124,20005,'',22,13815141314,'四川成都',102)
INSERT Students VALUES ('王二小','男','1998/10/02',610321199981002146,20006,'',20,13946135212,'湖北武汉',102)
INSERT Students VALUES ('小白','女','1997/06/27',610321199970627143,20007,'',23,13506170812,'山西大同',102)
INSERT Students VALUES ('小K','男','1999/8/28',610321199990828144,20008,'',21,13800100288,'山东济南',102)
INSERT Students VALUES ('张小小','女','1996/05/04',610321199960504147,20009,'',24,13504560212,'陕西汉中',102)
--后期添加的数据
INSERT Attendance VALUES('李茂','2020-03-03') --8
INSERT Attendance VALUES('宋冬野','2020-03-02') --9
INSERT Attendance VALUES('王二小','2020-02-04')--10
INSERT Attendance VALUES('小白','2020-02-28')--11
INSERT Attendance VALUES('小K','2020-02-26')--12
INSERT Attendance VALUES('张小小','2020-02-16')--13
