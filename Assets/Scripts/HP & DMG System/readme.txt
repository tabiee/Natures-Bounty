= Health & Damage System =

This provides a small health system for the player and any unit (enemy or object doesn't matter)

> HealthSystem - Stores the HP and handles modifying it, negative numbers reduce HP, positive heal HP.
You don't need to write negative numbers each time you want to do damage, that is built into the damaging methods on the other scripts.
Instances of this class are created in the other scripts.

> PlayerHealth - Singleton, has methods for dealing damage or healing the player. DamagePlayer() & HealPlayer() use ModifyHealth inside HealthSystem.
UpdateHealthBar() updates the Image present on the prefab.

> UnitHealth - Same as PlayerHealth but not a singleton.


+ TestHP is an example script where you can press buttons to see the health system working through debug.logs and the health bars.