Imports System.Data
Imports System.Security.Cryptography

Partial Class Seguridad_UsuarioCon
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim obj As Usuarios = New Usuarios()
        'Me.GridView1.DataSource = obj.GetAllUsers()
        'Me.DataBind()
        Me.GridView2.Visible = False

    End Sub

    
    Function Encode(ByVal dec As String) As String

        Dim bt() As Byte
        ReDim bt(dec.Length)

        bt = System.Text.Encoding.ASCII.GetBytes(dec)


        Dim enc As String
        enc = System.Convert.ToBase64String(bt)

        Return enc
    End Function
    Function Decode(ByVal enc As String) As String
        Dim bt() As Byte

        bt = System.Convert.FromBase64String(enc)


        Dim dec As String
        dec = System.Text.Encoding.ASCII.GetString(bt)


        Return dec


    End Function

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.TextBox1.Text = DecryptString(Me.TextBox2.Text, "BORISGONZALEZ")
    End Sub

    '---------------
    Public Shared Function EncryptString(ByVal InputString As String, ByVal SecretKey As String, Optional ByVal CyphMode As CipherMode = CipherMode.ECB) As String
        Try
            Dim Des As New TripleDESCryptoServiceProvider
            'Put the string into a byte array
            Dim InputbyteArray() As Byte = Encoding.UTF8.GetBytes(InputString)
            'Create the crypto objects, with the key, as passed in
            Dim hashMD5 As New MD5CryptoServiceProvider
            Des.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(SecretKey))
            Des.Mode = CyphMode
            Dim ms As IO.MemoryStream = New IO.MemoryStream
            Dim cs As CryptoStream = New CryptoStream(ms, Des.CreateEncryptor(), _
            CryptoStreamMode.Write)
            'Write the byte array into the crypto stream
            '(It will end up in the memory stream)
            cs.Write(InputbyteArray, 0, InputbyteArray.Length)
            cs.FlushFinalBlock()
            'Get the data back from the memory stream, and into a string
            Dim ret As StringBuilder = New StringBuilder
            Dim b() As Byte = ms.ToArray
            ms.Close()
            Dim I As Integer
            For I = 0 To UBound(b)
                'Format as hex
                ret.AppendFormat("{0:X2}", b(I))
            Next
            Return ret.ToString()
        Catch ex As System.Security.Cryptography.CryptographicException
            Return ex.Message
        End Try

    End Function

    Public Shared Function DecryptString(ByVal InputString As String, ByVal SecretKey As String, Optional ByVal CyphMode As CipherMode = CipherMode.ECB) As String
        If InputString = String.Empty Then
            Return ""
        Else
            Dim Des As New TripleDESCryptoServiceProvider
            'Put the string into a byte array
            Dim InputbyteArray(CType(InputString.Length / 2 - 1, Integer)) As Byte '= Encoding.UTF8.GetBytes(InputString)
            'Create the crypto objects, with the key, as passed in
            Dim hashMD5 As New MD5CryptoServiceProvider

            Des.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(SecretKey))
            Des.Mode = CyphMode
            'Put the input string into the byte array

            Dim X As Integer

            For X = 0 To InputbyteArray.Length - 1
                Dim IJ As Int32 = (Convert.ToInt32(InputString.Substring(X * 2, 2), 16))
                Dim BT As New ComponentModel.ByteConverter
                InputbyteArray(X) = New Byte
                InputbyteArray(X) = CType(BT.ConvertTo(IJ, GetType(Byte)), Byte)
            Next

            Dim ms As IO.MemoryStream = New IO.MemoryStream
            Dim cs As CryptoStream = New CryptoStream(ms, Des.CreateDecryptor(), _
            CryptoStreamMode.Write)

            'Flush the data through the crypto stream into the memory stream
            cs.Write(InputbyteArray, 0, InputbyteArray.Length)
            cs.FlushFinalBlock()

            '//Get the decrypted data back from the memory stream
            Dim ret As StringBuilder = New StringBuilder
            Dim B() As Byte = ms.ToArray

            ms.Close()

            Dim I As Integer

            For I = 0 To UBound(B)
                ret.Append(Chr(B(I)))
            Next

            Return ret.ToString()
        End If
    End Function


    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.TextBox2.Text = EncryptString(Me.TextBox1.Text, "BORISGONZALEZ")
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.TextBox3.Text = EncryptString(Me.TextBox1.Text, "ANYAMIYETH")
    End Sub
End Class
