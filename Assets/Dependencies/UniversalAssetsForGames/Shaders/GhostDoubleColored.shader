Shader "Nettle/Ghost_DoubleColored"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_GlowColor("Hint color", color) = (0,1,0,1)
		_GlowLightness("Hint lightness", Range(0,1)) = 0.2
		_EdgeThickness("EdgeThickness", Float) = 0.5
     }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue" = "Transparent" }
        LOD 100

		ZWrite Off
		Blend SrcAlpha One

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
				float3 normal: NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
				float3 worldPos : TEXCOORD1;
				float3 normal:TEXCOORD2;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float4 _Color;
			float4 _GlowColor;
			float _EdgeThickness;
			float _GlowLightness;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.worldPos = mul(UNITY_MATRIX_M, v.vertex);
				o.normal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
				float3 viewDir = normalize(_WorldSpaceCameraPos - i.worldPos);
				float dotProd = saturate(dot(viewDir,i.normal));
				col.rgb*=1-pow(dotProd,_EdgeThickness);
				col.rgb+= _GlowColor.rgb * _GlowLightness;
                return col;
            }
            ENDCG
        }
    }
}
