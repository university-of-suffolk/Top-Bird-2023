Shader "Custom/RainbowShader" {
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _Speed("Speed", Range(-5, 5)) = 1
    }
        SubShader{
            Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
            Pass {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float _Speed;

                v2f vert(appdata v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target {
                    float4 rainbow = float4(1, 0, 0, 1);

                    // Calculate the position of the current pixel in the texture
                    float2 texCoord = i.uv;

                    // Rotate the texture coordinates by 22 degrees around the center of the texture
                    float2 center = float2(0.5, 0.5);
                    float2 rotatedTexCoord = float2(
                        (texCoord.x - center.x) * cos(0.38397244) - (texCoord.y - center.y) * sin(0.38397244) + center.x,
                        (texCoord.x - center.x) * sin(0.38397244) + (texCoord.y - center.y) * cos(0.38397244) + center.y
                    );

                    // Calculate the color of the rainbow based on the x-position of the rotated texture coordinate
                    rainbow.r = sin(rotatedTexCoord.x * 8.0 + _Time.y * _Speed) * 0.5 + 0.5;
                    rainbow.g = sin(rotatedTexCoord.x * 8.0 + _Time.y * _Speed + 2.0) * 0.5 + 0.5;
                    rainbow.b = sin(rotatedTexCoord.x * 8.0 + _Time.y * _Speed + 4.0) * 0.5 + 0.5;

                    return rainbow;
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}
