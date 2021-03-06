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
    ' An System.Collections.ObjectModel.ObservableCollection that raises
    ' individual item removal notifications on clear and prevents adding duplicates.
    Public Class FixupCollection(Of T)
        Inherits ObservableCollection(Of T)
        Protected Overrides Sub ClearItems()
            Dim items As New List(Of T)(Me)
            items.ForEach(Sub(t) Remove(t))
        End Sub
    
        Protected Overloads Overrides Sub InsertItem(ByVal index As Integer, ByVal item As T)
            If Not Me.Contains(item) Then
                MyBase.InsertItem(index, item)
            End If
        End Sub
    End Class
End Namespace
