 ____    ___  _____                
|  __ \ / _ \/  __ \               
| |  \// /_\ \ /  \/ ___  _ __ ___ 
| | __ |  _  | |    / _ \| '__/ _ \
| |_\ \| | | | \__/\ (_) | | |  __/
 \____/\_| |_/\____/\___/|_|  \___|
                                  
https://github.com/GuidanceAutomation/GACore
https://www.guidanceautomation.com/

v1.19.1 (21st Nov 19)

* ViewModel HandleModelUpdate() now returns old and new values to faciltate better event handling.

v1.19.0 (21st Nov 19)

* Adds GetTempFilenameWithExtension to tools

v1.18.0 (20th Nov 19)

* Adds Abstract Collection View Model for self maintaining observable collection of view models.

v1.17.2 (12th Nov 19)

* Extended WPF Toolkit (http://schemas.xceed.com/wpf/xaml/toolkit) style sheet

v1.17.1 (8th Nov 19)

* View Bugfix

v1.17.0 (6th Nov 19)

* Adds CustomCommand object for MVVM

v1.16.0 (6th Nov 19)

* Adds messenger utility for inter-view model signalling. 
* Adds logger for view models

v1.15.0 (29th Oct 19)

* Switches to MVVM pattern for KingpinState and KingpinStatus views. 
* Allows views to update at FPS rate, rather than kingpin state updates which may occur at high frequency and flood dispatcher thread. 

v1.14.1 (29th Oct 19)

* Adds boilerplate MVVM components

v1.14.0 (14th Oct 19)

* Adds enumerators for Task type, Status, etc. 

v1.13.1 (8th Oct 19)

* Fixes missing abs check to AreWithinRadTol.

v1.13.0 (8th Oct 19)

* Adds AreWithinRadTol to Maths. 

v1.12.2 (26th Sep 19)

* .net472 framework 
* Removes duplicate extension methods between GACore.ExtensionMethods (class) and GACore.ExtensionMethods (assemblies).

v1.12.1 (26th Sep 19)

* Adds GACore.Extensions	
** Useful extension methods (50+)
** Mainly for manipulating collections
* Adds GACore.Generics
** Containers for comparative objects
* Adds Tignometry static tools
* Adds Maths static tools 
** LinSpace for creating linearly spaced arrays

v1.11.1 (25th Sep 19)

* Adds missing methods on ResultFactory

v1.11.0 (25th Sep 19)

* Adds ResultFactory

v1.10.0 (23rd Sep 19)

* Adds IResult and IGenericResult<T> interfaces and implementations. 

v1.9.0 (18th Sep 19)

* Adds NLogManager and associated components.

v1.8.2 (16th Sep 19)

* Removes poorly thought-out value constraint on key for GenericMailbox.

v1.8.1 (16th Sep 19)

* Fixes GenericMailbox failed branch merge.

v1.8.0 (16th Sep 19)

* Add GenericMailbox

v1.7.0 (9th Sep 19)

* Adds IPV4 control

v1.6.0 (20th Aug 19)

* Adds KingpinStateControl & children
* Adds IsConnectedControl
* Completes abstraction of kingpin state to a single package.

v1.5.0 (16th Aug 19)

* Adds KingpinFaultSatus code to diagnoise IKingpinStates for faults.

v1.4.0 (16th Aug 19)

* Adds MovementType enumerators
* Extends IKingpinState to include movement type. 

v1.3.2 (14th Aug 19)

* Fixes KingpinStateData not implementing IKingpinState

v1.3.1 (14th Aug 19)

* Adds GACore.Architecture assembly
* Moves some enums defs to GACore => GACore.Architecture
* Adds interface definition for IKingpinState

v1.3.0 (14th Aug 19)

* Adds KingpinStateData object.
* Adds enum definitions for frozen and auto control.
* Adds extension method for tick comparison.

v1.2.0 (13th Aug 19)

* Adds SemVerData object.

v1.1.0 (12th Aug 19)

* Adds Banner Q45 control.

v1.0.0 (6th Aug 19)

- Initial release
* Kingpin state enumerators
* Kingpin status control
