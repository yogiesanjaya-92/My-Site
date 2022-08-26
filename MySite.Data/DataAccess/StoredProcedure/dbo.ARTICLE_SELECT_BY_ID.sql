-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ARTICLE_SELECT_BY_ID 
	-- Add the parameters for the stored procedure here
	@ARTICLE_ID UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT cat.CATEGORY_NAME, art.ARTICLE_TITLE, art.ARTICLE_CONTENT, art.ARTICLE_ATTACHMENT, art.ARTICLE_RATE, art.ARTICLE_COMMENT, art.CREATED_BY
	FROM ARTICLE art
	LEFT JOIN ARTICLE_CATEGORY cat ON 
		art.ARTICLE_CATEGORY_ID = cat.CATEGORY_ID
	WHERE art.ARTICLE_ID = @ARTICLE_ID AND art.IS_DELETE = 0
END