using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node3D
{
	[Signal]
	public delegate void StateChangedEventHandler(State newState, State prevState, StateMachine machine);

	[Export]
	public State initialState;

	private Dictionary<string, State> states;
	public State currentState;
	public State prevState;

    public override void _Ready()
    {
        states = new Dictionary<string, State>();
		foreach (Node node in GetChildren()) {
			if(node is State s) {
				states[node.Name] = s;
				s.fsm = this;
				s.Start();
				s.Exit();
			}
		}

		currentState = initialState;
		currentState.Enter();
    }

    public override void _Process(double delta) {
        currentState.Process((float) delta);
    }

    public override void _PhysicsProcess(double delta) {
        currentState.PhysicsProcess((float) delta);
    }

    public override void _UnhandledInput(InputEvent @event) {
        currentState.HandleInput(@event);
    }

	public void TransitionTo (string key) {
		if (!states.ContainsKey(key) || currentState == states[key])
			return;

		prevState = currentState;

		currentState.Exit();
		currentState = states[key];
		currentState.Enter();

		EmitSignal(SignalName.StateChanged, currentState, prevState, this);
	}

	public State GetCurrentState() {
		return currentState;
	}
}
