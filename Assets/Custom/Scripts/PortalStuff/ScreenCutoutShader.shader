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

				//float4x4 MatrixMVPWithoutOffset = UNITY_MATRIX_MVP;
				//MatrixMVPWithoutOffset[0, 3] += 0.01;
				//MatrixMVPWithoutOffset[1, 3] += 0.01;
				//MatrixMVPWithoutOffset[2, 3] += 0.01;
				//o.vertex = mul(MatrixMVPWithoutOffset, v.vertex);

				o.screenPos = ComputeScreenPos(o.vertex);
				//o.screenPos.x -= 0.05 + 0.1 * unity_StereoEyeIndex;
				
				float k = length(WorldSpaceViewDir(v.vertex));
				float distance = k * k * k;
				float offset = 0.005 * distance + 0.01;
				//float rotation = UNITY_MATRIX_V[0, 1];

				//float offsetX = (1 - abs(rotation)) * 0.2;
				//o.screenPos.x -= 0.5 * offsetX;
				//o.screenPos.x += unity_StereoEyeIndex * offsetX;
				o.screenPos.x -= offset;
				o.screenPos.x += 2 * unity_StereoEyeIndex * offset;
				//o.screenPos.y += 0.15 * rotation;
				//o.screenPos.y -= unity_StereoEyeIndex * 0.3 * rotation;

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
