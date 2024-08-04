USE [Contacts]
GO

--Testing out the StoredProc
DECLARE @TempNotes dbo.ContactNote;

INSERT INTO @TempNotes (Note)
VALUES
	('The best way we learn anything is by practice and exercise questions'),
	('We have started this section for those (beginner to intermediate) who are familiar with C# Sharp programming'),
	('C# syntax is highly expressive, yet it is also simple and easy to learn'),
	('The solution of the exercises described here are not the only ways to do stuff'),
	('Please avoid copyrighted materials');

EXEC dbo.InsertContactNotes @ContactId = 41, @Notes = @TempNotes;