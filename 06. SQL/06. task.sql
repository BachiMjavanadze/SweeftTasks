/*
გვაქვს Teacher ცხრილი, რომელსაც აქვს შემდეგი მახასიათებლები: სახელი, გვარი, სქესი, საგანი. გვაქვს Pupil ცხრილი, რომელსაც აქვს შემდეგი მახასიათებლები: სახელი, გვარი, სქესი, კლასი.

ააგეთ ნებისმიერ რელაციურ ბაზაში ისეთი დამოკიდებულება, რომელიც საშუალებას მოგვცემს, რომ მასწავლებელმა ასწავლოს რამოდენიმე მოსწავლეს და ამავდროულად მოსწავლეს ჰყავდეს რამდენიმე მასწავლებელი (როგორც რეალურ ცხოვრებაში).

1. დაწერეთ sql რომელიც ააგებს შესაბამის table-ებს.
2. დაწერეთ sql რომელიც დააბრუნებს ყველა მასწავლებელს, რომელიც ასწავლის მოსწავლეს, რომელის სახელია: „გიორგი“ .
*/

CREATE DATABASE School
GO

USE School;

-- create tables
CREATE TABLE SchoolSubjects (
	Id INT PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL
);

CREATE TABLE Pupils (
	Id INT PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	ClassNumber NVARCHAR(10) NOT NULL,
);

CREATE TABLE PupilSchoolSubjects (
	PupilId INT,
	SubjectId INT,
	PRIMARY KEY(PupilId, SubjectId),
	FOREIGN KEY (PupilId) REFERENCES Pupils(Id),
	FOREIGN KEY (SubjectId) REFERENCES SchoolSubjects(Id)
);

CREATE TABLE Teachers (
	Id INT PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Gender NVARCHAR(10) NOT NULL,
	SchoolSubjectId INT,
	FOREIGN KEY (SchoolSubjectId) REFERENCES SchoolSubjects(Id)
);

-- Insert data
INSERT INTO SchoolSubjects (Id, Name) VALUES
(1, N'ქართული'),
(2, N'მათემატიკა'),
(3, N'ისტორია'),
(4, N'ინგლისური'),
(5, N'გეოგრაფია');

INSERT INTO Pupils (Id, FirstName, LastName, ClassNumber) VALUES
(1, N'ჯეირან', N'დიღმელაშვილი', '1A'),
(2, N'გიორგი', N'აბჟანდაძე', '2B'),
(3, N'ბაკურ', N'სულაკაური', '3C'),
(4, N'ანა', N'ირიმლიშვილი', '4D'),
(5, N'ჯუმბერ', N'ტყაბლაძე', '5E');

INSERT INTO PupilSchoolSubjects (PupilId, SubjectId) VALUES
(1, 1), (1, 2), (1, 3),
(2, 2), (2, 4), 
(3, 1), (3, 5),
(4, 2), (4, 4), (4, 5),
(5, 1), (5, 2);

INSERT INTO Teachers (Id, FirstName, LastName, Gender, SchoolSubjectId) VALUES
(1, N'ბადრი', N'ესებუა', 'Male', 1),
(2, N'მირიან', N'მაღრაძე', 'Female', 2),
(3, N'თომას', N'მანი', 'Male', 3),
(4, N'ალისა', N'ჩიგოგიძე', 'Female', 4),
(5, N'ნუკრი', N'ფრთხიალაშვილი', 'Male', 5);

-- query
SELECT DISTINCT t.*, s.Name AS SubjectName
FROM Teachers t
INNER JOIN
    SchoolSubjects s
    ON t.SchoolSubjectId = s.Id
INNER JOIN
    PupilSchoolSubjects pss
    ON s.Id = pss.SubjectId
INNER JOIN
    Pupils p
    ON pss.PupilId = p.Id
WHERE p.FirstName = N'გიორგი';