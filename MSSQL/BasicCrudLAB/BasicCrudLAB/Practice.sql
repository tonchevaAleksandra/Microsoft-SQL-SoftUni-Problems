USE SoftUni

SELECT TownId, [Name], LEN(Name), SUBSTRING(Name, 1, 3)
FROM Towns
WHERE LEFT(Name, 1) = 'S'

SELECT TownId,
       [Name],
       LEN([Name])             AS NameLength,
       SUBSTRING([Name], 1, 3) AS FirstThreeLetters
FROM Towns
WHERE LEFT(Name, 1) = 'S'

SELECT GETDATE()

SELECT AddressText, [Name]
FROM Addresses
         JOIN Towns ON Addresses.TownID = Towns.TownID
WHERE Name = 'Bellevue'

SELECT A.AddressText, T.Name
FROM Addresses A
         JOIN Towns T ON A.TownID = T.TownID
WHERE Name = 'Bellevue'

SELECT *
FROM (SELECT TownId,
             [Name],
             LEN([Name])             AS NameLength,
             SUBSTRING([Name], 1, 3) AS FirstThreeLetters
      FROM Towns) AS tmp
WHERE FirstThreeLetters = 'SOF'


SELECT [FirstName] + ' ' + [LastName] AS FullName,
       EmployeeID                     AS [No.]
FROM [Employees]

SELECT TOP (10) [FirstName] + ' ' + [LastName] AS FullName,
                JobTitle,
                Salary
FROM Employees
ORDER BY Salary DESC


SELECT DISTINCT TOP (10) JobTitle, EmployeeID
FROM [Employees]

SELECT COUNT(DISTINCT JobTitle)
FROM Employees




