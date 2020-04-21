CREATE DATABASE StudentManageDB
ON PRIMARY
(
	NAME ='StudentManageDB',
	FILENAME='E:\peixun\SQL Server���ݿ�List\StudentManage\StudnetMangeDB.mdf',
	SIZE=6MB,
	FILEGROWTH=20%

)
LOG ON
(
	NAME='StudentManageDB_log',
	FILENAME='E:\peixun\SQL Server���ݿ�List\StudentManage\StudentNamageDB_log.ldf',
	SIZE=5MB,
	FILEGROWTH=20%
)
GO
USE StudentManageDB
--��������Ա��
CREATE TABLE Admins
(
	[LoginID] INT NOT NULL IDENTITY(1111,1), --����Ա�˺�
	[LoginPwd] VARCHAR(20) NOT NULL, --����Ա����
	[AdminName] VARCHAR(20) NOT NULL --����Ա����
)
GO
ALTER TABLE [Admins]
ADD CONSTRAINT ['PK_LoginID'] PRIMARY KEY(LoginID)  --�������Լ��
GO 
ALTER TABLE [Admins]
ADD CONSTRAINT ['UQ_AdminName'] UNIQUE(AdminName)  --����Ա�����ΨһԼ��
GO
--�򿨱�
CREATE TABLE Attendance
(
	[AID] INT NOT NULL IDENTITY(1,1),   --���
	[CardNo] VARCHAR(20) NOT NULL,   --��ѧ�����
	[AUpdateTime] SMALLDATETIME NOT NULL    --��ʱ��
)
GO
ALTER TABLE [Attendance]
ADD CONSTRAINT [PK_AID] PRIMARY KEY(AID) --�򿨱����������
ALTER TABLE[Attendance]
ADD CONSTRAINT [DF_AUpdateTime] DEFAULT(GETDATE()) FOR[AUpdateTime] --��ʱ������Ĭ��Լ������ʱ��
GO
--�����༶��
CREATE TABLE StudentClass
(
	[ClassID] INT NOT NULL IDENTITY(101,1), --�༶��
	[ClassName] VARCHAR(20) NOT NULL --�༶��
)
GO
ALTER TABLE [StudentClass]
ADD CONSTRAINT [PK_ClassID] PRIMARY KEY(ClassID) --�༶����������Լ��
ALTER TABLE[StudentClass]
ADD CONSTRAINT [UQ_ClassName] UNIQUE(ClassName) --�༶�������ΨһԼ��
GO
--����ѧ����
CREATE TABLE Students
(
	[StudentID] INT NOT NULL IDENTITY(10001,1), --ѧ��
	[StudentName] VARCHAR(20) NOT NULL,    --����
	[Gender] CHAR(2) NOT NULL,  --�Ա�
	[Birthday] SMALLDATETIME NOT NULL, --��������
	[StudentIdNO] VARCHAR(20) NOT NULL, --���֤��
	[CardNO] VARCHAR(20) NOT NULL, --���ڴ򿨺�
	[StuIMage] text NULL,   --��Ƭ
	[Age] INT NOT NULL, --����
	[PhoneNumber] VARCHAR(20) NULL, --�ֻ���
	[StudentAddress] VARCHAR(50) NULL, --��ַ 
	[ClassID] INT NOT NULL --�༶���
)
GO
ALTER TABLE [Students]
ADD CONSTRAINT [PK_StudentID] PRIMARY KEY(StudentID) --��ѧ����������
ALTER TABLE [Students]
ADD CONSTRAINT [FK_ClassID] FOREIGN KEY(ClassID) REFERENCES [StudentClass](ClassID)  --��ѧ�����а༶������������ð༶���а༶ID
ALTER TABLE[Students]
ADD CONSTRAINT [UP_StudentIdNO] UNIQUE(sTUDENTiDNO) --���֤������Ψһ
ALTER TABLE[Students]
ADD CONSTRAINT [CK_Age] CHECK(Age>18) --��������Ӽ�����18��
ALTER TABLE[Students]
ADD CONSTRAINT [CK_STUDENTIdNO] CHECK((len([StudentIdNo])=(18))) --���֤�ű���18λ
ALTER TABLE[Students]
ADD CONSTRAINT [DF_StudentAddress] DEFAULT('��ַ����') FOR[StudentAddress]
GO
--�����ɼ���
CREATE TABLE ScoreList
(
	[ScoreID] INT NOT NULL IDENTITY(1,1), --���
	[StudentID] INT NOT NULL, --ѧ��
	[CSharp] INT NOT NULL, --c#�γ̳ɼ�
	[SQLServerDB] INT NOT NULL, --SQL ���ݿ�γ̳ɼ�
	[ScoreUpdateTime] SMALLDATETIME NOT NULL  --¼��ʱ��
)
ALTER TABLE [ScoreList]
ADD CONSTRAINT [PK_ScoreID] PRIMARY KEY(ScoreID) --��������
ALTER TABLE [ScoreList]
ADD CONSTRAINT [FK_StudentID] FOREIGN KEY(StudentID) REFERENCES [Students](StudentID) 
ALTER TABLE [ScoreList]
ADD CONSTRAINT [DF_ScoreUpdateTime] DEFAULT(GETDATE()) FOR[ScoreUpdateTime] --����Ĭ��ʱ��Ϊϵͳʱ��
GO

