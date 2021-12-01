Shader "Unlit/UIButton"
{
    Properties
    {
        _Color("Color",Color) = (1,1,1,1)
        [HDR]
        _EmissionColor("Emission Color",Color) = (0,0,0,1)
        _MainTex ("Texture", 2D) = "white" {}
        _ShadeStrength("Shade strength", Range(0,1)) =  1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float3 normal:TEXCOORD2;
                float3 view:TEXCOORD3;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _ShadeStrength;
            fixed4 _Color;
            fixed4 _EmissionColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                float3 worldPos = mul(UNITY_MATRIX_M, v.vertex);
                o.view = _WorldSpaceCameraPos - worldPos;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                float diffuse = dot(normalize(i.view), normalize(i.normal));
                col *= lerp(1, diffuse, _ShadeStrength);
                col += _EmissionColor;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
