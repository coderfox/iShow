''' <summary>
''' miniPlatform INI读取类
''' </summary>
''' <remarks></remarks>
Public Class ini
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32

    Private Declare Function GetPrivateProfileStringW Lib "kernel32" Alias "GetPrivateProfileStringW" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32
    Private Declare Function WritePrivateProfileStringW Lib "kernel32" Alias "WritePrivateProfileStringW" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32
    'mbcs
    ''' <summary>
    ''' INI读取
    ''' </summary>
    ''' <param name="Section">节点</param>
    ''' <param name="AppName">属性名</param>
    ''' <param name="lpDefault">出错返回</param>
    ''' <param name="FileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As String
        Dim MyEncoder As System.Text.Encoding = System.Text.Encoding.Default
        Dim chars(2048) As Char
        Dim strResult As String = New String(chars)
        Dim length As Integer = GetPrivateProfileString(Section, AppName, lpDefault, strResult, Len(strResult), FileName)
        '编码的转换
        Dim rByte() As Byte = System.Text.Encoding.Default.GetBytes(strResult.ToCharArray)
        strResult = New String(MyEncoder.GetChars(rByte))
        Return Microsoft.VisualBasic.Left(strResult, InStr(strResult, Chr(0)) - 1)
    End Function
    '写文件
    ''' <summary>
    ''' 写入INI
    ''' </summary>
    ''' <param name="Section">节点</param>
    ''' <param name="AppName">属性名</param>
    ''' <param name="lpDefault">属性文本</param>
    ''' <param name="FileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As Long
        WriteINI = WritePrivateProfileString(Section, AppName, lpDefault, FileName)
    End Function
    'unicode
    ''' <summary>
    ''' UNICODE的INI读取
    ''' </summary>
    ''' <param name="Section">节点</param>
    ''' <param name="AppName">属性名</param>
    ''' <param name="lpDefault">出错返回</param>
    ''' <param name="FileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetINIW(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As String
        Dim MyEncoder As System.Text.Encoding = System.Text.Encoding.Default
        Dim strResult As String
        Dim chars(2048) As Char
        strResult = CStr(chars)
        GetPrivateProfileStringW(Section, AppName, lpDefault, strResult, Len(strResult), FileName)

        Dim rByte() As Byte = System.Text.Encoding.Default.GetBytes(strResult.ToCharArray)
        strResult = New String(MyEncoder.GetChars(rByte))
        Return Microsoft.VisualBasic.Left(strResult, InStr(strResult, Chr(0)) - 1)
    End Function
    '写文件
    ''' <summary>
    ''' UNICODE的写入INI
    ''' </summary>
    ''' <param name="Section">节点</param>
    ''' <param name="AppName">属性名</param>
    ''' <param name="lpDefault">属性文本</param>
    ''' <param name="FileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteINIW(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As Long
        WriteINIW = WritePrivateProfileStringW(Section, AppName, lpDefault, FileName)
    End Function
End Class