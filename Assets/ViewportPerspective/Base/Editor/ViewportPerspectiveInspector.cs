﻿/*
	Created by Carl Emil Carlsen.
	Copyright 2017 Sixth Sensor.
	All rights reserved.
	http://sixthsensor.dk
*/

using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ViewportPerspective))]
[CanEditMultipleObjects]
public class ViewportPerspectiveInspector : Editor
{
	SerializedProperty _interactable;
	SerializedProperty _edgeAntialiasing;
	SerializedProperty _runtimeSerialization;
	SerializedProperty _interactableHotkey;
	SerializedProperty _resetHotkey;

	SerializedProperty _hotkeyFold;


	void OnEnable()
	{
		_interactable = serializedObject.FindProperty( "_interactable" );
		_edgeAntialiasing = serializedObject.FindProperty( "_edgeAntialiasing" );
		_runtimeSerialization = serializedObject.FindProperty( "_runtimeSerialization" );
		_interactableHotkey = serializedObject.FindProperty( "_interactableHotkey" );
		_resetHotkey = serializedObject.FindProperty( "_resetHotkey" );
		_hotkeyFold = serializedObject.FindProperty( "_hotkeyFold" );
	}


	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField( _interactable );

		EditorGUILayout.PropertyField( _edgeAntialiasing );

		EditorGUI.BeginDisabledGroup( Application.isPlaying );
		EditorGUILayout.PropertyField( _runtimeSerialization );
		EditorGUI.EndDisabledGroup();

		_hotkeyFold.boolValue = EditorGUILayout.Foldout( _hotkeyFold.boolValue, "Hotkeys" );
		if( _hotkeyFold.boolValue){
			EditorGUI.indentLevel++;
			EditorGUILayout.PropertyField( _interactableHotkey,  new GUIContent( "Interactable" ) );
			EditorGUILayout.PropertyField( _resetHotkey, new GUIContent( "Reset" ) );
			EditorGUI.indentLevel--;
		}

		serializedObject.ApplyModifiedProperties();
	}
}