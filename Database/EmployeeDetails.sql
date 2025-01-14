USE [EmployeeDetails]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 09/27/2020 00:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[ContactNo] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[CreateDateTime] [datetime] NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Employee_Login]    Script Date: 09/27/2020 00:40:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employee_Login] 
(

	 @Email nvarchar(100) = null,
	 @Password nvarchar(100)= null
)
AS
BEGIN
    BEGIN TRY
        
            BEGIN
				
			SELECT ''  AS ErrorMessage,0 ErrorCode,
			Id=ISNULL(Id,0)
			
			
			 FROM [dbo].[Registration]
				WHERE (@Email = Email and @Password = Password)
				
            END

		

    END TRY
    BEGIN CATCH
        DECLARE @ErrorMsg VARCHAR(MAX)
		SET @ErrorMsg = ERROR_MESSAGE();
        RAISERROR ('Error in [Employee_Login] :%s', 15, 1, @ErrorMsg)
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Emp_Registration]    Script Date: 09/27/2020 00:40:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Emp_Registration] (
@Id INT=0,
@FirstName NVARCHAR(100)=NULL,
@LastName NVARCHAR(100)=NULL,
@Email NVARCHAR(256)=NULL,
@Password NVARCHAR(256) = NULL,
@ContactNo NVARCHAR(256)=NULL,
@IsActive BIT=null
)
AS
BEGIN
    BEGIN TRY
	

        IF (@Id = 0)
            BEGIN
						IF EXISTS (SELECT 1 FROM [dbo].[Registration] r WITH (NOLOCK) WHERE r.Email = @Email AND IsActive = 1)
						BEGIN
						  SELECT '' AS ErrorMessage, ErrorCode = -1
						  RETURN;
						END
						IF EXISTS (SELECT 1 FROM [dbo].[Registration] r WITH (NOLOCK) WHERE r.ContactNo = @ContactNo AND IsActive = 1)
						BEGIN
						  SELECT '' AS ErrorMessage, ErrorCode = -1
						  RETURN;
						END
                    BEGIN
						INSERT INTO [dbo].[Registration] (FirstName,LastName,ContactNo,Email,Password,IsActive,CreateDateTime)
                        VALUES (@FirstName,@LastName,@ContactNo,@Email,@Password,1,GETDATE())
						 
						
						   SET @Id = SCOPE_IDENTITY();
					END
					Select @Id  AS Result
				End	

		
		
		
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMsg VARCHAR(MAX)
        SET @ErrorMsg = ERROR_MESSAGE();
        RAISERROR ('Error in  data :%s', 15, 1, @ErrorMsg)
    END CATCH
END
GO
