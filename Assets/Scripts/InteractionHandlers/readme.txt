--- These scripts provide a way of handling interaction in an abstract way ---

Dependency: Unity's Input System. Uses the name "Interact" for the input action.

= RayInteraction is put on the player object.

= TriggerInteraction is placed on an empty with a trigger collider, parented to the player.

= IInteractable is an interface with empty methods for interaction UseInteraction for RayInteraction and EnterInteraction, ExitInteraction & StayInteraction for TriggerInteraction.

= InteractTest is an example of a script made to work with RayInteraction.

= TriggerTest is an example of a script made to work with TriggerInteraction.


> RayInteraction & TriggerInteraction checks for objects on the selected interaction layers and looks for any scripts that have inherited IInteractable and attempts to run any of the interaction methods on them <


To make something interactable, you make a new script and inherit the IInteractable interface.
Create and select a layer that will be interacted with for example "Interactable" and give it to any object that will be interacted with.

To interact with those objects, use one or multiple of the available interaction methods in your new script by using the provided method names.


- RayInteraction

(Editor Only) The bool isFromMouse decides where the ray is cast from.
isFromMouse = true -> Where the cursor is on the screen
isFromMouse = false -> Center of the player object (+1 on the Y axis)

The ray checks objects for any script that have inherited IInteractable and runs UseInteraction() on it.


- TriggerInteraction

Make sure that the object interacted with through TriggerInteraction has Rigidbody (Kinematic if needed).