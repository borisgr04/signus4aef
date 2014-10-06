Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace Tawammar.CustomControls

    ''' <summary> 
    ''' Summary description for Filter 
    ''' </summary> 
    <Serializable()> _
    Public Class Filter
        Private m_operation As String
        Public Property Operation() As String
            Get
                Return m_operation
            End Get
            Set(ByVal value As String)
                m_operation = value
            End Set
        End Property

        Private m_columnName As String
        Public Property ColumnName() As String
            Get
                Return m_columnName
            End Get
            Set(ByVal value As String)
                m_columnName = value
            End Set
        End Property

        Private m_columnValue As String
        Public Property ColumnValue() As String
            Get
                Return m_columnValue
            End Get
            Set(ByVal value As String)
                m_columnValue = value
            End Set
        End Property

        Public Sub New()

        End Sub
        Public Sub New(ByVal columnName As String, ByVal operation As String, ByVal columnValue As String)
            Me.m_columnName = columnName
            Me.m_operation = operation

            Me.m_columnValue = columnValue
        End Sub
        Public Overloads Overrides Function ToString() As String
            Return ((m_columnName & " ") + m_operation & " ") + m_columnValue
        End Function
    End Class
End Namespace
