Shader "Unlit/ScreenCutoutShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		Lighting Off
		Cull Back
		ZWrite On
		ZTest Less
		
		Fog{ Mode Off }

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
				UNITY_VERTEX_INPUT_INSTANCE_ID // added
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float4 screenPos : TEXCOORD1;
				UNITY_VERTEX_OUTPUT_STEREO // added
			};

			v2f vert (appdata v)
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v); // added
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); // added
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.screenPos = ComputeScreenPos(o.vertex);
				
				float k = length(WorldSpaceViewDir(v.vertex));

				// HTC Vive
				float offset = 0.027 * (k );

				// Quest 2
				//float offset = 0.06 * (k + 0.1);
				
				o.screenPos.x -= offset;
				o.screenPos.x += 2 * unity_StereoEyeIndex * offset;

				return o;
			}
			
			sampler2D _MainTex;

			fixed4 frag(v2f i) : SV_Target
			{
				i.screenPos /= i.screenPos.w;
				fixed4 col = tex2D(_MainTex, float2(i.screenPos.x, i.screenPos.y));
				return col;
			}
			ENDCG
		}
	}
}
