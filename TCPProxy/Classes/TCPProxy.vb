Imports System.Net.Sockets

Class TCPProxy
    Private _HostPort As Integer
    Private _RemoteAdress As String
    Private _RemotePort As Integer

    Private Clients As New List(Of TCPProxyClient)
    Private Server As TcpListener

    Public Shared Async Function Start(HostPort As Integer, RemoteAddress As String, RemotePort As Integer) As Task
        Dim X As New TCPProxy(HostPort, RemoteAddress, RemotePort)
        Await X.Start()
    End Function

    Private Sub New(HostPort As Integer, RemoteAddress As String, RemotePort As Integer)
        _HostPort = HostPort
        _RemoteAdress = RemoteAddress
        _RemotePort = RemotePort
    End Sub

    Private Async Function Start() As Task
        Server = New TcpListener(Net.IPAddress.Any, _HostPort)
        Server.Start()

        Dim TcpClient As New TcpClient

        While True
            Try
                TcpClient = Await Server.AcceptTcpClientAsync
                Dim Handle As New TCPProxyClient(TcpClient, _RemoteAdress, _RemotePort)
                Clients.Add(Handle)
                Await Handle.Start()
            Catch ex As Exception
#If DEBUG Then
                Debug.Assert(False)
#End If
            End Try
        End While
    End Function

End Class
