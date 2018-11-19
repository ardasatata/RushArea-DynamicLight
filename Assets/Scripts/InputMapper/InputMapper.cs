using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMapper : MonoBehaviour {
	Dictionary<InputCode, List<KeyCode>> inputMaps = new Dictionary<InputCode, List<KeyCode>>();
	Dictionary<KeyCode, int> inputAxis = new Dictionary<KeyCode, int>();

	InputMaps imaps = new InputMaps();


	private static InputMapper instance = null;

	private InputMapper()
	{
		
		addInputMaps (InputCode.Jump, KeyCode.Space, 1 );
		addInputMaps (InputCode.MoveRight, KeyCode.RightArrow, 1);
		addInputMaps (InputCode.MoveLeft, KeyCode.LeftArrow, -1);

	}

	public static InputMapper Instance
	{
		get
		{
			if (instance==null)
			{
				instance = new InputMapper();
			}
			return instance;
		}
	}

	//--------------------------------------------------------------------------------------------------------------------

	public void addInputMaps(InputCode action, KeyCode key, int axis){
		List<KeyCode> listKey;
		if (inputMaps.ContainsKey(action)) {
			listKey = inputMaps [action];
			inputMaps.Remove (action);
		} else {
			listKey = new List<KeyCode> ();
		}

		listKey.Add (key);
		inputMaps.Add (action, listKey);
		inputAxis.Add (key, axis);
	}

	public void removeInputMaps(InputCode action, KeyCode key){
		if (inputMaps.ContainsKey(action)) {
			inputMaps.Remove (action);
		}
	}

	public void changeInputMaps(InputCode action, KeyCode oldKey, KeyCode newKey, int axis){
		List<KeyCode> listKey;
		if (inputMaps.ContainsKey(action)) {
			listKey = inputMaps [action];
			inputMaps.Remove (action);
		} else {
			addInputMaps (action, newKey, axis);
			return;
		}

		if (listKey.Contains (oldKey)) {
			listKey.Remove (oldKey);
			inputAxis.Remove (oldKey);
			listKey.Add (newKey);
			inputAxis.Add (newKey, axis);
		} else {
			return;
		}

		inputMaps.Add (action, listKey);

	}

	//--------------------------------------------------------------------------------------------------------------------

	// Keydown method
	// dipanggil ketika key telah ditekan
	public bool getKeyDown (InputCode action){
		List<KeyCode> listKey = inputMaps [action];

		for (int i = 0; i < listKey.Count; i++) {
			if(Input.GetKeyDown(listKey[i])){
				return true;
			}
		}
		return false;
	}

	// Key / Hold-key method
	// dipanggil ketika key sedang ditekan
	public bool getKey (InputCode action){
		List<KeyCode> listKey = inputMaps [action];

		for (int i = 0; i < listKey.Count; i++) {
			if(Input.GetKey(listKey[i])){
				return true;
			}
		}
		return false;
	}


	// Key up method
	// dipanggil ketika key diangkat setelah ditekan (down/hold)
	public bool getKeyUp (InputCode action){
		List<KeyCode> listKey = inputMaps [action];

		for (int i = 0; i < listKey.Count; i++) {
			if(Input.GetKeyUp(listKey[i])){
				return true;
			}
		}
		return false;
	}



	// Debugger
	void Update () {
		
	}
}
