
-- Step 1: Create a new file in the new filegroup
ALTER DATABASE BobsShoes
ADD FILE (
    NAME = BobsData,
    FILENAME = 'C:\SQLFiles\BobsShoes2\BobsData.mdf', -- Replace with the desired file path and name
    SIZE = 100MB, -- Specify the initial size of the file
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 10MB -- Specify the file growth increment
)
TO FILEGROUP BobsShoes2;

SELECT * FROM sys.filegroups
ALTER DATABASE [BobsShoes] REMOVE FILEGROUP BobsData
SELECT * FROM sys.master_files

