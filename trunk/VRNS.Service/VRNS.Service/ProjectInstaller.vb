Imports System.ComponentModel
Imports System.Configuration.Install

 
Namespace VRNS_Service
    <RunInstaller(True)> _
    Partial Public Class ProjectInstaller
        Inherits System.Configuration.Install.Installer
        Private serviceProcessInstaller1 As System.ServiceProcess.ServiceProcessInstaller
        Private serviceInstaller1 As System.ServiceProcess.ServiceInstaller
        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

        
    End Class
End Namespace