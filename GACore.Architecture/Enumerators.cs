using System.Runtime.Serialization;

namespace GACore.Architecture
{
	/// <summary>
	/// Enum to indicate job status.
	/// </summary>
	[DataContract]
	public enum JobStatus
	{
		[EnumMember]
		Assembly = 0,

		[EnumMember]
		Assigning = 1,

		[EnumMember]
		Waiting = 2,

		[EnumMember]
		InProgress = 3,

		[EnumMember]
		Completed = 4,

		[EnumMember]
		Aborting = 5,

		[EnumMember]
		Aborted = 6,

		[EnumMember]
		Editing = 7,

		[EnumMember]
		Failing = 8,

		[EnumMember]
		Failed = 9,

		[EnumMember]
		PartiallyCompleted = 10
	}

	[DataContract]
	public enum OccupyingMandateState
	{
		[EnumMember]
		None = 0,

		[EnumMember]
		InProgress = 1,

		[EnumMember]
		Occupied = 2,

		[EnumMember]
		TimedOut = 3,

		[EnumMember]
		AwaitingPreProcess = 4,

		[EnumMember]
		FailedPreProcessing = 5
	};

	[DataContract]
	public enum TaskStatus
	{
		[EnumMember]
		Unstarted = 0,

		[EnumMember]
		InProgress = 1,

		[EnumMember]
		Completed = 2,

		[EnumMember]
		Aborting = 3,

		[EnumMember]
		Aborted = 4,

		[EnumMember]
		Failing = 5,

		[EnumMember]
		Failed = 6,

		[EnumMember]
		Editing = 7,

		[EnumMember]
		PartiallyCompleted = 8
	};

	[DataContract]
	public enum TaskType
	{
		[EnumMember]
		UnorderedList = 0,

		[EnumMember]
		OrderedList = 1,

		[EnumMember]
		AtomicMoveList = 2,

		[EnumMember]
		ServiceAtNode = 3,

		[EnumMember]
		AwaitAtNode = 4,

		[EnumMember]
		SleepAtNode = 5,

		[EnumMember]
		ChargeAtNode = 6,

		[EnumMember]
		GoToNode = 7,

		[EnumMember]
		AtomicMove = 8
	};

	[DataContract]
	public enum DynamicLimiterStatus : ushort
	{
		[EnumMember]
		OK = 0,

		[EnumMember]
		SafetySensor = 1,

		[EnumMember]
		Warning_1 = 2,

		[EnumMember]
		Warning_2 = 3,

		[EnumMember]
		MotorFault = 4,

		[EnumMember]
		FastStop = 5,

		[EnumMember]
		GoSlow = 6,

		[EnumMember]
		Unknown = 65535
	}

	[DataContract]
	public enum ServiceType
	{
		[EnumMember]
		Charge = 0, // AGVs are able to charge here

		[EnumMember]
		Park = 1, // AGVs are able to park here

		[EnumMember]
		Fault = 2, // AGVs should try to go here if they have a fault

		[EnumMember]
		ManualLoadHandling = 3, // Manual load handling can occur here

		[EnumMember]
		Execution = 4 // ALL NODES SUPPORT - a service to send an AGV to this node and peform an execution instruction
	};

	[DataContract]
	public enum FrozenState
	{
		[EnumMember]
		Frozen = 0,

		[EnumMember]
		Unfrozen = 1
	}

	[DataContract]
	public enum ExtendedDataFaultStatus : byte
	{
		[EnumMember]
		OK = 0,

		[EnumMember]
		Fault = 1
	}

	[DataContract]
	public enum AgvMode
	{
		[EnumMember]
		Automatic = 1,

		[EnumMember]
		Manual = 0
	}

	[DataContract]
	public enum MovementType
	{
		[EnumMember]
		Stationary = 0,

		[EnumMember]
		ClothoidForwards = 1,

		[EnumMember]
		ClothoidBackwards = 2,

		[EnumMember]
		ACRIP = 3, // Anti-clockwise rotate in place

		[EnumMember]
		CRIP = 4, // Clockwise rotate in place

		[EnumMember]
		StrafeLinear = 5, // WSAD

		[EnumMember]
		StrafeClothoidForwards = 6,

		[EnumMember]
		StrafeClothoidBackwards = 7,
	}

	[DataContract]
	public enum NavigationStatus : ushort
	{
		[EnumMember]
		OK = 0,

		[EnumMember]
		Lost = 1,

		[EnumMember]
		AssociationFailure = 2,

		[EnumMember]
		HighUncertainty = 3,

		[EnumMember]
		PoorAssociaton = 4,

		[EnumMember]
		NoResponse = 5,

		[EnumMember]
		Unknown = 65535
	}

	[DataContract]
	public enum PositionControlStatus : ushort
	{
		[EnumMember]
		OK = 0,

		[EnumMember]
		Disabled = 1,

		[EnumMember]
		Disabling = 2,

		[EnumMember]
		NoWaypoints = 3,

		[EnumMember]
		OutOfPosition = 4,

		[EnumMember]
		WaypointDiscontinuity = 5,

		[EnumMember]
		Unknown = 65535
	}
}