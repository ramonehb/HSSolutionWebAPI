Create or Alter Function [dbo].[GetDateLocal]()
Returns DateTime
With SchemaBinding
As 
Begin
    Declare @DateTime DateTime = SysDateTimeOffSet() At Time Zone 'E. South America Standard Time'
    Return @DateTime
End
Go