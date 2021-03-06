'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized

Namespace EntityModel
    <Serializable()> _
    Partial Public Class VRNS_JOB
        #Region "Primitive Properties"
    
        Public Overridable Property ID As Integer
    
        Public Overridable Property CODE As String
    
        Public Overridable Property Description As String
    
        Public Overridable Property LAST_UPD As Nullable(Of Date)
    
        Public Overridable Property LAST_UPD_LOGIN As String
    
        Public Overridable Property LAST_UPD_DISPLAY_NM As String

        #End Region
        #Region "Navigation Properties"
        Public Overridable Property VRNS_Maintainance_Record As ICollection(Of VRNS_Maintainance_Record)
            Get
                If _vRNS_Maintainance_Record Is Nothing Then
                    Dim newCollection As New FixupCollection(Of VRNS_Maintainance_Record)
                    AddHandler newCollection.CollectionChanged, AddressOf FixupVRNS_Maintainance_Record
                    _vRNS_Maintainance_Record = newCollection
                End If
                Return _vRNS_Maintainance_Record
            End Get
            Set(ByVal value As ICollection(Of VRNS_Maintainance_Record))
                If _vRNS_Maintainance_Record IsNot value Then
                    Dim previousValue As FixupCollection(Of VRNS_Maintainance_Record) = TryCast(_vRNS_Maintainance_Record, FixupCollection(Of VRNS_Maintainance_Record))
                    If previousValue IsNot Nothing Then
                        RemoveHandler previousValue.CollectionChanged, AddressOf FixupVRNS_Maintainance_Record
                    End If
                    _vRNS_Maintainance_Record = value
                    Dim newValue As FixupCollection(Of VRNS_Maintainance_Record) = TryCast(value, FixupCollection(Of VRNS_Maintainance_Record))
                    If newValue IsNot Nothing Then
                        AddHandler newValue.CollectionChanged, AddressOf FixupVRNS_Maintainance_Record
                    End If
                End If
            End Set
        End Property
        Private _vRNS_Maintainance_Record As ICollection(Of VRNS_Maintainance_Record)
        Public Overridable Property VRNS_Maintainance_Record1 As ICollection(Of VRNS_Maintainance_Record)
            Get
                If _vRNS_Maintainance_Record1 Is Nothing Then
                    Dim newCollection As New FixupCollection(Of VRNS_Maintainance_Record)
                    AddHandler newCollection.CollectionChanged, AddressOf FixupVRNS_Maintainance_Record1
                    _vRNS_Maintainance_Record1 = newCollection
                End If
                Return _vRNS_Maintainance_Record1
            End Get
            Set(ByVal value As ICollection(Of VRNS_Maintainance_Record))
                If _vRNS_Maintainance_Record1 IsNot value Then
                    Dim previousValue As FixupCollection(Of VRNS_Maintainance_Record) = TryCast(_vRNS_Maintainance_Record1, FixupCollection(Of VRNS_Maintainance_Record))
                    If previousValue IsNot Nothing Then
                        RemoveHandler previousValue.CollectionChanged, AddressOf FixupVRNS_Maintainance_Record1
                    End If
                    _vRNS_Maintainance_Record1 = value
                    Dim newValue As FixupCollection(Of VRNS_Maintainance_Record) = TryCast(value, FixupCollection(Of VRNS_Maintainance_Record))
                    If newValue IsNot Nothing Then
                        AddHandler newValue.CollectionChanged, AddressOf FixupVRNS_Maintainance_Record1
                    End If
                End If
            End Set
        End Property
        Private _vRNS_Maintainance_Record1 As ICollection(Of VRNS_Maintainance_Record)

        #End Region
        #Region "Association Fixup"
        Private Sub FixupVRNS_Maintainance_Record(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            If e.NewItems IsNot Nothing Then
                For Each item As VRNS_Maintainance_Record In e.NewItems
                    item.VRNS_JOB = Me
                Next
            End If
            If e.OldItems IsNot Nothing Then
                For Each item As VRNS_Maintainance_Record In e.OldItems
                    If item.VRNS_JOB Is Me Then
                        item.VRNS_JOB = Nothing
                    End If
                Next
            End If
        End Sub
        Private Sub FixupVRNS_Maintainance_Record1(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            If e.NewItems IsNot Nothing Then
                For Each item As VRNS_Maintainance_Record In e.NewItems
                    item.VRNS_JOB1 = Me
                Next
            End If
            If e.OldItems IsNot Nothing Then
                For Each item As VRNS_Maintainance_Record In e.OldItems
                    If item.VRNS_JOB1 Is Me Then
                        item.VRNS_JOB1 = Nothing
                    End If
                Next
            End If
        End Sub

        #End Region
    End Class
End Namespace
