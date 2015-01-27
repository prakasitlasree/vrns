Imports System.ServiceProcess

Namespace VRNS_Service
    NotInheritable Class Program
        Private Sub New()
        End Sub
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        Public Shared Sub Main()
            Dim ServicesToRun As ServiceBase()
            ServicesToRun = New ServiceBase() {New VRNS_Service()}
            ServiceBase.Run(ServicesToRun)
        End Sub

    End Class
End Namespace