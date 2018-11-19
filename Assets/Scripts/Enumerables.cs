public enum GameStates{
	Running,
	Paused,
	GameOver

}

public enum PlayerState{
	OnAir,
	OnGround,
	KnockedBack,
	Dead

}

public enum ObstacleReactionType{
	None,
	ByHidenCollision,
	ByDistance,
	ByDelayedCollision

}

public enum SceneNumber{
	MainMenu = 0,
	GamePlay = 1
	
}

public enum SFXState{
	disabled,
    enabled
}

public enum BGMState{
	disabled,
    enabled
}