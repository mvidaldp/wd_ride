This package contains 5 different types of animated traffic-lights (US and EU style).

Just drag the prefabs into your scene and arrange them as you like.

The package also contains a configurable script for the light-animation.

You may also want to have a look at the example scene that contains all the prefabs.

All single objects using between 1500 und 5000 polygons.

Textures-sizes 1024x1024.

The original FBX-file is also included in the package.

 
------------------------------------------------------------------------
Parameter documentation:
------------------------

When you drag one of the EU-Traffic-Lights into your scene, you will find
some parameters in the Inspector:

-Traffic_light_active: 			enables/disables the whole funcionality of the single traffic light
-Traffic_light_out_of_order_mode: 	-If this is set inactive the traffic light will work in normal switch mode
					-If this is set active the traffic light will only show a flashing yellow light
-Crossway Direction:			-Here you can choose one the two crossing road directions 
-Direction_time:			-This value defines the time the traffic lights stays green/red in one direction

-Use_real_lights:			-if this is enabled real point lights will be used for each single light
-Traffic_light_type_single (only EU)	-This defines how many lightpanels are used in this construction (1 or 2). 
					 The preset is like it should be, so better do not change this!
-Real_lights_range:			-Only needed if "Use_real_lights" is enabled. This defines the Light-Falloff for all 
                                         Lights in this construction
-Cast_shadows:				-Only needed if "Use_real_lights" is enabled. Here you can enabled / disable shadow-casting 
					 for all Lights in this construction.

Notice: -The used Lights for the Realtime Lights are Pointlights. Cast Shadows will only work in Deferred Lighting
         Unity Pro needed for realtime Shadows!

	-In the default-configuration no traffic light uses realtime lights or shadows.

	-If too many Lights are used, this might slow down your scene!


For futher questions mail to: info@vis-games.de  
			      Mail Subject: Unity Traffic Lights

Your VIS-Games Team	