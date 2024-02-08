shader_type canvas_item;

uniform sampler2D screen_texture : hint_screen_texture, repeat_disable, filter_nearest;
uniform float brightness = 1.13;

void fragment() {
    // Called for every pixel the material is visible on.
    vec4 pixel_color = texture(screen_texture, SCREEN_UV);

    // Get pixel color from texture (set on the TextureFrame)
    vec4 grid_pixel_color = texture(TEXTURE, UV);

    // If the pixel color from our grid image is dark, set it to be fully transparent
    if(grid_pixel_color.r < 0.5) {
        COLOR = vec4(1,1,1,0); // (red, green, blue, alpha-transparency)
    } 
    else { // Since it is NOT dark, we adjust the pixel color brightness
        COLOR = pixel_color * brightness;
        }
    }