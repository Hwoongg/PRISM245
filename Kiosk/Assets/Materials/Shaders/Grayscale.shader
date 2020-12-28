Shader "Custom/Grayscale"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		//_TipPos("Tip Position", Vector) = (0, 0, 0, 0)
		//_HandTex("Hand Texture", 2D) = "black" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

			//float4 _TipPos;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
				
				if (col.r != 0)
				{
					// Convert Gray Scale
					fixed4 gray;
					gray.r = col.r;
					gray.g = col.r;
					gray.b = col.r;
					col.rgb = gray;
				}

				/*if (i.uv.x - 0.1f < _TipPos.x && i.uv.x + 0.1f > _TipPos.x)
				{
					col.r = 0;
					col.g = 1;
					col.b = 0;
				}*/

                return col;
            }
            ENDCG
        }
    }
}
