# Gcode Random Mixer
This is a simple windows form app to modify Gcode with random extruder mix ratio after line that begins with search string. 
It defaults to searching on `;LAYER:`, the default comment Cura outputs at the start of each layer.  
It assumes that all extruders will always have at least 1% extrusion to prevent clogging. 