SELECT*FROM Admins --����Ա��Ϣ
SELECT *FROM StudentClass --�༶
SELECT*FROM Students --ѧ����
SELECT*FROM Admins --����Ա��Ϣ
SELECT*FROM Attendance --����Ϣ��




/*DROP TABLE Admins
DROP TABLE Attendance
DROP TABLE ScoreList
DROP TABLE Students
DROP TABLE StudentClass*/


TRUNCATE TABLE Students

--����Ա�����������
INSERT Admins VALUES ('123456','A����Ա')
INSERT Admins VALUES ('234567','B����Ա')
--�༶���������
INSERT StudentClass VALUES('C#101��')
INSERT StudentClass VALUES('C#102��')
INSERT StudentClass VALUES('SQLServer101��')
INSERT StudentClass VALUES('SQLServer102��')
--ѧ������Ϣ�������
/*ѧ�ţ��������Ա����գ����֤�ţ����ںţ�ͼƬ�����䣬�绰����ַ���༶��*/
INSERT Students VALUES ('������','��','1998/07/02',610321199990816141,20001,'',21,13900100212,'��������',102)
INSERT Students VALUES ('�����','Ů','1999/08/21',610321199990821137,20002,'',21,13900100212,'����μ��',103)
INSERT Students VALUES ('����','��','1997/06/21',610321199996216124,20003,'',21,13900100212,'��������',104)
---���ڱ��������
INSERT Attendance VALUES('������','')
INSERT Attendance VALUES('�����','2020-02-28')
INSERT Attendance VALUES('����','2020-02-27')
SELECT StudentID AS'ѧ��',StudentName AS'����',ClassName AS'�༶' FROM Students JOIN StudentClass ON Students.ClassID=StudentClass.ClassID
--�ɼ����������
---ѧ�ţ�C#��SQLserver,¼��ʱ��
INSERT ScoreList VALUES(10002,89,97,'2020-02-28')
INSERT ScoreList VALUES(10001,79,98,'2020/02/27')
/*ѧ�ţ��������Ա����գ����֤�ţ����ںţ�ͼƬ�����䣬�绰����ַ���༶��*/
INSERT Students VALUES ('��ï','��','1999/06/12',610321199990612142,20004,'',21,13900100212,'����μ��',102)
INSERT Students VALUES ('�ζ�Ұ','��','1999/11/12',610321199991112124,20005,'',22,13815141314,'�Ĵ��ɶ�',102)
INSERT Students VALUES ('����С','��','1998/10/02',610321199981002146,20006,'',20,13946135212,'�����人',102)
INSERT Students VALUES ('С��','Ů','1997/06/27',610321199970627143,20007,'',23,13506170812,'ɽ����ͬ',102)
INSERT Students VALUES ('СK','��','1999/8/28',610321199990828144,20008,'',21,13800100288,'ɽ������',102)
INSERT Students VALUES ('��СС','Ů','1996/05/04',610321199960504147,20009,'',24,13504560212,'��������',102)
--������ӵ�����
INSERT Attendance VALUES('��ï','2020-03-03') --8
INSERT Attendance VALUES('�ζ�Ұ','2020-03-02') --9
INSERT Attendance VALUES('����С','2020-02-04')--10
INSERT Attendance VALUES('С��','2020-02-28')--11
INSERT Attendance VALUES('СK','2020-02-26')--12
INSERT Attendance VALUES('��СС','2020-02-16')--13
